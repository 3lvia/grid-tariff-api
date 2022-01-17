using System;
using GridTariffApi.Middleware;

namespace GridTariffApi.Metrics
{
    public interface IMetricsLogger
    {
        public void LogRequestMetrics(string controller, string action, string method, int? responseCode, TimeSpan elapsedTimeSpan, IElviaLoggingDataCollector loggingDataCollector);
    }
}
