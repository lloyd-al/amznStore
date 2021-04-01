using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amznStore.Services.Catalog.Core.Interfaces
{
    public interface IIdentity
    {
        ObjectId Id { get; set; }
    }

    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task Add(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}
