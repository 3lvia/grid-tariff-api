using GridTariffApi.Lib.Models.Internal;
using System;
using System.Collections.Generic;

namespace GridTariffApi.Lib.Services.Helpers
{
    public interface IServiceHelper
    {
        DateTime GetEndTime(string range, DateTimeOffset? endDateTime);
        DateTime GetStartTime(string range, DateTimeOffset? startDateTime);
        DateTimeOffset GetEndDateTimeOffset(string range, DateTimeOffset? endDateTime);
        DateTimeOffset GetStartDateTimeOffset(string range, DateTimeOffset? startDateTime);
        DateTimeOffset DbTimeZoneDateToUtc(DateTime dateTime);
        DateTime GetTimeZonedDateTime(DateTime datetime);
        DateTimeOffset ToConfiguredTimeZone(DateTimeOffset dateTimeOffset);
        bool TimePeriodIsIncludingLocaleToday(DateTimeOffset fromDateTime, DateTimeOffset toDateTime);
        DateTimeOffset CreateLocaledDateTimeOffset(int year, int month, int day, int hour, int minute, int second);
        List<TimePeriod> GetMonthPeriods(DateTimeOffset fromDate, DateTimeOffset toDate, IReadOnlyList<int> months);
        DateTimeOffset GetStartOfNextMonth(DateTimeOffset fromDateLocaled);
        public DateTimeOffset DecideEndOfDay(DateTimeOffset paramToDate, DateTimeOffset currentDateTime);
    }
}