using amznStore.Services.Basket.Core.Interfaces;
using amznStore.Services.Basket.Infrastructure.DataContexts;
using amznStore.Services.Basket.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace amznStore.Services.Basket.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                var configuration = ConfigurationOptions.Parse(_configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddTransient<IBasketContext, BasketContext>();
            services.AddTransient<IBasketRepository, BasketRepository>();
        }
    }
}
