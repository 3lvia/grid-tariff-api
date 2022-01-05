using System;

namespace GridTariffApi.Lib.Services
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
            var retVal = new Models.V2.Digin.TariffType
            {
                TariffKey = tariffType.TariffKey,
                Product = tariffType.Product,
                CompanyName = company.CompanyName,
                CompanyOrgNo = company.CompanyOrgNo,
                Title = tariffType.Title,
                ConsumptionFlag = tariffType.ConsumptionFlag,
                LastUpdated = tariffType.LastUpdated,
                UsePublicHolidayPrices = !String.IsNullOrEmpty(tariffType.UsePublicHolidayOverride),
                UseWeekendPrices = !string.IsNullOrEmpty(tariffType.UseWeekendPriceOverride),
                FixedPriceConfiguration = ToFixedPriceConfiguration(tariffType.FixedPriceConfiguration),
                PowerPriceConfiguration = ToPowerPriceConfiguration(tariffType.PowerPriceConfiguration),
                Resolution = tariffType.Resolution,
                Description = tariffType.Description
            };
            return retVal;
        }

        public Models.V2.Digin.PowerPriceConfiguration ToPowerPriceConfiguration(Models.V2.PriceStructure.PowerPriceConfiguration priceConfiguration)
        {
            Models.V2.Digin.PowerPriceConfiguration retVal = null;
            if (priceConfiguration != null)
            {
                return new Models.V2.Digin.PowerPriceConfiguration()
                {
                    PowerFactorPercentage = priceConfiguration.PowerFactorPercentage,
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
                retVal = new Models.V2.Digin.FixedPriceConfiguration
                {
                    Basis = priceConfiguration.Basis
                };
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
