using GridTariffApi.Lib.Models.TariffQuery;
using System;

namespace GridTariffApi.Lib.Services.TariffQuery
{
    public interface ITariffQueryService
    {
        TariffQueryResult QueryTariff(string tariffKey, DateTime paramFromDate, DateTime paramToDate);
    }
}