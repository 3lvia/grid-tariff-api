using GridTariffApi.Lib.Models.Holidays;
using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.PriceStructure;
using System;
using System.Collections.Generic;

namespace GridTariffApi.Lib.Services
{
    public interface ITariffPriceCache
    {
        Company GetCompany();
        IReadOnlyList<Holiday> GetHolidays(DateTimeOffset fromDate, DateTimeOffset toDate);
        List<MeteringPointInformation> GetMeteringPointInformation(List<string> meteringPoints);
        Models.PriceStructure.TariffType GetTariff(string tariffKey);
        TariffPriceStructureRoot GetTariffRootElement();
        IReadOnlyList<Models.PriceStructure.TariffType> GetTariffs();
    }
}