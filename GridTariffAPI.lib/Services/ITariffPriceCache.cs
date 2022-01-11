using GridTariffApi.Lib.Models.Holidays;
using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.PriceStructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Services
{
    public interface ITariffPriceCache
    {
        public Company GetCompany();
        public IReadOnlyList<Holiday> GetHolidays(DateTimeOffset fromDate, DateTimeOffset toDate);
        public Task<List<MeteringPointInformation>> GetMeteringPointInformationAsync(List<string> meteringPoints);
        Models.PriceStructure.TariffType GetTariff(string tariffKey);
        public TariffPriceStructureRoot GetTariffRootElement();
        public IReadOnlyList<Models.PriceStructure.TariffType> GetTariffs();
    }
}