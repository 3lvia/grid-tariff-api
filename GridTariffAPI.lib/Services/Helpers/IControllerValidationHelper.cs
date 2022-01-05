using GridTariffApi.Lib.Models.V2.Digin;

namespace GridTariffApi.Lib.Services.Helpers
{
    public interface IControllerValidationHelper
    {
        string DecideTariffKeyFromInput(TariffQueryRequest request);
        string ValidateRequestInput(TariffQueryRequest request);
        public string ValidateRequestInput(TariffQueryRequestMeteringPoints request);
    }
}