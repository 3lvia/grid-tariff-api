using GridTariffApi.Lib.Models.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Interfaces.External
{
    public interface IMeteringPointMaxConsumptionRepository
    {
        public Task<IReadOnlyList<MeteringPointMaxConsumption>> GetMeteringPointMaxConsumptionsAsync(List<string> meteringPointIds);
    }
}
