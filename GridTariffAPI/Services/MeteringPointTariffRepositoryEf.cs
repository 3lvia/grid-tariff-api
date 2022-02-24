using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GridTariffApi.Database;

namespace GridTariffApi.Services
{
    public class MeteringPointTariffRepositoryEf : IMeteringPointTariffRepository
    {
        private readonly ElviaDbContext _elviaDbContext;

        public MeteringPointTariffRepositoryEf(ElviaDbContext elviaDbContext)
        {
            _elviaDbContext = elviaDbContext;
        }

        public async Task<IReadOnlyList<MeteringPointTariff>> GetMeteringPointTariffsAsync(List<string> meteringPointIds)
        {
            return await _elviaDbContext.MeteringPointTariff
                .Where(x => meteringPointIds.Contains(x.MeteringPointId))
                .Select(meteringPointProduct =>
                    new MeteringPointTariff(meteringPointProduct.MeteringPointId, meteringPointProduct.ProductKey))
                .ToListAsync();
        }
    }
}
