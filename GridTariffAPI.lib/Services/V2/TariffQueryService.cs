﻿using GridTariffApi.Lib.Models.V2.Digin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Services.V2
{
    public interface ITariffQueryService
    {
        Task<GridTariffCollection> QueryTariffAsync(string tariffKey, DateTimeOffset paramFromDate, DateTimeOffset paramToDate);
    }

    public class TariffQueryService : ITariffQueryService
    {
        private readonly ITariffPriceCache _tariffPriceCache;
        private readonly IObjectConversionHelper _objectConversionHelper;
        public TariffQueryService(
            ITariffPriceCache tariffPriceCache,
            IObjectConversionHelper objectConversionHelper)
        {
            _tariffPriceCache = tariffPriceCache;
            _objectConversionHelper = objectConversionHelper;
        }

        public async Task<GridTariffCollection> QueryTariffAsync(
            string tariffKey, 
            DateTimeOffset paramFromDate, DateTimeOffset paramToDate)
        {
            var tariff = _tariffPriceCache.GetTariff(tariffKey, paramFromDate, paramToDate);
            var company = _tariffPriceCache.GetCompany();

            var gridTariffCollection = new GridTariffCollection();
            gridTariffCollection.GridTariff = ToGridTariff(company, tariff);
            gridTariffCollection.GridTariff.TariffPrice = new Models.V2.Digin.TariffPrice();
            gridTariffCollection.GridTariff.TariffPrice.PriceInfo = new List<PriceInfo>();

            tariff.TariffPrices.RemoveAll(x => x.EndDate <= paramFromDate || x.StartDate > paramToDate);
            Parallel.ForEach(tariff.TariffPrices.OrderBy(x => x.StartDate), async tariffPrice =>
            {
                var startDate = tariffPrice.StartDate <= paramFromDate ? paramFromDate : tariffPrice.StartDate;
                var endDate = tariffPrice.EndDate > paramToDate ? paramToDate : tariffPrice.EndDate;
                foreach (var priceInfo in await ProcessTariffPriceAsync(tariffPrice, startDate, endDate))
                {
                    gridTariffCollection.GridTariff.TariffPrice.PriceInfo.Add(priceInfo);
                }
            });
            await Task.CompletedTask;
            return gridTariffCollection;
        }

        public Models.V2.Digin.GridTariff ToGridTariff(
            Models.V2.PriceStructure.Company company, 
            Models.V2.PriceStructure.TariffType tariffType)
        {
            var retVal = new Models.V2.Digin.GridTariff();
            retVal.TariffType = _objectConversionHelper.ToTariffType(company,tariffType);
            return retVal;
        }

        public async Task<List<Models.V2.Digin.PriceInfo>> ProcessTariffPriceAsync(
            Models.V2.PriceStructure.TariffPrice tariffPrice, 
            DateTimeOffset paramFromDate, 
            DateTimeOffset paramToDate)
        {
            var tasks = new List<Task<List<Models.V2.Digin.PriceInfo>>>();
            var retVal = new List<Models.V2.Digin.PriceInfo>();
            var fromDate = paramFromDate;
            while (fromDate < paramToDate)
            {
                var currMonthEndToDate = GetNextMonthEndDate(fromDate, paramToDate);
                tasks.Add(ProcessMonthAsync(tariffPrice, fromDate, currMonthEndToDate));
                fromDate = currMonthEndToDate;
            }
            foreach (var task in tasks)
            {
                retVal.AddRange(await task);
            }
            return retVal;
        }


        public async Task<List<Models.V2.Digin.PriceInfo>> ProcessMonthAsync(
            GridTariffApi.Lib.Models.V2.PriceStructure.TariffPrice tariffPrice, 
            DateTimeOffset paramFromDate, 
            DateTimeOffset paramToDate)
        {
            var tasks = new List<Task<List<Models.V2.Digin.PriceInfo>>>();
            var retVal = new List<Models.V2.Digin.PriceInfo>();
            var season = tariffPrice.Seasons.FirstOrDefault(x => x.Months.Contains(paramFromDate.Month));
            var fixedPrices = CalcMonthlyFixePrices(season.FixedPrices, tariffPrice.Taxes.FixedPriceTaxes, paramFromDate.Year, paramFromDate.Month);
            var variableEnergyPrices = CalcVariableEnergyPrice(season.EnergyPrice, tariffPrice.Taxes.EnergyPriceTaxes);
            var powerPrices = CalcPowerPrices(season.PowerPrices, tariffPrice.Taxes.PowerPriceTaxes,paramFromDate.Year, paramFromDate.Month);
            var fromDate = paramFromDate;
            while (fromDate.Ticks < paramToDate.Ticks)
            {
                var endDate = fromDate.AddDays(1) < paramToDate ? fromDate.AddDays(1) : paramToDate;
                tasks.Add(ProcessDayAsync(season, fixedPrices, variableEnergyPrices, powerPrices, fromDate, endDate));
                fromDate = fromDate.AddDays(1);
            }
            foreach (var task in tasks)
            {
                retVal.AddRange(await task);
            }
            return retVal;
        }

        public List<Models.V2.Digin.PowerPrice> CalcPowerPrices(
            Models.V2.PriceStructure.PowerPrices powerPrices, 
            List<Models.V2.PriceStructure.PowerPriceTax> powerPriceTaxes,
            int year,
            int month)
        {
            var retVal = new List<Models.V2.Digin.PowerPrice>();
            if (powerPrices != null)
            {
                int hoursInMonth = DateTime.DaysInMonth(year, month) * Constants.HoursInDay;
                var vatTax = GetPowerPriceTax(powerPriceTaxes, "vat");
                foreach (var priceLevel in powerPrices.PriceLevel)
                {
                    var powerPrice = new Models.V2.Digin.PowerPrice();
                    powerPrice.LevelId = priceLevel.LevelId;
                    if (priceLevel.LevelValueMin.HasValue)
                    {
                        powerPrice.LevelValueMin = priceLevel.LevelValueMin.Value;
                    }
                    if (priceLevel.LevelValueMax.HasValue)
                    {
                        powerPrice.LevelValueMax = priceLevel.LevelValueMax.Value;
                    }
                    if (priceLevel.NextLevelIdDown.HasValue)
                    {
                        powerPrice.NextLevelIdDown = priceLevel.NextLevelIdDown.Value;
                    }
                    if (priceLevel.NextLevelIdUp.HasValue)
                    {
                        powerPrice.NextLevelIdUp = priceLevel.NextLevelIdUp.Value;
                    }
                    powerPrice.LevelValueUnitOfMeasure = priceLevel.LevelValueUnitOfMeasure;
                    powerPrice.MonthlyActivePowerTotal = RoundDouble(priceLevel.MonthlyActivePowerTotal, Constants.PowerPriceDecimals);
                    powerPrice.MonthlyReactivePowerTotal = RoundDouble(priceLevel.MonthlyReactivePowerTotal, Constants.PowerPriceDecimals);
                    //                powerPrice.MonthlyTotalUnitOfMeasure = priceLevel.MonthlyTotalUnitOfMeasure;
                    powerPrice.LevelInfo = priceLevel.LevelInfo;
                    powerPrice.ActiveTotal = RoundDouble(powerPrice.MonthlyActivePowerTotal / hoursInMonth, Constants.PowerPriceDecimals);
                    powerPrice.ActiveTaxes = RoundDouble(CalcTaxes(powerPrice.ActiveTotal, vatTax),4);
                    powerPrice.ActivePowerExTaxes = RoundDouble(powerPrice.ActiveTotal - powerPrice.ActiveTaxes, Constants.PowerPriceDecimals);
                    powerPrice.ReactiveTotal = RoundDouble(powerPrice.MonthlyReactivePowerTotal / hoursInMonth, Constants.PowerPriceDecimals);
                    powerPrice.ReactiveTaxes = RoundDouble(CalcTaxes(powerPrice.ReactiveTotal, vatTax), Constants.PowerPriceDecimals);
                    powerPrice.ReactivePowerExTaxes = RoundDouble(powerPrice.ReactiveTotal - powerPrice.ReactiveTaxes, Constants.PowerPriceDecimals);
                    powerPrice.Currency = priceLevel.Currency;
                    powerPrice.MonetaryUnitOfMeasure = priceLevel.MonetaryUnitOfMeasure;

                    retVal.Add(powerPrice);
                }
            }
            return retVal;
        }

        public double RoundDouble(double value, int numDecimals)
        {
            double addValue = 1 / Math.Pow(10, numDecimals +1);
            return Math.Round(value + addValue, numDecimals);
        }

        public double CalcTaxes (double input, double vat)
        {
            return input-(input*100/(100+vat));
        }

        public Models.V2.Digin.FixedPrices CalcMonthlyFixePrices(
            Models.V2.PriceStructure.FixedPrices fixedPrices, 
            List<Models.V2.PriceStructure.FixedPriceTax> fixedPriceTaxes, 
            int year, 
            int month)
        {
            var retVal = new Models.V2.Digin.FixedPrices() { PriceLevel = new List<Models.V2.Digin.PriceLevel>() };
            
            int hoursInMonth = DateTime.DaysInMonth(year, month)* Constants.HoursInDay;
            var vatTax = fixedPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");
            foreach (var priceLevelPrice in fixedPrices.PriceLevel)
            {
                var priceLevel = ToPriceLevel(priceLevelPrice);
                priceLevel.Total = RoundDouble(priceLevelPrice.MonthlyTotal / hoursInMonth, Constants.FixedPricesDecimals);
                priceLevel.Taxes = RoundDouble(CalcTaxes(priceLevel.Total, vatTax.TaxValue), Constants.FixedPricesDecimals);
                priceLevel.FixedExTaxes = RoundDouble(priceLevel.Total - priceLevel.Taxes, Constants.FixedPricesDecimals);
                retVal.PriceLevel.Add(priceLevel);
            }
            return retVal;
        }

        public Models.V2.Digin.PriceLevel ToPriceLevel(Models.V2.PriceStructure.PriceLevel inputPriceLevel)
        {
            var retVal = new Models.V2.Digin.PriceLevel();

            retVal.LevelId = inputPriceLevel.LevelId;

            if (inputPriceLevel.LevelValueMin.HasValue)
            {
                retVal.LevelValueMin = inputPriceLevel.LevelValueMin.Value;
            }
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

        public async Task<List<Models.V2.Digin.PriceInfo>> ProcessDayAsync(
            Models.V2.PriceStructure.Season season,
            Models.V2.Digin.FixedPrices fixedPrices,
            Models.V2.Digin.EnergyPrice[] energyPrices,
            List<Models.V2.Digin.PowerPrice> powerPrices,
            DateTimeOffset paramFromDate, 
            DateTimeOffset paramToDate)
        {
            var retVal = new List<Models.V2.Digin.PriceInfo>();
            var fromDate = paramFromDate;
            while (fromDate < paramToDate)
            {
                var priceInfo = new Models.V2.Digin.PriceInfo();
                priceInfo.StartTime = fromDate;
                priceInfo.ExpiredAt = fromDate.AddHours(1);     //todo resolution fra prisstruktur
                priceInfo.HoursShortName = $"{priceInfo.StartTime.Hour.ToString().PadLeft(2, '0')}-{(priceInfo.ExpiredAt.Hour).ToString().PadLeft(2, '0')}";
                priceInfo.Season = season.Name;
//                priceInfo.PublicHoliday       todo
                priceInfo.FixedPrices = new List<Models.V2.Digin.FixedPrices>();
                priceInfo.FixedPrices.Add(fixedPrices);
                priceInfo.VariablePrices = new Models.V2.Digin.VariablePrices();
                priceInfo.VariablePrices.EnergyPrice = energyPrices[fromDate.Hour];
                priceInfo.VariablePrices.PowerPriceLevel = new List<Models.V2.Digin.PowerPrice>();
                foreach (var powerPrice in powerPrices)
                {
                    priceInfo.VariablePrices.PowerPriceLevel.Add(powerPrice);
                }
                retVal.Add(priceInfo);
                fromDate = fromDate.AddHours(1); //todo resolution fra prisstruktur
            }
            await Task.CompletedTask;
            return retVal;
        }

        public Models.V2.Digin.EnergyPrice[] CalcVariableEnergyPrice (Models.V2.PriceStructure.EnergyPrice priceStructureEnergyPrice, List<Models.V2.PriceStructure.EnergyPriceTax> energyPriceTaxes)
        {
            var consumptionTax = GetEnergyPriceTax(energyPriceTaxes, "consumptionTax");
            var enovaTax = GetEnergyPriceTax(energyPriceTaxes, "enovaTax");
            var vatTax = GetEnergyPriceTax(energyPriceTaxes, "vat");
            Models.V2.Digin.EnergyPrice[] retval = new Models.V2.Digin.EnergyPrice[Constants.HoursInDay];
            foreach (var priceLevel in priceStructureEnergyPrice.PriceLevel)
            {
                var energyPrice = new Models.V2.Digin.EnergyPrice();
                energyPrice.Level = priceLevel.Level;
                energyPrice.Currency = priceLevel.Currency;
                energyPrice.MonetaryUnitOfMeasure = priceLevel.MonetaryUnitOfMeasure;

                energyPrice.Total = RoundDouble (priceLevel.Total,Constants.EnergyPriceDecimals);
                var energyExTaxes = CalcVariablePriceEnergyExTaxes(
                    priceLevel.Total,
                    consumptionTax,
                    enovaTax,
                    vatTax);
                energyPrice.EnergyExTaxes = RoundDouble(energyExTaxes, Constants.EnergyPriceDecimals);
                energyPrice.Taxes = RoundDouble(energyPrice.Total - energyPrice.EnergyExTaxes, Constants.EnergyPriceDecimals);
                foreach (var hour in priceLevel.Hours)
                {
                    retval[hour] = energyPrice;
                }
            }
            return retval;
        }

        public double CalcVariablePriceEnergyExTaxes(double total, double consumptionTax, double enovaTax, double vat)
        {
            double retVal = total - CalcTaxes(total, vat) - consumptionTax - enovaTax;
            return retVal;
        }


        public double GetEnergyPriceTax(List<Models.V2.PriceStructure.EnergyPriceTax> taxes, string taxType)
        {
            var tax = taxes.FirstOrDefault(x => x.TaxType == taxType);
            if (tax != null)
            {
                return tax.TaxValue;
            }
            return 0;
        }

        public double GetPowerPriceTax(List<Models.V2.PriceStructure.PowerPriceTax> taxes, string taxType)
        {
            var tax = taxes.FirstOrDefault(x => x.TaxType == taxType);
            if (tax != null)
            {
                return tax.TaxValue;
            }
            return 0;
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
