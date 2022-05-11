using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GridTariffApi.Elvid;
using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Mdmx.Dtos;
using GridTariffApi.Metrics;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace GridTariffApi.Mdmx
{
    public class MdmxClient : IMdmxClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMdmxAccessTokenService _accessTokenService; // Calling MDMx test from prod
        private readonly MdmxConfig _config;
        private readonly IElviaLoggingDataCollector _loggingDataCollector;


        public MdmxClient(IHttpClientFactory httpClientFactory, IMdmxAccessTokenService accessTokenService, MdmxConfig config, IElviaLoggingDataCollector loggingDataCollector)
        {
            _httpClientFactory = httpClientFactory;
            _accessTokenService = accessTokenService;
            _config = config;
            _loggingDataCollector = loggingDataCollector;
        }


        public async Task<List<MeteringPointMaxConsumption>> GetMaxConsumptionsAsync(List<string> meteringPointIds)
        {
            var request = new MaxConsumptionAggregationBatchQuery
            {
                MeteringPointIds = meteringPointIds.ToArray(),
                MeasurementTimeLe = null // null for the current MaxConsumption
            };

            var uriBuilder = new UriBuilder(_config.HostAddress)
            {
                Path = "volumeaggregation/maxConsumption",
            };

            var requestJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var httpClient = await GetHttpClient();
            var res = await _loggingDataCollector.MeasureMdmxElapsedTimeAsync(async () => await httpClient.PostAsync(uriBuilder.Uri, content));

            if (!res.IsSuccessStatusCode)
            {
                var errorContent = await res.Content.ReadAsStringAsync();
                throw new MdmxClientException($"Error when calling MDMx API {uriBuilder.Uri} for {meteringPointIds.Count} mpids: HTTP {(int)res.StatusCode} {res.ReasonPhrase} - {errorContent}", (int)res.StatusCode);
            }

            if (res.Content.Headers.ContentType.MediaType != "application/json")
            {
                var stringContent = await res.Content.ReadAsStringAsync();
                throw new MdmxClientException($"MDMx API {uriBuilder.Uri} for {meteringPointIds.Count} mpids returned {res.Content.Headers.ContentType.MediaType} instead of JSON: HTTP {(int)res.StatusCode} - {stringContent}", (int)res.StatusCode);
            }

            var aggregations = await res.Content.ReadAsAsync<MaxConsumptionAggregationDto[]>();
            return aggregations.Select(agg => new MeteringPointMaxConsumption
                {
                    MeteringPointId = agg.MeteringPointId,
                    MaxConsumption = agg.MaxConsumption,
                    LastVolumeEndTime = agg.LastVolumeEndTime
                })
                .ToList();
        }

        private async Task<HttpClient> GetHttpClient()
        {
            var accessToken = await _accessTokenService.GetAccessToken();
            var httpClient = _httpClientFactory.CreateClient("mdmx");
            httpClient.SetBearerToken(accessToken);
            httpClient.Timeout = TimeSpan.FromMinutes(10);
            return httpClient;
        }
    }

    [Serializable]
    public class MdmxClientException : Exception
    {
        public int HttpStatusCode { get; set; }

        public MdmxClientException()
        {
        }

        public MdmxClientException(string message, int httpStatusCode)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }

        public MdmxClientException(string message, Exception inner, int httpStatusCode)
            : base(message, inner)
        {
            HttpStatusCode = httpStatusCode;
        }

        protected MdmxClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}