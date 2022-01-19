using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GridTariffApi.Metrics
{
    public class LoggingDataCollector : IElviaLoggingDataCollector
    {
        public TimeSpan? TariffTimeSpan { get; private set; }
        public int? NumMeteringPoints { get; private set; }
        public double? MdmxElapsedSeconds { get; private set; }
        public int? NumMaxConsumptionCacheHits { get; private set; }
        public int? NumMaxConsumptionCacheMisses { get; private set; }
        
        public void RegisterTariffPeriodAndNumMeteringPoints(DateTimeOffset startDateTime, DateTimeOffset endDateTime, int? numMeteringPoints)
        {
            TariffTimeSpan = endDateTime.Subtract(startDateTime);
            NumMeteringPoints = numMeteringPoints;
        }

        public async Task<T> MeasureMdmxElapsedTimeAsync<T>(Func<Task<T>> mdmxAction)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var res = await mdmxAction();

            stopWatch.Stop();
            MdmxElapsedSeconds = stopWatch.ElapsedMilliseconds / 1000.0;

            return res;
        }

        public void RegisterMaxConsumptionCacheHitStatistics(int numHits, int numMisses)
        {
            NumMaxConsumptionCacheHits = numHits;
            NumMaxConsumptionCacheMisses = numMisses;
        }
    }
}
