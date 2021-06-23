using amznStore.Common.Infrastructure.Extensions;
using amznStore.Services.Discount.Api.ActionFilters;
using amznStore.Services.Discount.Core.Interfaces;
using amznStore.Services.Discount.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace amznStore.Services.Discount.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureApiVersioning();
            services.ConfigureSwagger("Discount Api");

            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("DiscountDb"));
        }
    }
}
