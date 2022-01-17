using System;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridTariffApi.Mdmx;

namespace GridTariffApi.Services
{
    public class MeteringPointMaxConsumptionMdmxRepository : IMeteringPointMaxConsumptionRepository
    {
        private readonly IMdmxClient _mdmxClient;

        public MeteringPointMaxConsumptionMdmxRepository(IMdmxClient mdmxClient)
        {
            _mdmxClient = mdmxClient;
        }

        public async Task<IReadOnlyList<MeteringPointMaxConsumption>> GetMeteringPointMaxConsumptionsAsync(DateTimeOffset fromDateTime, DateTimeOffset toDateTime, List<string> meteringPointIds)
        {
            // We'll fetch the max consumption from the MDMx api directly (but TariffPriceCache will cache for a while)
            var mdmxRes = await _mdmxClient.GetVolumeAggregationsForThisMonthAsync(meteringPointIds);
            return mdmxRes.AsReadOnly();
        }
    }
}