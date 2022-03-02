using GridTariffApi.Lib.Config;
using GridTariffApi.Lib.Models.Digin;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Services.Helpers
{

    public class ControllerValidationHelper : IControllerValidationHelper
    {
        private readonly GridTariffApiConfig _gridTariffApiConfig;
        private readonly ITariffPriceCache _tariffPriceCache;
        private readonly IServiceHelper _serviceHelper;

        public ControllerValidationHelper(
            GridTariffApiConfig gridTariffApiConfig,
            ITariffPriceCache tariffPriceCache,
            IServiceHelper serviceHelper)
        {
            _gridTariffApiConfig = gridTariffApiConfig;
            _tariffPriceCache = tariffPriceCache;
            _serviceHelper = serviceHelper;

        }
        public ControllerValidationHelper()
        {

        }


        public async Task<bool> ValidateTariffExistsAsync(TariffQueryRequest request)
        {
            return await ValidateTariffExistsAsync(request.TariffKey, request.Product);
        }

        public virtual async Task<bool> ValidateTariffExistsAsync(string tariffKey, string productKey)
        {
            var tariffs = await _tariffPriceCache.GetTariffsAsync();
            var foundTariffKey = tariffs.Any(x => x.TariffKey == tariffKey);
            var foundProductKey = tariffs.Any(x => x.Product == productKey);
            return foundTariffKey || foundProductKey;
        }

        public string ValidateRequestInput(TariffQueryRequestMeteringPoints request)
        {
            // Denne valideringen er i tillegg til Validate()-metoden på request-objektet, som kalles automatisk av ASP.NET.

            if (request == null)
            {
                return "Missing model";
            }

            var minStartValidationResult = ValidateMinStartAllowedQuery(request.Range, request.StartTime);
            if (!String.IsNullOrEmpty(minStartValidationResult))
            {
                return minStartValidationResult;
            }

            return String.Empty;
        }

        public string ValidateRequestInput(TariffQueryRequest request)
        {
            // Denne valideringen er i tillegg til Validate()-metoden på request-objektet, som kalles automatisk av ASP.NET.

            if (request == null)
            {
                return "Missing model";
            }

            bool tariffKeyAndProductMissing = String.IsNullOrEmpty(request.TariffKey) && String.IsNullOrEmpty(request.Product);
            bool tariffKeyAndProductBothPresent = !String.IsNullOrEmpty(request.TariffKey) && !String.IsNullOrEmpty(request.Product);
            if (tariffKeyAndProductMissing)
            {
                return "Neither TariffKey nor Product present in request";
            }
            if (tariffKeyAndProductBothPresent)
            {
                return "Both TariffKey and Product present in request. These are mutually exclusive";
            }

            var minStartValidationResult = ValidateMinStartAllowedQuery(request.Range, request.StartTime);
            if (!String.IsNullOrEmpty(minStartValidationResult))
            {
                return minStartValidationResult;
            }
            return String.Empty;
        }

        private string ValidateMinStartAllowedQuery(string range,  DateTimeOffset? startTime)
        {
            var startDateTime = _serviceHelper.GetStartDateTimeOffset(range, startTime);
            if (startDateTime.DateTime < _gridTariffApiConfig.MinStartDateAllowedQuery)
            {
                return $"Query before {_gridTariffApiConfig.MinStartDateAllowedQuery} not supported";
            }

            return String.Empty;
        }

        public async Task<string> DecideTariffKeyFromInputAsync(TariffQueryRequest request)
        {
            if (!String.IsNullOrEmpty(request.TariffKey))
            {
                return request.TariffKey;
            }
            var tariff = (await _tariffPriceCache.GetTariffsAsync()).FirstOrDefault(x => x.Product == request.Product);
            if (tariff != null)
            {
                return tariff.TariffKey;
            }
            return String.Empty;
        }
    }
}
