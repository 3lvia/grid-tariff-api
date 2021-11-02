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
            var gridTariffCollection = new GridTariffCollection();
            var tariff = _tariffPriceCache.GetTariff(tariffKey, paramFromDate, paramToDate);

            var fromDate = paramFromDate;
            while (fromDate < paramToDate)
            {
                var currMonthEndToDate = GetNextMonthEndDate(fromDate, paramToDate);
                var currMonthTariffPrice = tariff.TariffPrices.FirstOrDefault(x => x.StartDate <= fromDate && x.EndDate <= currMonthEndToDate);
                if (currMonthTariffPrice != null)
                {
                    ProcessMonth(currMonthTariffPrice, fromDate, currMonthEndToDate);
                }
                fromDate = currMonthEndToDate;
            }

            return gridTariffCollection;
        }

        public void ProcessMonth(GridTariffApi.Lib.Models.V2.PriceStructure.TariffPrice tariffPrice, DateTimeOffset paramFromDate, DateTimeOffset paramToDate)
        {
            var season = tariffPrice.Seasons.FirstOrDefault(x => x.Months.Contains(paramFromDate.Month));
            var fixedPrices = CalcMonthlyFixePrices(season.FixedPrices, tariffPrice.Taxes.FixedPriceTaxes, paramFromDate.Year, paramFromDate.Month);
            var variableEnergyPrices = CalcVariableEnergyPrice(season.EnergyPrice, tariffPrice.Taxes.EnergyPriceTaxes);

            var fromDate = paramToDate;
            while (fromDate.Ticks < paramToDate.Ticks)
            {
                var endDate = fromDate.AddDays(1) < paramToDate ? fromDate.AddDays(1) : paramToDate;
                ProcessDay(season, fixedPrices, variableEnergyPrices, fromDate, fromDate);
                fromDate = fromDate.AddDays(1);
            }
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
//            retVal.LevelValueMax = inputPriceLevel.LevelValueMax;
//            retVal.NextLevelIdDown = inputPriceLevel.NextLevelIdDown;
//            retVal.NextLevelIdUp = inputPriceLevel.NextLevelIdUp;
            retVal.LevelValueUnitOfMeasure = inputPriceLevel.LevelValueUnitOfMeasure;
            retVal.MonthlyTotal = inputPriceLevel.MonthlyTotal;
//            retVal.MonthlyTotalUnitOfMeasure = inputPriceLevel.MonthlyTotalUnitOfMeasure;
            retVal.LevelInfo = inputPriceLevel.LevelInfo;
            retVal.Currency = inputPriceLevel.Currency;
            retVal.MonetaryUnitOfMeasure = inputPriceLevel.MonetaryUnitOfMeasure;

            return retVal;
        }

        public void ProcessDay(Models.V2.PriceStructure.Season season, Models.V2.Digin.FixedPrices fixedPrices, Models.V2.Digin.EnergyPrice[] energyPrices, DateTimeOffset paramFromDate, DateTimeOffset paramToDate)
        {
            var retVal = new List<Models.V2.Digin.PriceInfo>();
            var fromDate = paramFromDate;
            while (fromDate < paramFromDate)
            {
                var priceInfo = new Models.V2.Digin.PriceInfo();
                priceInfo.StartTime = fromDate;
                priceInfo.ExpiredAt = fromDate.AddHours(1);
                priceInfo.HoursShortName = $"{priceInfo.StartTime.Hour.ToString().PadLeft(2, '0')}-{(priceInfo.ExpiredAt.Hour + 1).ToString().PadLeft(2, '0')}";
                priceInfo.Season = season.Name;
//                priceInfo.PublicHoliday       todo
                priceInfo.FixedPrices = new List<Models.V2.Digin.FixedPrices>();
                priceInfo.FixedPrices.Add(fixedPrices);
                priceInfo.VariablePrices = new Models.V2.Digin.VariablePrices();
                priceInfo.VariablePrices.EnergyPrice = energyPrices[fromDate.Hour];

                retVal.Add(priceInfo);
            }
            throw new NotSupportedException();
        }

        public Models.V2.Digin.EnergyPrice[] CalcVariableEnergyPrice (Models.V2.PriceStructure.EnergyPrice priceStructureEnergyPrice, List<Models.V2.PriceStructure.EnergyPriceTax> energyPriceTaxes)
        {
            Models.V2.Digin.EnergyPrice[] retval = new Models.V2.Digin.EnergyPrice[24];
            foreach (var priceLevel in priceStructureEnergyPrice.PriceLevel)
            {
                var energyPrice = new Models.V2.Digin.EnergyPrice();
                energyPrice.Total = priceLevel.Total;
                //                energyPrice.EnergyExTaxes
                //energyPrice.Taxes;
                energyPrice.Level = priceLevel.Level;
                energyPrice.Currency = priceLevel.Currency;
                energyPrice.MonetaryUnitOfMeasure = priceLevel.MonetaryUnitOfMeasure;

                foreach (var hour in priceLevel.Hours)
                {
                    retval[hour] = energyPrice;
                }
            }
            return retval;
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
            //todo subtract one second ?
        }
    }
}
