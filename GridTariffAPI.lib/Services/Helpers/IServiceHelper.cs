using System;

namespace GridTariffApi.Lib.Services.Helpers
{
    public interface IServiceHelper
    {
        DateTime GetEndTime(string range, DateTime? endDateTime);
        DateTime GetStartTime(string range, DateTime? startDateTime);
    }
}