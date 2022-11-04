using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Models.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GridTariffApi.Lib.Services.Helpers
{
    public class ServiceHelper : IServiceHelper
    {
        private readonly GridTariffApiConfig _gridTariffApiConfig;
        public ServiceHelper(GridTariffApiConfig gridTariffApiConfig)
        {
            _gridTariffApiConfig = gridTariffApiConfig;

        }

        public List<TimePeriod> GetMonthPeriods(DateTimeOffset fromDate, DateTimeOffset toDate, IReadOnlyList<int> months)
        {
            var accumulator = new List<TimePeriod>();
            var currPeriodStartDateLocaled = ToConfiguredTimeZone(fromDate);
            var currPeriodEndDateLocaled = ToConfiguredTimeZone(toDate);

            //accumulate
            while (currPeriodStartDateLocaled < currPeriodEndDateLocaled)
            {
                if (months.Contains(currPeriodStartDateLocaled.Month))
                {
                    DateTimeOffset monthEndLocaled = GetStartOfNextMonth(currPeriodStartDateLocaled);
                    var timePeriod = new TimePeriod();
                    timePeriod.StartDate = currPeriodStartDateLocaled;
                    timePeriod.EndDate = monthEndLocaled < currPeriodEndDateLocaled ? monthEndLocaled : currPeriodEndDateLocaled;

                    accumulator.Add(timePeriod);
                }
                currPeriodStartDateLocaled = GetStartOfNextMonth(currPeriodStartDateLocaled);
            }

            //concat
            var retVal = new List<TimePeriod>();
            accumulator = accumulator.OrderBy(x => x.StartDate).ToList();
            if (accumulator.Count > 0)
            {
                var accTimePeriod = accumulator[0];
                for (int i =1;i< accumulator.Count;i++)
                {
                    var currTimePeriod = accumulator[i];
                    if (accTimePeriod.EndDate.Year == currTimePeriod.StartDate.Year && accTimePeriod.EndDate.Month == currTimePeriod.StartDate.Month)
                    {
                        accTimePeriod.EndDate = currTimePeriod.EndDate;
                    }
                    else
                    {
                        retVal.Add(accTimePeriod);
                        accTimePeriod = currTimePeriod;
                    }
                }
                retVal.Add(accTimePeriod);
            }

            return retVal;
        }

        public DateTimeOffset GetStartOfNextMonth(DateTimeOffset fromDateLocaled)
        {
            var retVal = new DateTimeOffset(fromDateLocaled.Year, fromDateLocaled.Month, 1, 0, 0, 0, 0, fromDateLocaled.Offset);
            retVal = retVal.AddMonths(1);
            return WithCorrectedLocalizedOffset(retVal);
        }

        /// <summary>
        /// Input is DateTimeOffset with localized values, but with possibly missing/wrong offset.
        /// Output is DateTimeOffset with localized values with correct offset.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// 
        public DateTimeOffset WithCorrectedLocalizedOffset(DateTimeOffset value)
        {
            return CreateLocaledDateTimeOffset(
                value.Year,
                value.Month,
                value.Day,
                value.Hour,
                value.Minute,
                value.Second);
        }
        /// <summary>
        /// Input is localized time, output is datettimeoffset with DST-adjusted offset
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public virtual DateTimeOffset CreateLocaledDateTimeOffset(int year, int month, int day,int hour, int minute, int second)
        {
            var dateTime = new DateTime(year, month, day, hour, minute, second);
            dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
            var dateTimeUtc= TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime, _gridTariffApiConfig.TimeZoneForQueries.Id, "UTC");
            var dateTimeLocaled = TimeZoneInfo.ConvertTime(dateTimeUtc, _gridTariffApiConfig.TimeZoneForQueries);
            var timeZoneOffset = _gridTariffApiConfig.TimeZoneForQueries.GetUtcOffset(dateTimeLocaled);
            return new DateTimeOffset(dateTimeLocaled, timeZoneOffset);
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
            return AddDaysUsingQueryRangeParameter(range, localTimeToday.AddDays(1));
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

        public virtual DateTimeOffset ToConfiguredTimeZone(DateTimeOffset dateTimeOffset)
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
        public DateTimeOffset DecideEndOfDay(DateTimeOffset paramToDate, DateTimeOffset currentDateTime)
        {
            //middle of next day
            var middleOfNextDay = currentDateTime.Date.AddHours(12).AddDays(1);

            //next midnight and correct for DST change
            var nextMidnight = CreateLocaledDateTimeOffset(middleOfNextDay.Year, middleOfNextDay.Month, middleOfNextDay.Day, 0, 0, 0);

            return nextMidnight < paramToDate ? nextMidnight : paramToDate;
        }
    }
}
