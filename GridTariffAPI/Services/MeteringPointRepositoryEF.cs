using GridTariffApi.Lib.EntityFramework;
using GridTariffApi.Lib.Interfaces.External;
using GridTariffApi.Lib.Models.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GridTariffApi.Services
{
    public class MeteringPointRepositoryEF : IMeteringPointRepository
    {
        private readonly TariffContext _tariffContext;

        public MeteringPointRepositoryEF(TariffContext tariffContext)
        {
            _tariffContext = tariffContext;
        }

        public IReadOnlyList<MeteringPointInformation> GetMeteringPointsInformation(List<String> meteringPointIds)
        {
            var retVal = new List<MeteringPointInformation>();
            var meteringPointProducts = _tariffContext.MeteringPointProducts.Where(x => meteringPointIds.Contains(x.MeteringpointId));

            foreach (var meteringPointProduct in meteringPointProducts)
            {
                retVal.Add(new MeteringPointInformation(meteringPointProduct.MeteringpointId, meteringPointProduct.TariffKey, 0,meteringPointProduct.LastUpdatedDate));
            }
            return retVal;
        }
    }
}
