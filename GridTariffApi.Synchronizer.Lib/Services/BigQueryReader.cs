using Elvia.Telemetry;
using Google.Cloud.BigQuery.V2;
using GridTariffApi.Synchronizer.Lib.Model.BigQueryMeteringPoint;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridTariffApi.Synchronizer.Lib.Services
{
    public class BigQueryReader : IBigQueryReader
    {
        private readonly ITelemetryInsightsLogger _logger;
        private readonly BigQueryClient _bigQueryClient;

        private readonly string _meteringPointProductQueryAll = "select meteringpointid, netproduct, source from `grid.v_amisite_latest` where netProduct is not null";
        private readonly string _meteringPointProductQueryIncremental = "select meteringpointid, netproduct, source from `grid.v_amisite_latest` where _updatedTimestamp > @updatedTimeStamp";

        public BigQueryReader(ITelemetryInsightsLogger logger, BigQueryClient bigQueryClient)
        {
            _bigQueryClient = bigQueryClient;
            _logger = logger;
        }

        public async Task<List<BqMeteringPointProduct>> GetAllMeteringPointProductAsync()
        {
            var result = await _bigQueryClient.ExecuteQueryAsync(_meteringPointProductQueryAll, parameters: null);
            return ConvertBigQueryResult(result);
        }
        public async Task<List<BqMeteringPointProduct>> GetMeteringPointsByFromDateAsync(DateTime fromDate)
        {
            var parameters = GetIncrementalParameters(fromDate);
            var result = await _bigQueryClient.ExecuteQueryAsync(_meteringPointProductQueryIncremental, parameters);
            return ConvertBigQueryResult(result);
        }

        private List<BqMeteringPointProduct> ConvertBigQueryResult(BigQueryResults result)
        {
            var meteringPointProducts = new List<BqMeteringPointProduct>();
            foreach (var row in result)
            {
                meteringPointProducts.Add(new BqMeteringPointProduct()
                {
                    MeteringPointId = row["meteringpointid"].ToString(),
                    Product = row["netproduct"].ToString(),
                    Area = Convert.ToInt32(row["source"])
                });
            }
            return meteringPointProducts;
        }

        private static BigQueryParameter[] GetIncrementalParameters(DateTime timestamp)
        {
            return new BigQueryParameter[]
            {
                new BigQueryParameter("updatedTimeStamp", BigQueryDbType.Int64, timestamp.Ticks)
            };
        }
    }
}
