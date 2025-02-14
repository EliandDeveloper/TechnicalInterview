using Microsoft.Extensions.DependencyInjection;
using Technical.Application.Contracts;
using Technical.Application.Services;
using Technical.Infraestructure.Interfaces;
using Technical.Infraestructure.Respositories;

namespace Technical.Ioc.Dependencias
{
    public static class ProductsDependency
    {
        public static void AddProductsDependency(this IServiceCollection service)
        {
            service.AddScoped<IProductsRepository, ProductsRepository>();
            service.AddTransient<IProductsService, ProductsService> ();
        }
    }
}
