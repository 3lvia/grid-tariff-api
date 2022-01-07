namespace GridTariffApi.Elvid
{
    public class ClientCredentialsConfiguration
    {
        public ClientCredentialsConfiguration(string tokenEndpoint, string clientId, string clientSecret)
        {
            TokenEndpoint = tokenEndpoint;
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public string TokenEndpoint { get; internal set; }

        public string ClientId { get; internal set; }

        public string ClientSecret { get; internal set; }
    }
}
