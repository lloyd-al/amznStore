using Microsoft.Extensions.DependencyInjection;
using amznStore.Common.Infrastructure.Extensions;

namespace amznStore.Services.Catalog.Api.Extensions
{ 
    public static class ServiceExtension
    {
        public static void ConfigureExtensions(this IServiceCollection services)
        {
            services.ConfigureApiVersioning();
            services.ConfigureSwagger("Catalog Api");
            services.ConfigureMailService();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => 
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
