using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Models.V2.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.Services.V2
{
    //currently used for mocking code. to be replaced with acutal implementation fetching data from actual source
    public class MeteringPointTariffPersistenceDummy : IMeteringPointPersistence
    {
        public MeteringPointTariffPersistenceDummy()
        {

        }

        public IReadOnlyList<MeteringPointInformation> GetMeteringPointsInformation()
        {
            var retVal = new List<MeteringPointInformation>();
            retVal.Add(new MeteringPointInformation("standarda", "standard", 6));
            retVal.Add(new MeteringPointInformation("standardb", "standard", 6.1 ));
            retVal.Add(new MeteringPointInformation("standardc", "standard", 104));
            retVal.Add(new MeteringPointInformation("powera", "power_ls_dn",12));
            retVal.Add(new MeteringPointInformation("powerb", "power_ls_dn",12));
            retVal.Add(new MeteringPointInformation("powerc", "power_ls_dn",42));
            return retVal;
        }
    }
}
