using amznStore.Services.Catalog.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amznStore.Services.Catalog.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<IEnumerable<Category>> GetByName(string categoryName);
        Task<Category> GetById(string id);
        Task Add(Category category);
        Task<bool> Update(Category category);
        Task<bool> Delete(string id);
    }
}
