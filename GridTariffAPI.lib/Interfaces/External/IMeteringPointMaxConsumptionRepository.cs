using System;
using GridTariffApi.Lib.Models.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Interfaces.External
{
    public interface IMeteringPointMaxConsumptionRepository
    {
        public Task<List<MeteringPointMaxConsumption>> GetMeteringPointMaxConsumptionsAsync(DateTimeOffset fromDateTime, DateTimeOffset toDateTime, List<string> meteringPointIds);
    }
}
