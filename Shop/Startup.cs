using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Common;

namespace Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //CONFIGURA A CONEXÃO COM O BANCO DE DADOS, INFORMANDO A STRING DE CONEXÃO
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString(DB.CONNECTION_STRING)));

            //INFORMANDO QUE VAMOS TRABALHAR COM CONTROLLER COM VIEW
            services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            //INFORMANDO QUE VAMOS TRABALHAR COM PÁGINA RAZOR
            services
                .AddRazorPages();

            services.AddScoped<IDbInitializer, DbInitializer>();
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
