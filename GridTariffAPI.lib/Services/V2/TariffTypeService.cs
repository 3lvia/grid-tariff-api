using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Services.V2
{
    public interface ITariffTypeService
    {
        Task<Models.V2.Digin.TariffTypeContainer> GetTariffTypes();
    }

    public class TariffTypeService : ITariffTypeService
    {
        private readonly ITariffPriceCache _tariffPriceCache;
        public TariffTypeService(ITariffPriceCache tariffPriceCache)
        {
            _tariffPriceCache = tariffPriceCache;
        }
        public async Task<Models.V2.Digin.TariffTypeContainer> GetTariffTypes()
        {
            var retVal = new Models.V2.Digin.TariffTypeContainer();
            retVal.TariffTypes = new List<Models.V2.Digin.TariffType>();
            var tariffTypes = _tariffPriceCache.GetTariffs();
            foreach (var tariffType in tariffTypes)
            {
                retVal.TariffTypes.Add(ToTariffType(tariffType));
            }
            await Task.CompletedTask;
            return retVal;
        }

        public Models.V2.Digin.TariffType ToTariffType(Models.V2.PriceStructure.TariffType tariffType)
        {
            var retVal = new Models.V2.Digin.TariffType();
            //todo full mapping
            return retVal;
        }

    }
}
