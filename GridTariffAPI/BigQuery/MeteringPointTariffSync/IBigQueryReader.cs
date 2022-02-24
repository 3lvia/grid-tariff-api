using GridTariffApi.BigQuery.MeteringPointTariffSync.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridTariffApi.BigQuery.MeteringPointTariffSync
{
    public interface IBigQueryReader
    {
        Task<List<BigQueryMeteringPointProduct>> GetAllMeteringPointProductAsync();
        Task<List<BigQueryMeteringPointProduct>> GetMeteringPointsByFromDateAsync(DateTimeOffset fromDate);
    }
}