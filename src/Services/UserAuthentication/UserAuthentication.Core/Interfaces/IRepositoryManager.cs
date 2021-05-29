using System.Threading.Tasks;

namespace amznStore.Services.UserAuthentication.Core.Interfaces
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IAddressRepository Address { get; }
        Task Save();
    }
}
