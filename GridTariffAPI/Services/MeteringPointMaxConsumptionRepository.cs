using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;
using GridTariffApi.Mdmx;

namespace GridTariffApi.Services
{
    public class MeteringPointMaxConsumptionRepository : IMeteringPointMaxConsumptionRepository
    {
        private readonly IMdmxClient _mdmxClient;

        public MeteringPointMaxConsumptionRepository(IMdmxClient mdmxClient)
        {
            _mdmxClient = mdmxClient;
        }

        public async Task<IReadOnlyList<MeteringPointMaxConsumption>> GetMeteringPointMaxConsumptionsAsync(List<string> meteringPointIds)
        {
            // We'll fetch the max consumption from the MDMx api directly (but TariffPriceCache will cache for a while)
            var mdmxRes = await _mdmxClient.GetVolumeAggregationsForThisMonthAsync(meteringPointIds);
            return mdmxRes.AsReadOnly();
        }
    }
}