using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.V2.Digin;
using GridTariffApi.Lib.Models.V2.Holidays;
using GridTariffApi.Lib.Models.V2.Internal;
using GridTariffApi.Lib.Models.V2.PriceStructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Services.V2
{
    public interface ITariffQueryService
    {
        Task<GridTariffCollection> QueryTariffAsync(
            string tariffKey,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate);

        Task<TariffQueryRequestMeteringPointsResult> QueryMeteringPointsTariffsAsync(
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate,
            List<String> meteringPoints);
    }
}