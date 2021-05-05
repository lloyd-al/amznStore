using amznStore.Services.UserAuthentication.Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace amznStore.Services.UserAuthentication.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("UserAuthenticationDb"), options => {
                        options.MigrationsAssembly(typeof(UserDbContext).Assembly.FullName);
                        options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                     }));
        }
    }
}
