using amznStore.Services.Basket.Core.Interfaces;
using amznStore.Services.Basket.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace amznStore.Services.Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache cache)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<CustomerBasket> GetBasketAsync(string buyerId)
        {
            var basket = await _redisCache.GetStringAsync(buyerId);

            return basket == null ? null : JsonConvert.DeserializeObject<CustomerBasket>(basket);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            await _redisCache.SetStringAsync(basket.BuyerId, JsonConvert.SerializeObject(basket));

            return await GetBasketAsync(basket.BuyerId);
        }

        public async Task DeleteBasketAsync(string buyerId)
        {
            await _redisCache.RemoveAsync(buyerId);
        }
    }
}
