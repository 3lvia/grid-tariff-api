using GridTariffApi.Lib.Models.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Interfaces.External
{
    public interface IMeteringPointTariffRepository
    {
        public Task<IReadOnlyList<MeteringPointTariff>> GetMeteringPointTariffsAsync(List<string> meteringPointIds);
    }
}
