using System;
using GridTariffApi.Middleware;
using Prometheus;

namespace GridTariffApi.Metrics
{
    public class MetricsLogger : IMetricsLogger
    {
        private readonly Histogram _tariffLatencyHistogram;
        private readonly Histogram _mdmxLatencyHistogram;
        private readonly Counter _mdmxCacheHitCounter;

        public MetricsLogger()
        {
            // Inspired by AddStandardElviaAspnetMetrics. We'll use our own metrics for latency with custom labels/categories (haven't found a feasible way of adding our own labels to standard metrics).
            // We'll use the standard labels for our metrics, too (controller/action/method/code).

            _tariffLatencyHistogram = Prometheus.Metrics.CreateHistogram("kunde_gridtariffapi_http_request_duration_seconds", "The duration of HTTP requests processed by an ASP.NET Core application. With custom labels for the grid-tariff-api application.",
                new HistogramConfiguration
                {
                    Buckets = new[] { 0.001, 0.002, 0.005, 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, 1.0, 2.0, 5.0, 10.0, 20.0, 60.0 },
                    LabelNames = new[] { "controller", "action", "method", "code", "tariff_period_range", "num_meteringpoints_range" }
                });

            _mdmxLatencyHistogram = Prometheus.Metrics.CreateHistogram("kunde_gridtariffapi_mdmx_request_duration_seconds", "The duration of HTTP requests to fetch maxConsumption from MDMx. All meteringPointIds from the call to grid-tariff-api with cache misses will be included in the same call to the MDMx API. The period in the MDMx request is from the start of the current month until now.",
                new HistogramConfiguration
                {
                    Buckets = new[] { 0.001, 0.002, 0.005, 0.01, 0.02, 0.05, 0.1, 0.2, 0.5, 1.0, 2.0, 5.0, 10.0, 20.0, 60.0 },
                    LabelNames = new[] { "controller", "action", "method", "code", "num_meteringpoints_range" }
                });

            _mdmxCacheHitCounter = Prometheus.Metrics.CreateCounter("kunde_gridtariffapi_mdmx_cache_hit_counter", "The number of cache hits and misses for maxConsumption data from the MDMx API. Cache misses will result in calls to the MDMx API. All meteringPointIds from the call to grid-tariff-api with cache misses will be included in the same call to the MDMx API.",
                new CounterConfiguration
                {
                    LabelNames = new[] { "controller", "action", "method", "code", "hit_or_miss", "num_meteringpoints_range" }
                });

            // Initialize metrics, by referencing them.
            // We won't initialize all variants, but the most important ones.
            foreach (var numMeteringPointsRange in new[] { "0", "1", "2-10", "> 10" })
            {
                var controller = "TariffQuery";
                foreach (var tariffPeriodRange in new[] { "< 1 dg", "1-30 dg", "1-6 mnd", "> 6 mnd" })
                {
                    _tariffLatencyHistogram.WithLabels(controller, "TariffQuery", "GET", "200", tariffPeriodRange, numMeteringPointsRange);

                    _tariffLatencyHistogram.WithLabels(controller, "MeteringPointsTariffQuery", "POST", "200", tariffPeriodRange, numMeteringPointsRange);
                }
                _mdmxLatencyHistogram.WithLabels(controller, "MeteringPointsTariffQuery", "POST", "200", numMeteringPointsRange);
                foreach (var hitOrMiss in new[]{"hit", "miss"})
                {
                    _mdmxCacheHitCounter.WithLabels(controller, "MeteringPointsTariffQuery", "POST", "200", hitOrMiss, numMeteringPointsRange);
                }
            }
        }

        public void LogRequestMetrics(string controller, string action, string method, int? responseCode, TimeSpan elapsedTimeSpan, IElviaLoggingDataCollector loggingDataCollector)
        {
            // Our custom metrics are only for successful calls. Failed calls are handled by standard metrics.
            if (responseCode == null || responseCode >= 400)
            {
                return;
            }

            // Our custom metrics are for requests to tariff operations, where we require a tariff period.
            if (loggingDataCollector.TariffTimeSpan == null)
            {
                return;
            }

            var tariffTimeSpan = (TimeSpan)loggingDataCollector.TariffTimeSpan;

            var elapsedSeconds = elapsedTimeSpan.TotalSeconds;

            var tariffPeriodRange = TariffPeriodRangeFor(tariffTimeSpan);
            var numMeteringPointsRange = NumMeteringpointsRangeFor(loggingDataCollector.NumMeteringPoints);

            _tariffLatencyHistogram.WithLabels(controller, action, method, responseCode.ToString(), tariffPeriodRange, numMeteringPointsRange).Observe(elapsedSeconds);

            // Metrics on operations with MdmxElapsedSeconds / cache hits
            if (loggingDataCollector.MdmxElapsedSeconds.HasValue)
            {
                _mdmxLatencyHistogram.WithLabels(controller, action, method, responseCode.ToString(), numMeteringPointsRange).Observe(loggingDataCollector.MdmxElapsedSeconds.Value);
            }

            if (loggingDataCollector.NumMaxConsumptionCacheHits.HasValue)
            {
                _mdmxCacheHitCounter.WithLabels(controller, action, method, responseCode.ToString(), "hit", numMeteringPointsRange).Inc(loggingDataCollector.NumMaxConsumptionCacheHits.Value);
            }

            if (loggingDataCollector.NumMaxConsumptionCacheMisses.HasValue)
            {
                _mdmxCacheHitCounter.WithLabels(controller, action, method, responseCode.ToString(), "miss", numMeteringPointsRange).Inc(loggingDataCollector.NumMaxConsumptionCacheMisses.Value);
            }
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

        private string NumMeteringpointsRangeFor(int? numMeteringpoints)
        {
            return (numMeteringpoints ?? 0) switch
            {
                0 => "0",
                1 => "1",
                var n when (n <= 10) => "2-10",
                _ => "> 10"
            };
        }
    }
}