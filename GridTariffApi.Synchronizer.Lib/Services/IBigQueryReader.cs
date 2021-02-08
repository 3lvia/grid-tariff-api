using GridTariffApi.Synchronizer.Lib.Model.BigQueryMeteringPoint;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridTariffApi.Synchronizer.Lib.Services
{
    public interface IBigQueryReader
    {
        Task<List<BqMeteringPointProduct>> GetAllMeteringPointProductAsync();
        Task<List<BqMeteringPointProduct>> GetMeteringPointsByFromDateAsync(DateTime fromDate);
    }
}