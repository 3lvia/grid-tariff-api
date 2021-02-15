using Elvia.Telemetry;
using System;
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
                        : base(config.CronExpression, config.TimeZoneInfo, logger)
        {
            _logger = logger;
            _gridTariffApiSynchronizer = gridTariffApiSynchronizer;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.TrackTrace("Setting up scheduled synchronizing of meteringpoints with netproducts from Google BigQuery");
                return base.StartAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.TrackException(e);
                throw;
            }
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            try
            {
                _logger.TrackTrace("Starting synchronizing of meteringpoints with netproducts from Google BigQuery");
                await _gridTariffApiSynchronizer.SynchronizeMeteringPointsAsync();
                _logger.TrackTrace("Done synchronizing of Meteringpoints with netproducts from Google BigQuery");
            }
            catch (Exception e)
            {
                _logger.TrackException(e);
                throw;
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.TrackTrace("Failed synchronizing of meteringpoints with netproducts from Google BigQuery");
                return base.StopAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.TrackException(e);
                throw;
            }
        }
    }
}
