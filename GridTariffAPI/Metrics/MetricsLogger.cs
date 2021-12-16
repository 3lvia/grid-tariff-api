using System;
using Prometheus;

namespace GridTariffApi.Metrics
{
    public class MetricsLogger : IMetricsLogger
    {
        private readonly Histogram _tariffLatencyHistogram;
        private readonly Histogram _tariffLatencyPerMonthHistogram;

        public MetricsLogger()
        {
            // Inspired by AddStandardElviaAspnetMetrics. We'll use our own metrics for latency with custom labels/categories (haven't found a feasible way of adding our own labels to standard metrics).
            // We'll use the standard labels for our metrics, too (controller/action/method/code).

            // We plan to include the number of metering points as a custom label, too. And expand the "per_month" histogram to meteringpoint-months.

            _tariffLatencyHistogram = Prometheus.Metrics.CreateHistogram("kunde_gridtariffapi_http_request_duration_seconds", "The duration of HTTP requests processed by an ASP.NET Core application. With custom labels for the grid-tariff-api application.", 
                new HistogramConfiguration
                {
                    Buckets = new double[] { 0.001, 0.002, 0.005, 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, 1.0, 2.0, 5.0, 10.0, 20.0, 60.0 },
                    LabelNames = new string[] { "controller", "action", "method", "code", "tariff_period_range" }
                });
            _tariffLatencyPerMonthHistogram = Prometheus.Metrics.CreateHistogram("kunde_gridtariffapi_http_request_duration_seconds_per_month", "The duration of HTTP requests processed by an ASP.NET Core application. With custom labels for the grid-tariff-api application. Latency per month (30d) in the requested period.", 
                new HistogramConfiguration
                {
                    Buckets = new double[] { 0.001, 0.002, 0.005, 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, 1.0, 2.0, 5.0, 10.0, 20.0, 60.0 },
                    LabelNames = new string[] { "controller", "action", "method", "code", "tariff_period_range" }
                });

            // Initialize metrics, by referencing them.
            foreach (var tariffPeriodRange in new[] {"< 1 dg", "1-30 dg", "1-6 mnd", "> 6 mnd"})
            {
                // We won't initialize all variants
                _tariffLatencyHistogram.WithLabels("TariffQuery", "TariffQuery", "GET", "200", tariffPeriodRange);
                _tariffLatencyPerMonthHistogram.WithLabels("TariffQuery", "TariffQuery", "GET", "200", tariffPeriodRange);
            }
        }
        
        public void LogRequestMetrics(string controller, string action, string method, string responseCode, TimeSpan tariffTimeSpan, TimeSpan elapsedTimeSpan)
        {
            var elapsedSeconds = elapsedTimeSpan.TotalSeconds;
            var numMonths = tariffTimeSpan.TotalDays / 30;
            var elapsedSecondsPerMonth = elapsedSeconds / numMonths;

            var tariffPeriodRange = TariffPeriodRangeFor(tariffTimeSpan);

            _tariffLatencyHistogram.WithLabels(controller, action, method, responseCode, tariffPeriodRange).Observe(elapsedSeconds);
            _tariffLatencyPerMonthHistogram.WithLabels(controller, action, method, responseCode, tariffPeriodRange).Observe(elapsedSecondsPerMonth);
        }

        private string TariffPeriodRangeFor(TimeSpan tariffTimeSpan)
        {
            var numDays = tariffTimeSpan.TotalDays;

            var periodRange = numDays switch
            {
                var n when (n <= 1) => "< 1 dg",
                var n when (n <= 30) => "1-30 dg",
                var n when (n <= 182) => "1-6 mnd",
                _ => "> 6 mnd"
            };

            return periodRange;
        }
    }
}
