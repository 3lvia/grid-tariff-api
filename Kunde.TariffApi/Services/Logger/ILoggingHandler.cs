namespace Kunde.TariffApi.Services.Logger
{
    public interface ILoggingHandler
    {
        void TrackMetric(string metricName, double metricValue);
    }
}