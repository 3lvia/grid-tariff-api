using Google.Cloud.BigQuery.V2;
using GridTariffApi.BigQuery.MeteringPointTariffSync.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridTariffApi.BigQuery.MeteringPointTariffSync
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

        public async Task<List<BigQueryMeteringPointProduct>> GetAllMeteringPointProductAsync()
        {
            var result = await _bigQueryClient.ExecuteQueryAsync(_meteringPointProductQueryAll, parameters: null);
            return ConvertBigQueryResult(result);
        }
        public async Task<List<BigQueryMeteringPointProduct>> GetMeteringPointsByFromDateAsync(DateTimeOffset fromDate)
        {
            var parameters = GetIncrementalParameters(fromDate);
            var result = await _bigQueryClient.ExecuteQueryAsync(_meteringPointProductQueryIncremental, parameters);
            return ConvertBigQueryResult(result);
        }

        private List<BigQueryMeteringPointProduct> ConvertBigQueryResult(BigQueryResults result)
        {
            var meteringPointProducts = new List<BigQueryMeteringPointProduct>();
            foreach (var row in result)
            {
                meteringPointProducts.Add(BigQueryRowToBqMeteringPointProduct(row));
            }
            return meteringPointProducts;
        }

        private BigQueryMeteringPointProduct BigQueryRowToBqMeteringPointProduct(BigQueryRow row)
        {
            var result = new BigQueryMeteringPointProduct() { MeteringPointId = String.Empty, Product = String.Empty/*, Area = -1*/ } ;
            if (row["meteringpointid"] != null)
            {
                result.MeteringPointId = row["meteringpointid"].ToString();
            }
            if (row["netproduct"] != null)
            {
                result.Product = row["netproduct"].ToString();
            }
            return result;
        }

        private static BigQueryParameter[] GetIncrementalParameters(DateTimeOffset timestamp)
        {
            return new BigQueryParameter[]
            {
                new BigQueryParameter("updatedTimeStamp", BigQueryDbType.Int64, timestamp.Ticks)
            };
        }
    }
}
