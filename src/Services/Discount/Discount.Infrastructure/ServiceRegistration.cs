using amznStore.Services.Discount.Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace amznStore.Services.Discount.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DiscountDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DiscountDb"), options => {
                        options.MigrationsAssembly(typeof(DiscountDbContext).Assembly.FullName);
                        options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                     }));
        }
    }
}
