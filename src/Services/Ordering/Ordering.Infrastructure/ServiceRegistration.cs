using amznStore.Services.Ordering.Core.Interfaces;
using amznStore.Services.Ordering.Infrastructure.DataContexts;
using amznStore.Services.Ordering.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace amznStore.Services.Ordering.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(c =>
                c.UseSqlServer(configuration.GetConnectionString("OrderConnection")), ServiceLifetime.Singleton);
            // we made singleton this in order to resolve in mediatR when consuming Rabbit

            // Add Infrastructure Layer
            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddTransient<IOrderRepository, OrderRepository>();
            // we made transient this in order to resolve in mediatR when consuming Rabbit
        }
    }
}
