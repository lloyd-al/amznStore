using System;

namespace amznStore.Common.Core.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
