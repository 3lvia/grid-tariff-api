using GridTariffApi.Lib.Models.V2.Digin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridTariffApi.Lib.Services.V2
{
    public interface ITariffQueryService
    {
        GridTariffCollection QueryTariff(string tariffKey, DateTimeOffset paramFromDate, DateTimeOffset paramToDate);
    }

    public class TariffQueryService : ITariffQueryService
    {
        private readonly ITariffPriceCache _tariffPriceCache;
        public TariffQueryService(ITariffPriceCache tariffPriceCache)
        {
            _tariffPriceCache = tariffPriceCache;
        }

        public GridTariffCollection QueryTariff(string tariffKey, DateTimeOffset paramFromDate, DateTimeOffset paramToDate)
        {
            var tariff = _tariffPriceCache.GetTariff(tariffKey, paramFromDate, paramToDate);
            var company = _tariffPriceCache.GetCompany();

            var gridTariffCollection = new GridTariffCollection();
            gridTariffCollection.GridTariff = ToGridTariff(company, tariff);
            gridTariffCollection.GridTariff.TariffPrice = new Models.V2.Digin.TariffPrice();

            tariff.TariffPrices.RemoveAll(x => x.EndDate <= paramFromDate || x.StartDate > paramToDate);
            foreach (var tariffPrice in tariff.TariffPrices.OrderBy(x => x.StartDate))      //order by not strictly necessary
            {
                var startDate = tariffPrice.StartDate <= paramFromDate ? paramFromDate : tariffPrice.StartDate;
                var endDate = tariffPrice.EndDate > paramToDate ? paramToDate : tariffPrice.EndDate;
                gridTariffCollection.GridTariff.TariffPrice.PriceInfo = ProcessTariffPrice(tariffPrice, startDate, endDate);
            }
            return gridTariffCollection;
        }

        public Models.V2.Digin.GridTariff ToGridTariff(Models.V2.PriceStructure.Company company, Models.V2.PriceStructure.TariffType tariffType)
        {
            var retVal = new Models.V2.Digin.GridTariff();
            retVal.TariffType = ToTariffType(company,tariffType);
            return retVal;
        }

        public Models.V2.Digin.TariffType ToTariffType(Models.V2.PriceStructure.Company company, Models.V2.PriceStructure.TariffType tariffType)
        {
            var retVal = new Models.V2.Digin.TariffType();
            retVal.TariffKey = tariffType.TariffKey;
            retVal.Product = tariffType.Product;
            retVal.CompanyName = company.CompanyName;
            retVal.CompanyOrgNo = company.CompanyOrgNo;
            retVal.Title = tariffType.Title;
            retVal.ConsumptionFlag = tariffType.ConsumptionFlag;
            retVal.FixedPriceConfiguration = ToFixedPriceConfiguration(tariffType.FixedPriceConfiguration);
            retVal.Resolution = company.Resolution;
            retVal.Description = tariffType.Description;
            return retVal;
        }

        public Models.V2.Digin.FixedPriceConfiguration ToFixedPriceConfiguration(Models.V2.PriceStructure.FixedPriceConfiguration priceConfiguration)
        {
            var retVal = new Models.V2.Digin.FixedPriceConfiguration();
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
            retVal.MaxhoursPerMonth = priceConfiguration.MaxhoursPerMonth;
            retVal.Months = priceConfiguration.Months;
            return retVal;
        }

        public List<Models.V2.Digin.PriceInfo> ProcessTariffPrice(Models.V2.PriceStructure.TariffPrice tariffPrice, DateTimeOffset paramFromDate, DateTimeOffset paramToDate)
        {
            var retVal = new List<Models.V2.Digin.PriceInfo>();
            var fromDate = paramFromDate;
            while (fromDate < paramToDate)
            {
                var currMonthEndToDate = GetNextMonthEndDate(fromDate, paramToDate);
                retVal.AddRange(ProcessMonth(tariffPrice, fromDate, currMonthEndToDate));
                fromDate = currMonthEndToDate;
            }
            return retVal;
        }


        public List<Models.V2.Digin.PriceInfo> ProcessMonth(GridTariffApi.Lib.Models.V2.PriceStructure.TariffPrice tariffPrice, DateTimeOffset paramFromDate, DateTimeOffset paramToDate)
        {
            var retVal = new List<Models.V2.Digin.PriceInfo>();
            var season = tariffPrice.Seasons.FirstOrDefault(x => x.Months.Contains(paramFromDate.Month));
            var fixedPrices = CalcMonthlyFixePrices(season.FixedPrices, tariffPrice.Taxes.FixedPriceTaxes, paramFromDate.Year, paramFromDate.Month);
            var variableEnergyPrices = CalcVariableEnergyPrice(season.EnergyPrice, tariffPrice.Taxes.EnergyPriceTaxes);

            var fromDate = paramFromDate;
            while (fromDate.Ticks < paramToDate.Ticks)
            {
                var endDate = fromDate.AddDays(1) < paramToDate ? fromDate.AddDays(1) : paramToDate;
                retVal.AddRange(ProcessDay(season, fixedPrices, variableEnergyPrices, fromDate, endDate));
                fromDate = fromDate.AddDays(1);
            }
            return retVal;
        }

        public Models.V2.Digin.FixedPrices CalcMonthlyFixePrices(Models.V2.PriceStructure.FixedPrices fixedPrices, List<Models.V2.PriceStructure.FixedPriceTax> fixedPriceTaxes, int year, int month)
        {
            var retVal = new Models.V2.Digin.FixedPrices() { PriceLevel = new List<Models.V2.Digin.PriceLevel>() };

            const int hoursInDay = 24;          //todo not constant here
            int hoursInMonth = DateTime.DaysInMonth(year, month)* hoursInDay;
            var vat = fixedPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");

            foreach (var priceLevelPrice in fixedPrices.PriceLevel)
            {
                var priceLevel = ToPriceLevel(priceLevelPrice);
                priceLevel.Total = priceLevelPrice.MonthlyTotal / hoursInMonth;
                priceLevel.Taxes = priceLevel.Total * vat.TaxValue / 100;
                priceLevel.FixedExTaxes = priceLevel.Total - priceLevel.Taxes;
                retVal.PriceLevel.Add(priceLevel);
            }
            return retVal;
        }

        public Models.V2.Digin.PriceLevel ToPriceLevel(Models.V2.PriceStructure.PriceLevel inputPriceLevel)
        {
            var retVal = new Models.V2.Digin.PriceLevel();

            retVal.LevelId = inputPriceLevel.LevelId;
            retVal.LevelValueMin = inputPriceLevel.LevelValueMin;

            if (inputPriceLevel.LevelValueMax.HasValue)
            {
                retVal.LevelValueMax = inputPriceLevel.LevelValueMax.Value;
            }
            if (inputPriceLevel.NextLevelIdDown.HasValue)
            {
                retVal.NextLevelIdDown = inputPriceLevel.NextLevelIdDown.Value;
            }
            if (inputPriceLevel.NextLevelIdUp.HasValue)
            {
                retVal.NextLevelIdUp = inputPriceLevel.NextLevelIdUp.Value;
            }
            retVal.LevelValueUnitOfMeasure = inputPriceLevel.LevelValueUnitOfMeasure;
            retVal.MonthlyTotal = inputPriceLevel.MonthlyTotal;
//            retVal.MonthlyTotalUnitOfMeasure = inputPriceLevel.MonthlyTotalUnitOfMeasure;     //todo
            retVal.LevelInfo = inputPriceLevel.LevelInfo;
            retVal.Currency = inputPriceLevel.Currency;
            retVal.MonetaryUnitOfMeasure = inputPriceLevel.MonetaryUnitOfMeasure;

            return retVal;
        }

        public List<Models.V2.Digin.PriceInfo> ProcessDay(Models.V2.PriceStructure.Season season, Models.V2.Digin.FixedPrices fixedPrices, Models.V2.Digin.EnergyPrice[] energyPrices, DateTimeOffset paramFromDate, DateTimeOffset paramToDate)
        {
            var retVal = new List<Models.V2.Digin.PriceInfo>();
            var fromDate = paramFromDate;
            while (fromDate < paramToDate)
            {
                var priceInfo = new Models.V2.Digin.PriceInfo();
                priceInfo.StartTime = fromDate;
                priceInfo.ExpiredAt = fromDate.AddHours(1);
                priceInfo.HoursShortName = $"{priceInfo.StartTime.Hour.ToString().PadLeft(2, '0')}-{(priceInfo.ExpiredAt.Hour).ToString().PadLeft(2, '0')}";
                priceInfo.Season = season.Name;
//                priceInfo.PublicHoliday       todo
                priceInfo.FixedPrices = new List<Models.V2.Digin.FixedPrices>();
                priceInfo.FixedPrices.Add(fixedPrices);
                priceInfo.VariablePrices = new Models.V2.Digin.VariablePrices();
                priceInfo.VariablePrices.EnergyPrice = energyPrices[fromDate.Hour];
                retVal.Add(priceInfo);
                fromDate = fromDate.AddHours(1);
            }
            return retVal;
        }

        public Models.V2.Digin.EnergyPrice[] CalcVariableEnergyPrice (Models.V2.PriceStructure.EnergyPrice priceStructureEnergyPrice, List<Models.V2.PriceStructure.EnergyPriceTax> energyPriceTaxes)
        {
            Models.V2.Digin.EnergyPrice[] retval = new Models.V2.Digin.EnergyPrice[24];
            foreach (var priceLevel in priceStructureEnergyPrice.PriceLevel)
            {
                var energyPrice = new Models.V2.Digin.EnergyPrice();
                energyPrice.Level = priceLevel.Level;
                energyPrice.Currency = priceLevel.Currency;
                energyPrice.MonetaryUnitOfMeasure = priceLevel.MonetaryUnitOfMeasure;

                energyPrice.Total = priceLevel.Total;
                energyPrice.EnergyExTaxes = CalcVariablePriceEnergyExTaxes(
                    priceLevel.Total,
                    energyPriceTaxes.FirstOrDefault(x => x.TaxType == "consumptionTax").TaxValue,
                    energyPriceTaxes.FirstOrDefault(x => x.TaxType == "enovaTax").TaxValue,
                    energyPriceTaxes.FirstOrDefault(x => x.TaxType == "vat").TaxValue);
                energyPrice.Taxes = energyPrice.Total - energyPrice.EnergyExTaxes;
                foreach (var hour in priceLevel.Hours)
                {
                    retval[hour] = energyPrice;
                }
            }
            return retval;
        }

        public double CalcVariablePriceEnergyExTaxes(double total, double consumptionTax, double enovaTax, double vat )
        {
            double retVal = (total * 100) / (100 + vat);
            retVal = retVal - consumptionTax;
            retVal = retVal - enovaTax;
            return retVal;

        }

        public DateTimeOffset GetNextMonthEndDate(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            var monthEndDate = fromDate.AddMonths(1);
            monthEndDate = new DateTimeOffset(monthEndDate.Year, monthEndDate.Month, 1, 0, 0, 0, monthEndDate.Offset);

            if (monthEndDate < toDate)
            {
                return monthEndDate;
            }
            return toDate;
        }
    }
}
