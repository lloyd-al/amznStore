using amznStore.Services.Catalog.Core.Interfaces;

namespace amznStore.Services.Catalog.Infrastructure.Settings
{
    public class CatalogDatabaseSetting : ICatalogDatabaseSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ProductCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
    }
}
