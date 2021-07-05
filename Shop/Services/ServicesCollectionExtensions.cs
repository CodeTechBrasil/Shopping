using DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Shop
{
    public static class ServicesCollectionExtensions
    {
        public static void AllDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<IProductController, ProductController>();

            services.AddScoped<ICategoryController, CategoryController>();
            services.AddScoped<ISubCategoryController, SubCategoryController>();
            services.AddScoped<IProductRepository, ProductRepository>();

            //return services;
        }
    }
}
