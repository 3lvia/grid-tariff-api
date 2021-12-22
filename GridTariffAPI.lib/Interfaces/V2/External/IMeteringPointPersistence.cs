﻿using GridTariffApi.Lib.Models.V2.Internal;
using System.Collections.Generic;

namespace GridTariffApi.Lib.Interfaces.V2.External
{
    public interface IMeteringPointPersistence
    {
        public IReadOnlyList<MeteringPointInformation> GetMeteringPointsInformation();
    }
}
