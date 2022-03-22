using Cronos;
using Elvia.Telemetry;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GridTariffApi.Synchronizer.Lib.Services
{
    public abstract class CronJobService : IHostedService, IDisposable
    {
        private System.Timers.Timer _timer;
        private readonly CronExpression _expression;
        private readonly TimeZoneInfo _timeZoneInfo;
        private readonly ITelemetryInsightsLogger _logger;

        protected CronJobService(string cronExpression, TimeZoneInfo timeZoneInfo, ITelemetryInsightsLogger logger)
        {
            _logger = logger;
            _expression = CronExpression.Parse(cronExpression);
            _timeZoneInfo = timeZoneInfo;
        }

        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                await ScheduleJob(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.TrackException(e);
            }
        }

        protected virtual async Task ScheduleJob(CancellationToken cancellationToken)
        {
            try
            {
                var next = _expression.GetNextOccurrence(DateTimeOffset.Now, _timeZoneInfo);
                if (next.HasValue)
                {
                    var timezonedNow = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, _timeZoneInfo);
                    var delay = next.Value - timezonedNow;
                    if (delay.TotalMilliseconds <= 0) // prevent non-positive values from being passed into Timer
                    {
                        _logger.TrackTrace("CronJobServiceRescheduledDueToNegativeDelay", new {Delay = delay});
                        await ScheduleJob(cancellationToken);
                    }

                    _timer = new System.Timers.Timer(delay.TotalMilliseconds);
                    _timer.Elapsed += async (sender, args) =>
                    {
                        _timer?.Dispose(); // reset and dispose timer
                        _timer = null;

                        if (!cancellationToken.IsCancellationRequested)
                        {
                            await DoWork(cancellationToken);
                        }

                        if (!cancellationToken.IsCancellationRequested)
                        {
                            await ScheduleJob(cancellationToken); // reschedule next
                        }
                    };
                    _timer.Start();
                }

                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                _logger.TrackException(e);
                throw;
            }
        }

        public virtual async Task DoWork(CancellationToken cancellationToken)
        {
            await Task.Delay(5000, cancellationToken); // do the work
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Stop();
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _timer?.Dispose();
        }
    }

    public interface IScheduleConfig<T>
    {
        string CronExpression { get; set; }
        TimeZoneInfo TimeZoneInfo { get; set; }
    }

    public class ScheduleConfig<T> : IScheduleConfig<T>
    {
        public string CronExpression { get; set; }
        public TimeZoneInfo TimeZoneInfo { get; set; }
    }

    public static class ScheduledServiceExtensions
    {
        public static IServiceCollection AddCronJob<T>(this IServiceCollection services, Action<IScheduleConfig<T>> options) where T : CronJobService
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options), @"Please provide Schedule Configurations.");
            }

            var config = new ScheduleConfig<T>();
            options.Invoke(config);
            if (string.IsNullOrWhiteSpace(config.CronExpression))
            {
                throw new ArgumentException("Empty CronExpression is not allowed.", nameof(options));
            }

            services.AddSingleton<IScheduleConfig<T>>(config);
            services.AddHostedService<T>();
            return services;
        }
    }
}