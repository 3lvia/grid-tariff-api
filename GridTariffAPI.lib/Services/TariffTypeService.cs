﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Services
{
        public class TariffTypeService : ITariffTypeService
    {
        private readonly ITariffPriceCache _tariffPriceCache;
        private readonly IObjectConversionHelper _objectConversionHelper;

        public TariffTypeService(ITariffPriceCache tariffPriceCache,
            IObjectConversionHelper objectConversionHelper)
        {
            _tariffPriceCache = tariffPriceCache;
            _objectConversionHelper = objectConversionHelper;
        }
        public async Task<Models.Digin.TariffTypeContainer> GetTariffTypes()
        {
            var retVal = new Models.Digin.TariffTypeContainer();
            var company = await _tariffPriceCache.GetCompanyAsync();
            retVal.TariffTypes = new List<Models.Digin.TariffType>();
            var tariffTypes = await _tariffPriceCache.GetTariffsAsync();
            foreach (var tariffType in tariffTypes)
            {
                retVal.TariffTypes.Add(_objectConversionHelper.ToTariffType(company,tariffType));
            }
            await Task.CompletedTask;
            return retVal;
        }
    }
}
