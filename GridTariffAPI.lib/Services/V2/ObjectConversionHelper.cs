using System;
using System.Collections.Generic;
using System.Text;

namespace GridTariffApi.Lib.Services.V2
{
    public interface IObjectConversionHelper
    {
        Models.V2.Digin.FixedPriceConfiguration ToFixedPriceConfiguration(Models.V2.PriceStructure.FixedPriceConfiguration priceConfiguration);
        Models.V2.Digin.PowerPriceConfiguration ToPowerPriceConfiguration(Models.V2.PriceStructure.PowerPriceConfiguration priceConfiguration);

        public Models.V2.Digin.TariffType ToTariffType(
            Models.V2.PriceStructure.Company company,
            Models.V2.PriceStructure.TariffType tariffType);

    }

    public class ObjectConversionHelper : IObjectConversionHelper
    {
        public ObjectConversionHelper()
        {

        }

        public Models.V2.Digin.TariffType ToTariffType(
            Models.V2.PriceStructure.Company company,
            Models.V2.PriceStructure.TariffType tariffType)
        {
            var retVal = new Models.V2.Digin.TariffType();
            retVal.TariffKey = tariffType.TariffKey;
            retVal.Product = tariffType.Product;
            retVal.CompanyName = company.CompanyName;
            retVal.CompanyOrgNo = company.CompanyOrgNo;
            retVal.Title = tariffType.Title;
            retVal.ConsumptionFlag = tariffType.ConsumptionFlag;
            retVal.LastUpdated = tariffType.LastUpdated;
            retVal.UsePublicHolidayPrices = !String.IsNullOrEmpty(tariffType.UsePublicHolidayOverride);
            retVal.UseWeekendPrices = !string.IsNullOrEmpty(tariffType.UseWeekendPriceOverride);
            retVal.FixedPriceConfiguration = ToFixedPriceConfiguration(tariffType.FixedPriceConfiguration);
            retVal.PowerPriceConfiguration = ToPowerPriceConfiguration(tariffType.PowerPriceConfiguration);
            retVal.Resolution = tariffType.Resolution;
            retVal.Description = tariffType.Description;
            return retVal;
        }

        public Models.V2.Digin.PowerPriceConfiguration ToPowerPriceConfiguration(Models.V2.PriceStructure.PowerPriceConfiguration priceConfiguration)
        {
            Models.V2.Digin.PowerPriceConfiguration retVal = null;
            if (priceConfiguration != null)
            {
                return new Models.V2.Digin.PowerPriceConfiguration()
                {
                    PowerFactorPercentage = (int)(priceConfiguration.PowerFactorPercentage + 0.5),  //todo should be double in digin according to are
                    ReactivePowerPricing = priceConfiguration.ReactivePowerPricing
                };
            }
            return retVal;
        }
        public Models.V2.Digin.FixedPriceConfiguration ToFixedPriceConfiguration(Models.V2.PriceStructure.FixedPriceConfiguration priceConfiguration)
        {
            Models.V2.Digin.FixedPriceConfiguration retVal = null;
            if (priceConfiguration != null)
            {
                retVal = new Models.V2.Digin.FixedPriceConfiguration();
                retVal.Basis = priceConfiguration.Basis;
                if (priceConfiguration.MaxhoursPerDay.HasValue)
                {
                    retVal.MaxhoursPerDay = priceConfiguration.MaxhoursPerDay.Value;
                }
                if (priceConfiguration.DaysPerMonth.HasValue)
                {
                    retVal.DaysPerMonth = priceConfiguration.DaysPerMonth.Value;
                }
                if (priceConfiguration.AllDaysPerMonth.HasValue)
                {
                    retVal.AllDaysPerMonth = priceConfiguration.AllDaysPerMonth.Value;
                }
                if (priceConfiguration.MaxhoursPerMonth.HasValue)
                {
                    retVal.MaxhoursPerMonth = priceConfiguration.MaxhoursPerMonth.Value;
                }
                if (priceConfiguration.Months.HasValue)
                {
                    retVal.Months = priceConfiguration.Months.Value;
                }
            }
            return retVal;
        }
    }
}
