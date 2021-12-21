using GridTariffApi.Lib.Interfaces.V2.External;
using GridTariffApi.Lib.Models.V2.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.Services.V2
{
    //currently used for mocking code. to be replaced with acutal implementation fetching data from actual source
    public class MeteringPointTariffPersistenceDummy : IMeteringPointTariffPersistence
    {
        public MeteringPointTariffPersistenceDummy()
        {

        }

        public IReadOnlyList<MeteringPointTariff> GetMeteringPointsTariffs()
        {
            var retVal = new List<MeteringPointTariff>();
            retVal.Add(new MeteringPointTariff("standarda", "standard"));
            retVal.Add(new MeteringPointTariff("standardb", "standard"));
            retVal.Add(new MeteringPointTariff("standardc", "standard"));
            retVal.Add(new MeteringPointTariff("powera", "power_ls_dn"));
            retVal.Add(new MeteringPointTariff("powerb", "power_ls_dn"));
            retVal.Add(new MeteringPointTariff("powerc", "power_ls_dn"));
            return retVal;
        }
    }
}
