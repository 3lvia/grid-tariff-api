﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Services
{
    public interface ITariffTypeService
    {
        Task<Models.Digin.TariffTypeContainer> GetTariffTypes();
    }

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
            var company = _tariffPriceCache.GetCompany();
            retVal.TariffTypes = new List<Models.Digin.TariffType>();
            var tariffTypes = _tariffPriceCache.GetTariffs();
            foreach (var tariffType in tariffTypes)
            {
                retVal.TariffTypes.Add(_objectConversionHelper.ToTariffType(company,tariffType));
            }
            await Task.CompletedTask;
            return retVal;
        }
    }
}