using System;

namespace GridTariffApi.Lib.Services
{
    public interface IObjectConversionHelper
    {
        Models.Digin.FixedPriceConfiguration ToFixedPriceConfiguration(Models.PriceStructure.FixedPriceConfiguration priceConfiguration);
        Models.Digin.PowerPriceConfiguration ToPowerPriceConfiguration(Models.PriceStructure.PowerPriceConfiguration priceConfiguration);

        public Models.Digin.TariffType ToTariffType(
            Models.PriceStructure.Company company,
            Models.PriceStructure.TariffType tariffType);

    }

    public class ObjectConversionHelper : IObjectConversionHelper
    {
        public ObjectConversionHelper()
        {

        }

        public Models.Digin.TariffType ToTariffType(
            Models.PriceStructure.Company company,
            Models.PriceStructure.TariffType tariffType)
        {
            var retVal = new Models.Digin.TariffType
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

        public Models.Digin.PowerPriceConfiguration ToPowerPriceConfiguration(Models.PriceStructure.PowerPriceConfiguration priceConfiguration)
        {
            Models.Digin.PowerPriceConfiguration retVal = null;
            if (priceConfiguration != null)
            {
                return new Models.Digin.PowerPriceConfiguration()
                {
                    PowerFactorPercentage = priceConfiguration.PowerFactorPercentage,
                    ReactivePowerPricing = priceConfiguration.ReactivePowerPricing
                };
            }
            return retVal;
        }
        public Models.Digin.FixedPriceConfiguration ToFixedPriceConfiguration(Models.PriceStructure.FixedPriceConfiguration priceConfiguration)
        {
            Models.Digin.FixedPriceConfiguration retVal = null;
            if (priceConfiguration != null)
            {
                retVal = new Models.Digin.FixedPriceConfiguration
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
