using System;

namespace GridTariffApi.Lib.Services.Helpers
{
    public interface IServiceHelper
    {
        DateTime GetEndTime(string range, DateTimeOffset? endDateTime);
        DateTime GetStartTime(string range, DateTimeOffset? startDateTime);
        DateTimeOffset DbTimeZoneDateToUtc(DateTime dateTime);
    }
}