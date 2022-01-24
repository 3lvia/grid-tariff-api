using System.Net.Http;
using Microsoft.Extensions.Caching.Memory;

namespace GridTariffApi.Elvid
{
    /// <summary>
    /// Special access token service for the MDMx api (grid-tariff-api prod calls MDMx api in test)
    /// </summary>
    public class MdmxAccessTokenService : AccessTokenService, IMdmxAccessTokenService
    {
        protected override string AccessTokenMemoryCacheKey => "AccessTokenMemoryCacheKey-Mdmx";

        public MdmxAccessTokenService(MdmxClientCredentialsConfiguration config, IHttpClientFactory httpClientFactory, IMemoryCache memoryCache) : base(config, httpClientFactory, memoryCache)
        {
        }
    }
}