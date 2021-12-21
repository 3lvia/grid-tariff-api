﻿using GridTariffApi.Lib.Models.V2.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Lib.Interfaces.V2.External
{
    public interface IMeteringPointTariffPersistence
    {
        public IReadOnlyList<MeteringPointTariff> GetMeteringPointsTariffs();
    }
}
