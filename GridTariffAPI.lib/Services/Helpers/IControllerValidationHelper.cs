using System.Threading.Tasks;
using GridTariffApi.Lib.Models.Digin;

namespace GridTariffApi.Lib.Services.Helpers
{
    public interface IControllerValidationHelper
    {
        public Task<string> DecideTariffKeyFromInputAsync(TariffQueryRequest request);
        public string ValidateRequestInput(TariffQueryRequestMeteringPoints request);
        public string ValidateRequestInput(TariffQueryRequest request);
        public Task<bool> ValidateTariffExistsAsync(TariffQueryRequest request);

    }
}
