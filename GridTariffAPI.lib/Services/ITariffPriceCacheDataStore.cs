﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Holidays;
using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.PriceStructure;

namespace GridTariffApi.Lib.Services
{
    /// <summary>
    /// Internal data store for the ITariffPriceCache
    /// </summary>
    public interface ITariffPriceCacheDataStore
    {
        Task<List<MeteringPointTariff>> GetMeteringPointTariffsAsync(List<string> meteringPoints, Func<List<string>, Task<IReadOnlyList<MeteringPointTariff>>> retrieveUncachedMeteringPointTariffsFunc);
        IReadOnlyList<Holiday> GetHolidayRoot();
        TariffPriceStructureRoot GetTariffRootElement();
        Task ResetCacheIfNecessaryAsync(ITariffRepository tariffRepository, IHolidayRepository holidayRepository);
    }
}
