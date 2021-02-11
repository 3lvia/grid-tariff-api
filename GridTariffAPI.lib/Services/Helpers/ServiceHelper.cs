using GridTariffApi.Lib.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Lib.Services.Helpers
{
    public class ServiceHelper : IServiceHelper
    {
        private readonly GridTariffApiConfig _gridTariffApiConfig;
        public ServiceHelper(GridTariffApiConfig gridTariffApiConfig)
        {
            _gridTariffApiConfig = gridTariffApiConfig;

        }
        public DateTime GetStartTime(string? range, DateTime? startDateTime)
        {
            if (startDateTime.HasValue)
            {
                return startDateTime.Value;
            }
            DateTime timeZonedDateTime = GetTimeZonedDateTime(DateTime.UtcNow).Date;
            return AddDaysUsingQueryRangeParameter(range, timeZonedDateTime);

        }

        public DateTime GetEndTime(string? range, DateTime? endDateTime)
        {
            if (endDateTime.HasValue)
            {
                return endDateTime.Value;
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

        private DateTime GetTimeZonedDateTime(DateTime datetime)
        {
            var timeZonedDateTime = TimeZoneInfo.ConvertTimeFromUtc(datetime, _gridTariffApiConfig.TimeZoneForQueries);
            return timeZonedDateTime;
        }
    }
}
