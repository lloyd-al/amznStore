using System;
using amznStore.Common.Core.Interfaces;

namespace amznStore.Common.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
