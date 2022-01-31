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

        public DateTimeOffset GetStartDateTimeOffset(string? range, DateTimeOffset? startDateTime)
        {
            if (startDateTime.HasValue)
            {
                return startDateTime.Value;
            }
            var localTimeNow = ToConfiguredTimeZone(DateTime.UtcNow);
            var localTimeToday = new DateTimeOffset(localTimeNow.Year, localTimeNow.Month, localTimeNow.Day, 0, 0, 0, localTimeNow.Offset);
            return AddDaysUsingQueryRangeParameter(range, localTimeToday);
        }

        public DateTimeOffset GetEndDateTimeOffset(string? range, DateTimeOffset? endDateTime)
        {
            if (endDateTime.HasValue)
            {
                return endDateTime.Value;
            }
            var localTimeNow = ToConfiguredTimeZone(DateTime.UtcNow);
            var localTimeToday = new DateTimeOffset(localTimeNow.Year, localTimeNow.Month, localTimeNow.Day, 0, 0, 0, localTimeNow.Offset);
            return AddDaysUsingQueryRangeParameter(range, localTimeToday.AddDays(1).AddSeconds(-1));
        }

        private DateTimeOffset AddDaysUsingQueryRangeParameter(string? range, DateTimeOffset dateTimeOffset)
        {
            if (!String.IsNullOrEmpty(range))
            {
                if (range.Equals("yesterday"))
                {
                    return dateTimeOffset.AddDays(-1);
                }
                if (range.Equals("tomorrow"))
                {
                    return dateTimeOffset.AddDays(1);
                }
            }
            return dateTimeOffset;
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
        public DateTime GetTimeZonedDateTime(DateTime datetime)
        {
            var timeZonedDateTime = TimeZoneInfo.ConvertTimeFromUtc(datetime, _gridTariffApiConfig.TimeZoneForQueries);
            return timeZonedDateTime;
        }

        public DateTimeOffset ToConfiguredTimeZone(DateTimeOffset dateTimeOffset)
        {
            var retVal = TimeZoneInfo.ConvertTime(dateTimeOffset, _gridTariffApiConfig.TimeZoneForQueries);
            return retVal;
        }


        public DateTimeOffset DbTimeZoneDateToUtc(DateTime dateTime)
        {
            return new DateTimeOffset(dateTime, _gridTariffApiConfig.TimeZoneForQueries.GetUtcOffset(dateTime));
        }

        public virtual bool TimePeriodIsIncludingLocaleToday(DateTimeOffset fromDateTime, DateTimeOffset toDateTime)
        {
            var localNow = ToConfiguredTimeZone(DateTimeOffset.UtcNow);
            var localTodayStart = new DateTimeOffset(localNow.Date, localNow.Offset);
            var localTodayEnd = localTodayStart.AddDays(1);

            if (localTodayStart >= toDateTime)
            {
                return false;
            }
            if (localTodayEnd <= fromDateTime)
            {
                return false;
            }
            return true;
        }
    }
}
