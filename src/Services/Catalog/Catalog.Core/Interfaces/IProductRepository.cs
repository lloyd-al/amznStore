using amznStore.Common.Core.Entities.Filters;
using amznStore.Services.Catalog.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amznStore.Services.Catalog.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<(IEnumerable<Product> products, long totalRecords, int totalPages)> GetAll(RequestParameters filter);
        Task<(IEnumerable<Product> products, long totalRecords, int totalPages)> GetByCategory(string category, RequestParameters filter);
        Task<IEnumerable<Product>> GetByName(string productName);
        Task<Product> GetById(string id);
        Task Add(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(string id);
    }
}
