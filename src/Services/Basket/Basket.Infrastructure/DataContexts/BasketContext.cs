using StackExchange.Redis;
using amznStore.Services.Basket.Core.Interfaces;

namespace amznStore.Services.Basket.Infrastructure.DataContexts
{
    public class BasketContext : IBasketContext
    {
        public ConnectionMultiplexer Connection { get; }

        public IDatabase Redis { get; }

        public BasketContext(ConnectionMultiplexer redisConnection)
        {
            Connection = redisConnection;
            Redis = redisConnection.GetDatabase();
        }


    }
}
