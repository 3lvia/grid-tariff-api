using System.Collections.Generic;
using System.Threading.Tasks;
using GridTariffApi.Lib.Models.Internal;

namespace GridTariffApi.Mdmx
{
    public interface IMdmxClient
    {
        Task<List<MeteringPointMaxConsumption>> GetMaxConsumptionsAsync(List<string> meteringPointIds);
    }
}