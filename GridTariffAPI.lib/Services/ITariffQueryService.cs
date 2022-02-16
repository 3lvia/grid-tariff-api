using GridTariffApi.Lib.Models.Digin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Services
{
    public interface ITariffQueryService
    {
        Task<GridTariffCollection> QueryTariffUsingTariffKeyAsync(
            string tariffKey,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate);

        Task<GridTariffCollection> QueryTariffUsingProductKeyAsync(
            string productKey,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate);

        Task<TariffQueryRequestMeteringPointsResult> QueryMeteringPointsTariffsAsync(
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate,
            List<String> meteringPoints);
    }
}