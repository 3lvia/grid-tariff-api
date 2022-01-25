using System.Threading.Tasks;
using GridTariffApi.Lib.Models.Digin;

namespace GridTariffApi.Lib.Services.Helpers
{
    public interface IControllerValidationHelper
    {
        Task<string> DecideTariffKeyFromInputAsync(TariffQueryRequest request);
        Task<string> ValidateRequestInputAsync(TariffQueryRequest request);
        public string ValidateRequestInput(TariffQueryRequestMeteringPoints request);
    }
}