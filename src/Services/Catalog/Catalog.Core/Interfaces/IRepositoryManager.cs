using System;

namespace amznStore.Services.Catalog.Core.Interfaces
{
    public interface IRepositoryManager
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
    }
}
