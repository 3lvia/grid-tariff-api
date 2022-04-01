﻿using GridTariffApi.Lib.Config;
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
            var fromDateLocaled = ToConfiguredTimeZone(fromDate);
            var toDateLocaled = ToConfiguredTimeZone(toDate);

            //accumulate
            while (fromDateLocaled < toDateLocaled)
            {
                if (months.Contains(fromDateLocaled.Month))
                {
                    var monthEndLocaled = fromDateLocaled.AddDays(1 - fromDateLocaled.Day).AddMonths(1);
                    monthEndLocaled = monthEndLocaled.AddHours(-monthEndLocaled.Hour).AddMinutes(-monthEndLocaled.Minute);
                    var timePeriod = new TimePeriod();
                    timePeriod.StartDate = fromDateLocaled;
                    timePeriod.EndDate = monthEndLocaled < toDateLocaled ? monthEndLocaled : toDateLocaled;

                    accumulator.Add(timePeriod);
                }
                fromDateLocaled = fromDateLocaled.AddDays(1 - fromDateLocaled.Day).AddMonths(1);
                fromDateLocaled = fromDateLocaled.AddHours(-fromDateLocaled.Hour).AddMinutes(-fromDate.Minute);
            }

            //adjust for standard time/DST
            foreach (var element in accumulator)
            {
                element.StartDate = CreateLocaledDateTimeOffset(element.StartDate);
                element.EndDate = CreateLocaledDateTimeOffset(element.EndDate);
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

//adjust for standard time/DST
            foreach (var element in accumulator)
            {
                element.StartDate = CreateLocaledDateTimeOffset(element.StartDate);
                element.EndDate = CreateLocaledDateTimeOffset(element.EndDate);
            }
            return retVal;
        }

        //private DateTimeOffset CalcSeasonStart(DateTimeOffset fromDate, ref DateTimeOffset fromDateLocaled, int? startMonth)
        //{
        //    if (fromDateLocaled.Month != startMonth.Value)
        //    {
        //        fromDateLocaled = fromDateLocaled.AddMonths(startMonth.Value - fromDateLocaled.Month);
        //    }
        //    fromDateLocaled = fromDateLocaled.AddDays(1 - fromDateLocaled.Day).AddHours(-fromDateLocaled.Hour).AddMinutes(-fromDate.Minute);
        //    var seasonStartTimeLocaledAndTimeZoneCorrected = _serviceHelper.DbTimeZoneDateToUtc(fromDateLocaled.DateTime);
        //    //            var seasonStart = fromDate.AddTicks(seasonStartTimeLocaledAndTimeZoneCorrected.UtcDateTime.Ticks - fromDate.Ticks);
        //    //GLUE-1541 - temp quickfix for problem related to transition from one season to another.
        //    //functionality to calc intersection between "season" and taxperiod should be rewritten
        //    var seasonStart = fromDate.AddTicks(seasonStartTimeLocaledAndTimeZoneCorrected.UtcDateTime.Ticks - fromDate.UtcDateTime.Ticks);
        //    return seasonStart;
        //}

        public DateTimeOffset CreateLocaledDateTimeOffset(DateTimeOffset value)
        {
            return CreateLocaledDateTimeOffset(
                value.Year,
                value.Month,
                value.Day,
                value.Hour,
                value.Minute,
                value.Second);
        }

        public DateTimeOffset CreateLocaledDateTimeOffset(int year, int month, int day,int hour, int minute, int second)
        {
            var dateTime = new DateTime(year, month, day, hour, minute, second);
            dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
            var dateTimeLocaled = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime, _gridTariffApiConfig.TimeZoneForQueries.Id, "UTC");
            DateTimeOffset retVal = TimeZoneInfo.ConvertTime(dateTimeLocaled, _gridTariffApiConfig.TimeZoneForQueries);
            return retVal;
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
    }
}
