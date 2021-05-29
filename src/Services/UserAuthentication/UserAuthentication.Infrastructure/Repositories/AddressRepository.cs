using amznStore.Services.UserAuthentication.Core.Entities;
using amznStore.Services.UserAuthentication.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amznStore.Services.UserAuthentication.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public Task<IEnumerable<UserAddress>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserAddress> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAddress(UserAddress address)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAddress(UserAddress address)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAddress(UserAddress address)
        {
            throw new NotImplementedException();
        }
        
        public Task SetDefaultAddress(UserAddress address)
        {
            throw new NotImplementedException();
        }
    }
}
