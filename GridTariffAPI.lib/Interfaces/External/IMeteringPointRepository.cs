using GridTariffApi.Lib.Models.Internal;
using System;
using System.Collections.Generic;

namespace GridTariffApi.Lib.Interfaces.External
{
    public interface IMeteringPointRepository
    {
        public IReadOnlyList<MeteringPointInformation> GetMeteringPointsInformation(List<String> meteringPointIds);
    }
}
