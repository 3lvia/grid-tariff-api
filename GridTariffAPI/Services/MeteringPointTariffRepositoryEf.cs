using GridTariffApi.Lib.EntityFramework;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GridTariffApi.Services
{
    public class MeteringPointTariffRepositoryEf : IMeteringPointTariffRepository
    {
        private readonly TariffContext _tariffContext;

        public MeteringPointTariffRepositoryEf(TariffContext tariffContext)
        {
            _tariffContext = tariffContext;
        }

        public async Task<IReadOnlyList<MeteringPointTariff>> GetMeteringPointTariffsAsync(List<string> meteringPointIds)
        {
            var retVal = new List<MeteringPointTariff>();
            return await _tariffContext.MeteringPointProducts
                .Where(x => meteringPointIds.Contains(x.MeteringpointId))
                .Select(meteringPointProduct =>
                    new MeteringPointTariff(meteringPointProduct.MeteringpointId, meteringPointProduct.TariffKey))
                .ToListAsync();
        }
    }
}
