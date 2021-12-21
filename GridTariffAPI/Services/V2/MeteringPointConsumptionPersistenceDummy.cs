using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Models.V2.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.Services.V2
{
    public class MeteringPointConsumptionPersistenceDummy : IMeteringPointConsumptionPersistence
    {
        public IReadOnlyList<MeteringPointMaxConsumption> GetMeteringPointsMaxConsumption()
        {
            var retVal = new List<MeteringPointMaxConsumption>();
            retVal.Add(new MeteringPointMaxConsumption("standarda",1 ));
            retVal.Add(new MeteringPointMaxConsumption("standardb",11));
            retVal.Add(new MeteringPointMaxConsumption("standardc",111 ));
            retVal.Add(new MeteringPointMaxConsumption("powera", 6));
            retVal.Add(new MeteringPointMaxConsumption("powerb", 9));
            retVal.Add(new MeteringPointMaxConsumption("powerc", 30));
            return retVal;
        }
    }
}
