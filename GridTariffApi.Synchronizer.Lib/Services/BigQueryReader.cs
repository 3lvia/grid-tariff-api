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
        private readonly BigQueryClient _bigQueryClient;

        private readonly string _meteringPointProductQueryAll = "select meteringpointid, netproduct, source from `grid.v_amisite_latest` where netProduct is not null";
        private readonly string _meteringPointProductQueryIncremental = "select meteringpointid, netproduct, source from `grid.v_amisite_latest` where _updatedTimestamp > @updatedTimeStamp";

        public BigQueryReader(BigQueryClient bigQueryClient)
        {
            _bigQueryClient = bigQueryClient;
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
                meteringPointProducts.Add(BigQueryRowToBqMeteringPointProduct(row));
            }
            return meteringPointProducts;
        }

        private BqMeteringPointProduct BigQueryRowToBqMeteringPointProduct(BigQueryRow row)
        {
            var result = new BqMeteringPointProduct() { MeteringPointId = String.Empty, Product = String.Empty, Area = -1 } ;
            if (row["meteringpointid"] != null)
            {
                result.MeteringPointId = row["meteringpointid"].ToString();
            }
            if (row["netproduct"] != null)
            {
                result.Product = row["netproduct"].ToString();
            }
            if (row["source"] != null)
            {
                result.Area = Convert.ToInt32(row["source"]);
            }
            return result;
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
