using System;

namespace GridTariffApi.Metrics
{
    public interface IMetricsLogger
    {
        public void LogRequestMetrics(string controller, string action, string method, string responseCode, TimeSpan tariffTimeSpan, TimeSpan elapsedTimeSpan);
    }
}
