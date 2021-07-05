using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Common;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Data.SqlClient;
using Services;

namespace Shop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public DbConnection DbConnection => new SqlConnection(Configuration.GetConnectionString(DB.CONNECTION_STRING));
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //CONFIGURA O NOVO CAMINHA DAS ÁREAS => PASSANDO DE [Areas] PARA [Modulo]
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Modules/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Modules/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            //CONFIGURA A CONEXÃO COM O BANCO DE DADOS, INFORMANDO A STRING DE CONEXÃO
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    //String de Conexão está definida na propriedade DbConnection
                    DbConnection,
                    //Definições de banco de dados está no assembly que o ApplicationDbContext se encontra.
                    assembly => assembly
                                .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            //INFORMANDO QUE VAMOS TRABALHAR COM CONTROLLER COM VIEW
            services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            //INFORMANDO QUE VAMOS TRABALHAR COM PÁGINA RAZOR
            services
                .AddRazorPages();


            //INJENÇÃO DE DEPENDÊNCIA
            services.AllDependencyInjection();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IDbInitializer dbInit)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //MÉTODO PARA CRIAR E INSERIR REGISTRO NO BANCO DE DADOS.
            dbInit.Initialize();

            app.UseAuthorization();

            //VAMOS ATRABALHAR COM ÁREAS
            app.UseEndpoints(endpoints =>
            {
                //Configurando Rota de Areas
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("AreaCategory", "Register", "Category/{controller=Category}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("AreaSubCategory", "Register", "SubCategory/{controller=SubCategory}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("AreaProduct", "Register", "Product/{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
