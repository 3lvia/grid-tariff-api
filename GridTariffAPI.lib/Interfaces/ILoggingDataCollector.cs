using System;

namespace GridTariffApi.Lib.Interfaces
{
    /// <summary>
    /// Collects data from specific operations. Used for logging details about calls in request pipeline middleware. Should be set up as scoped instance to gather statistics per request. If you don't need this feature, it is OK to omit it from the service collection setup (null is handled).
    /// </summary>
    public interface ILoggingDataCollector
    {
        public TimeSpan? TariffTimeSpan { get; }
        public void RecordTariffPeriod(DateTimeOffset startDateTime, DateTimeOffset endDateTime);
    }
}
