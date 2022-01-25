namespace GridTariffApi.Elvid
{
    public class MdmxClientCredentialsConfiguration : ClientCredentialsConfiguration
    {
        /// <summary>
        /// Special client credentials for the MDMx api (grid-tariff-api prod calls MDMx api in test)
        /// </summary>
        public MdmxClientCredentialsConfiguration(string tokenEndpoint, string clientId, string clientSecret) : base(tokenEndpoint, clientId, clientSecret)
        {
        }
    }
}
