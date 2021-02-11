using Elvia.Telemetry;
using System.Threading;
using System.Threading.Tasks;

namespace GridTariffApi.Synchronizer.Lib.Services
{
    public class ScheduledGridTariffApiSynchronizer : CronJobService
    {
        private readonly ITelemetryInsightsLogger _logger;
        private readonly IGridTariffApiSynchronizer _gridTariffApiSynchronizer;

        public ScheduledGridTariffApiSynchronizer(
            ITelemetryInsightsLogger logger,
            IScheduleConfig<ScheduledGridTariffApiSynchronizer> config,
            IGridTariffApiSynchronizer gridTariffApiSynchronizer)
                        : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
            _gridTariffApiSynchronizer = gridTariffApiSynchronizer;


        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.TrackTrace("Setting up scheduled synchronizing of meteringpoints with netproducts from Google BigQuery");
            return base.StartAsync(cancellationToken);
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            _logger.TrackTrace("Starting synchronizing of meteringpoints with netproducts from Google BigQuery");
            await _gridTariffApiSynchronizer.SynchronizeMeteringPointsAsync();
            _logger.TrackTrace("Done synchronizing of Meteringpoints with netproducts from Google BigQuery");
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.TrackTrace("Failed synchronizing of meteringpoints with netproducts from Google BigQuery");
            return base.StopAsync(cancellationToken);
        }
    }
}
