using System.Threading.Tasks;
using amznStore.Services.Basket.Core.Entities;

namespace amznStore.Services.Basket.Core.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string buyerId);
        //IEnumerable<string> GetUsers();
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task DeleteBasketAsync(string buyerId);
    }
}
