using System.Threading.Tasks;

namespace GridTariffApi.Elvid
{
    public interface IAccessTokenService
    {
        Task<string> GetAccessToken();
    }
}