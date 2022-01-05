using GridTariffApi.Lib.Models.V2.Internal;
using System;
using System.Collections.Generic;

namespace GridTariffApi.Lib.Interfaces.V2.External
{
    public interface IMeteringPointRepository
    {
        public IReadOnlyList<MeteringPointInformation> GetMeteringPointsInformation(List<String> meteringPointIds);
    }
}
