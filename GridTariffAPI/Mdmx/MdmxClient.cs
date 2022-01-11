using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GridTariffApi.Elvid;
using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Mdmx.Dtos;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace GridTariffApi.Mdmx
{
    public class MdmxClient : IMdmxClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAccessTokenService _accessTokenService;
        private readonly MdmxConfig _config;


        public MdmxClient(IHttpClientFactory httpClientFactory, IAccessTokenService accessTokenService, MdmxConfig config)
        {
            _httpClientFactory = httpClientFactory;
            _accessTokenService = accessTokenService;
            _config = config;
        }


        public async Task<List<MeteringPointMaxConsumption>> GetVolumeAggregationsForThisMonthAsync(List<string> meteringPointIds)
        {
            var localNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _config.TimeZoneForMonthLimiting);
            var localMonthStart = new DateTime(localNow.Year, localNow.Month, 1, 0, 0, 0, localNow.Kind);

            var request = new VolumeAggregationBatchQuery
            {
                MeteringPointIds = meteringPointIds.ToArray(),
                Register = "ActivePlus",
                MeasurementTimeGe = localMonthStart,
                MeasurementTimeLe = localNow
            };
           
            var uriBuilder = new UriBuilder(_config.HostAddress)
            {
                Path = "api/volumeaggregation",
            };

            var requestJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var httpClient = await GetHttpClient();            
            var res = await httpClient.PostAsync(uriBuilder.Uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var errorContent = await res.Content.ReadAsStringAsync();
                throw new MdmxClientException($"Error when calling MDMx API {_config.HostAddress} for {meteringPointIds.Count} mpids: HTTP {(int)res.StatusCode} {res.ReasonPhrase} - {errorContent}", (int)res.StatusCode);
            }

            if (res.Content.Headers.ContentType.MediaType != "application/json")
            {
                var stringContent = await res.Content.ReadAsStringAsync();
                throw new MdmxClientException($"MDMx API {_config.HostAddress} for {meteringPointIds.Count} mpids returned {res.Content.Headers.ContentType.MediaType} instead of JSON: HTTP {(int)res.StatusCode} - {stringContent}", (int)res.StatusCode);
            }

            var aggregations = await res.Content.ReadAsAsync<VolumeAggregationDto[]>();
            return aggregations.Select(agg => new MeteringPointMaxConsumption
                {
                    MeteringPointId = agg.MeteringPointId,
                    MaxHourlyEnergyConsumption = agg.Max,
                    LastVolumeEndTime = agg.LastVolumeEndTime
                })
                .ToList();
        }

        private async Task<HttpClient> GetHttpClient()
        {
            var accessToken = await _accessTokenService.GetAccessToken();
            var httpClient = _httpClientFactory.CreateClient("mdmx");
            httpClient.SetBearerToken(accessToken);
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