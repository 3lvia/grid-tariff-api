using GridTariffApi.Lib.Models.V2.Holidays;
using GridTariffApi.Lib.Models.V2.Internal;
using GridTariffApi.Lib.Models.V2.PriceStructure;
using System;
using System.Collections.Generic;

namespace GridTariffApi.Lib.Services
{
    public interface ITariffPriceCache
    {
        Company GetCompany();
        IReadOnlyList<Holiday> GetHolidays(DateTimeOffset fromDate, DateTimeOffset toDate);
        List<MeteringPointInformation> GetMeteringPointInformation(List<string> meteringPoints);
        Models.V2.PriceStructure.TariffType GetTariff(string tariffKey);
        TariffPriceStructureRoot GetTariffRootElement();
        IReadOnlyList<Models.V2.PriceStructure.TariffType> GetTariffs();
    }
}