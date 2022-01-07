using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.Extensions.Caching.Memory;

namespace GridTariffApi.Elvid
{
    public class AccessTokenService : IAccessTokenService
    {
        private readonly ClientCredentialsConfiguration _config;
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpClientFactory _httpClientFactory;

        private const string AccessTokenMemoryCacheKey = "AccessTokenMemoryCacheKey";

        public AccessTokenService(ClientCredentialsConfiguration config, IHttpClientFactory httpClientFactory, IMemoryCache memoryCache)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
            _memoryCache = memoryCache;
        }

        public async Task<string> GetAccessToken()
        {
            if (_memoryCache.TryGetValue(AccessTokenMemoryCacheKey, out string cachedAccessToken))
            {
                return cachedAccessToken;
            }
            
            var client = _httpClientFactory.CreateClient(); // Andre måter å få tak i en HttpClient er selvfølgelig også mulig å benytte
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = _config.TokenEndpoint,
                ClientId = _config.ClientId,
                ClientSecret = _config.ClientSecret
            });

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }

            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(tokenResponse.ExpiresIn));
            _memoryCache.Set(AccessTokenMemoryCacheKey, tokenResponse.AccessToken, cacheEntryOptions);

            return tokenResponse.AccessToken;
        }
    }
}