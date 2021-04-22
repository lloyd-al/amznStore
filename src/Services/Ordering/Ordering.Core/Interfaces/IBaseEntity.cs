using System;

namespace amznStore.Services.Ordering.Core.Interfaces
{
    public interface IBaseEntity<TId>
    {
        TId Id { get; }
    }
}
