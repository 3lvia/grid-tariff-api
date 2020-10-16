using Kunde.TariffApi.Models.TariffQuery;
using System;

namespace Kunde.TariffApi.Services.TariffQuery
{
    public interface ITariffQueryService
    {
        TariffQueryResult QueryTariff(string tariffKey, DateTime paramFromDate, DateTime paramToDate);
    }
}