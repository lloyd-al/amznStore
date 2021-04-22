using StackExchange.Redis;

namespace amznStore.Services.Basket.Core.Interfaces
{
    public interface IBasketContext
    {
        public ConnectionMultiplexer Connection { get; }
        IDatabase Redis { get; }
    }
}
