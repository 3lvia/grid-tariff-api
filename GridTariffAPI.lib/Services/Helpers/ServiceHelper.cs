using GridTariffApi.Lib.Config;
using System;

namespace GridTariffApi.Lib.Services.Helpers
{
    public class ServiceHelper : IServiceHelper
    {
        private readonly GridTariffApiConfig _gridTariffApiConfig;
        public ServiceHelper(GridTariffApiConfig gridTariffApiConfig)
        {
            _gridTariffApiConfig = gridTariffApiConfig;

        }

#nullable enable
        public DateTime GetStartTime(string? range, DateTimeOffset? startDateTime)
        {
            if (startDateTime.HasValue)
            {
                return startDateTime.Value.DateTime;
            }
            DateTime timeZonedDateTime = GetTimeZonedDateTime(DateTime.UtcNow).Date;
            return AddDaysUsingQueryRangeParameter(range, timeZonedDateTime);
        }

        public DateTime GetEndTime(string? range, DateTimeOffset? endDateTime)
        {
            if (endDateTime.HasValue)
            {
                return endDateTime.Value.DateTime;
            }
            DateTime timeZonedDateTime = GetTimeZonedDateTime(DateTime.UtcNow).Date;
            return AddDaysUsingQueryRangeParameter(range, timeZonedDateTime.AddDays(1).AddSeconds(-1));
        }

        private DateTime AddDaysUsingQueryRangeParameter(string? range, DateTime dateTime)
        {
            if (!String.IsNullOrEmpty(range))
            {
                if (range.Equals("yesterday"))
                {
                    return dateTime.AddDays(-1);
                }
                if (range.Equals("tomorrow"))
                {
                    return dateTime.AddDays(1);
                }
            }
            return dateTime;
        }
#nullable disable
        private DateTime GetTimeZonedDateTime(DateTime datetime)
        {
            var timeZonedDateTime = TimeZoneInfo.ConvertTimeFromUtc(datetime, _gridTariffApiConfig.TimeZoneForQueries);
            return timeZonedDateTime;
        }

        public DateTimeOffset DbTimeZoneDateToUtc(DateTime dateTime)
        {
            return new DateTimeOffset(dateTime, _gridTariffApiConfig.TimeZoneForQueries.GetUtcOffset(dateTime));
        }
    }
}
