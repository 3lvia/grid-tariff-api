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
        public Task<Company> GetCompanyAsync();
        public Task<IReadOnlyList<Holiday>> GetHolidaysAsync(DateTimeOffset fromDate, DateTimeOffset toDate);
        public Task<List<MeteringPointInformation>> GetMeteringPointInformationsAsync(DateTimeOffset fromDateTime, DateTimeOffset toDateTime, List<string> meteringPoints);
        public Task<TariffType> GetTariffAsync(string tariffKey);
        public Task<TariffPriceStructureRoot> GetTariffRootElementAsync();
        public Task<IReadOnlyList<TariffType>> GetTariffsAsync();
    }
}
