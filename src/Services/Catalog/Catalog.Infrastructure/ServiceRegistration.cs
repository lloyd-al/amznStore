using amznStore.Services.Catalog.Core.Interfaces;
using amznStore.Services.Catalog.Infrastructure.DataContexts;
using amznStore.Services.Catalog.Infrastructure.Repositories;
using amznStore.Services.Catalog.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace amznStore.Services.Catalog.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CatalogDatabaseSetting>(x => configuration.GetSection(nameof(CatalogDatabaseSetting)).Bind(x));

            services.AddSingleton<ICatalogDatabaseSetting>(sp => sp.GetRequiredService<IOptions<CatalogDatabaseSetting>>().Value);

            services.AddTransient<ICatalogDbContext, CatalogDbContext>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
