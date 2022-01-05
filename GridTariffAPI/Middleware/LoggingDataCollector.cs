using System;
using GridTariffApi.Lib.Interfaces;

namespace GridTariffApi.Middleware
{
    public class LoggingDataCollector : ILoggingDataCollector
    {
        public TimeSpan? TariffTimeSpan { get; private set; }
        
        public void RecordTariffPeriod(DateTimeOffset startDateTime, DateTimeOffset endDateTime)
        {
            TariffTimeSpan = endDateTime.Subtract(startDateTime);
        }
    }
}
