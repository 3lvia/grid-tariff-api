using Elvia.Telemetry.Impl;
using Kunde.TariffApi.Config;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace Kunde.TariffApi.Services.Logger
{
    public class LoggingHandler : ILoggingHandler
    {
        private GridTariffApiConfig _gridTariffApiConfig { get; set; }
        private readonly TelemetryClient telemetryClient;
        private readonly object _telemetryLogger;


        public LoggingHandler(GridTariffApiConfig _gridTariffApiConfig)
        {
            this._gridTariffApiConfig = _gridTariffApiConfig;
            telemetryClient = new TelemetryClient(new TelemetryConfiguration(_gridTariffApiConfig.InstrumentationKey));
            if (_gridTariffApiConfig.AlternativeSource.Equals("Elvia)"))
            {
                _telemetryLogger = new TelemetryInsightsLogger(telemetryClient);
            }
            else
            {
                _telemetryLogger = telemetryClient;
            }

        }

        public void TrackMetric(string metricName, double metricValue)
        {
            if (_telemetryLogger is TelemetryInsightsLogger)
            {
                ((TelemetryInsightsLogger)_telemetryLogger).TrackMetric(metricName, metricValue);
            }
            else
            {
                telemetryClient.TrackMetric(metricName, metricValue);
            }
        }
    }
}
