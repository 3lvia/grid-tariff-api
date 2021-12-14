﻿using GridTariffApi.Lib.Config;
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
            DateTimeOffset timeZonedDateTime = GetTimeZonedDateTime(DateTime.UtcNow).Date;
            return AddDaysUsingQueryRangeParameter(range, timeZonedDateTime).ToUniversalTime(); ;
        }

        public DateTimeOffset GetEndDateTimeOffset(string? range, DateTimeOffset? endDateTime)
        {
            if (endDateTime.HasValue)
            {
                return endDateTime.Value;
            }
            DateTimeOffset timeZonedDateTime = GetTimeZonedDateTime(DateTime.UtcNow).Date;
            return AddDaysUsingQueryRangeParameter(range, timeZonedDateTime.AddDays(1).AddSeconds(-1)).ToUniversalTime();
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

        public DateTimeOffset GetTimeZonedDateTimeOffset(DateTimeOffset dateTimeOffset)
        {
            var retVal = TimeZoneInfo.ConvertTime(dateTimeOffset, _gridTariffApiConfig.TimeZoneForQueries);
            return retVal;
        }


        public DateTimeOffset DbTimeZoneDateToUtc(DateTime dateTime)
        {
            return new DateTimeOffset(dateTime, _gridTariffApiConfig.TimeZoneForQueries.GetUtcOffset(dateTime));
        }
    }
}
