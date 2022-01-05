using GridTariffApi.Lib.Models.TariffQuery;
using System;
using System.Collections.Generic;

namespace GridTariffApi.Lib.Services.Pilot
{
    public interface ITariffQueryService
    {
        TariffQueryResult QueryTariff(string tariffKey, DateTime paramFromDate, DateTime paramToDate);

        TariffQueryRequestMeteringPointsResult QueryTariff(List<string> meteringPoints, DateTime startDateTime, DateTime endDateTime);
    }
}