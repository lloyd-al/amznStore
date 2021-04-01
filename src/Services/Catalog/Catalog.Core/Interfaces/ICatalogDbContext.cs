using amznStore.Services.Catalog.Core.Entities;
using MongoDB.Driver;

namespace amznStore.Services.Catalog.Core.Interfaces
{
    public interface ICatalogDbContext
    {
        IMongoCollection<Product> Products { get; }
        IMongoCollection<Category> Categories { get; }
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
