using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace amznStore.Services.Catalog.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
