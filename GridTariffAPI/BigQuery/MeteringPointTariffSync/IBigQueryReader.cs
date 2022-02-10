using GridTariffApi.BigQuery.MeteringPointTariffSync.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridTariffApi.BigQuery.MeteringPointTariffSync
{
    public interface IBigQueryReader
    {
        Task<List<MeteringPointProductBigQuery>> GetAllMeteringPointProductAsync();
        Task<List<MeteringPointProductBigQuery>> GetMeteringPointsByFromDateAsync(DateTimeOffset fromDate);
    }
}