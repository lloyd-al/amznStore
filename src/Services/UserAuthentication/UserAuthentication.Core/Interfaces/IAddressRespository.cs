using amznStore.Services.UserAuthentication.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amznStore.Services.UserAuthentication.Core.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<UserAddress>> GetAll();
        Task<UserAddress> GetById(int id);
        Task AddAddress(UserAddress address);
        Task UpdateAddress(UserAddress address);
        Task DeleteAddress(UserAddress address);
        Task SetDefaultAddress(UserAddress address);
    }
}
