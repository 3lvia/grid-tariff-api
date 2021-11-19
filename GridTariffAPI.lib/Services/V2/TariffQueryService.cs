using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.V2.Digin;
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
            DateTimeOffset paramFromDate, 
            DateTimeOffset paramToDate)
        {
            var tariff = _tariffPriceCache.GetTariff(tariffKey, paramFromDate, paramToDate);
            var company = _tariffPriceCache.GetCompany();

            var gridTariffCollection = new GridTariffCollection();
            gridTariffCollection.GridTariff = ToGridTariff(company, tariff);    //todo sjekk nye attributter
            tariff.TariffPrices.RemoveAll(x => x.EndDate <= paramFromDate || x.StartDate > paramToDate);
            var tariffPrice = ProcessTariffPrices(tariff.TariffPrices, paramFromDate, paramToDate);
            gridTariffCollection.GridTariff.TariffPrice = tariffPrice;
            await Task.CompletedTask;
            return gridTariffCollection;
        }



        public Models.V2.Digin.TariffPrice ProcessTariffPrices(
            List<Models.V2.PriceStructure.TariffPrice> tariffPricePrices,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate)
        {
            var tariffPrice = new Models.V2.Digin.TariffPrice();    //todo generere tariff
            tariffPrice.PriceInfo = new Models.V2.Digin.PriceInfo();
            tariffPrice.PriceInfo.FixedPrices = new List<Models.V2.Digin.FixedPrices>();
            tariffPrice.PriceInfo.PowerPrices = new List<Models.V2.Digin.PowerPrices>();

            foreach (var tariffPricePrice in tariffPricePrices)
            {
                processTariffPrice(paramFromDate, paramToDate, tariffPrice, tariffPricePrice);
            }
            return tariffPrice;
        }

        private void processTariffPrice(DateTimeOffset paramFromDate, DateTimeOffset paramToDate, TariffPrice tariffPrice, Models.V2.PriceStructure.TariffPrice tariffPricePrice)
        {
            var startDate = tariffPricePrice.StartDate <= paramFromDate ? paramFromDate : tariffPricePrice.StartDate;
            var endDate = tariffPricePrice.EndDate > paramToDate ? paramToDate : tariffPricePrice.EndDate;

            foreach (var season in tariffPricePrice.Seasons)
            {
                if (season.Name == "winter")
                {
                    bool debug = true;
                }
                var accumulator = ProcessSeason(
                    season,
                    tariffPricePrice,
                    startDate,
                    endDate);

                if (accumulator != null)
                {
                    foreach (var fixedPrice in accumulator.TariffPrice.PriceInfo.FixedPrices)
                    {
                        tariffPrice.PriceInfo.FixedPrices.Add(fixedPrice);
                    }
                    foreach (var powerPrice in accumulator.TariffPrice.PriceInfo.PowerPrices)
                    {
                        tariffPrice.PriceInfo.PowerPrices.Add(powerPrice);
                    }
                    //todo energyPrices
                }
            }
        }

        SeasonDataNew ProcessSeason(Models.V2.PriceStructure.Season season,
            Models.V2.PriceStructure.TariffPrice tariffPricePrice,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate)
        {
            var dataAccumulator = new SeasonDataNew() { };
            dataAccumulator.TariffPrice.PriceInfo.FixedPrices.Add(ToFixedPrice(tariffPricePrice, season.FixedPrices));
            dataAccumulator.TariffPrice.PriceInfo.PowerPrices.Add(ToPowerPrice(tariffPricePrice, season.PowerPrices));

            var fromDate = paramFromDate;
            while (fromDate < paramToDate)
            {
                var currMonthEndToDate = GetNextMonthEndDate(fromDate, paramToDate);
                if (season.Months.Contains(fromDate.Month))
                {
                    var daysInMonth = DateTime.DaysInMonth(fromDate.Year,fromDate.Month);
                    dataAccumulator = AddFixedPrices(season.FixedPrices, tariffPricePrice.Taxes.FixedPriceTaxes, daysInMonth, dataAccumulator);
                    dataAccumulator = AddPowerPrices(season.PowerPrices, tariffPricePrice.Taxes.PowerPriceTaxes, daysInMonth, dataAccumulator);
                }
                fromDate = currMonthEndToDate;
            }
            if (dataAccumulator.TariffPrice.PriceInfo.FixedPrices.First().PriceLevel.Count == 0)
            {
                return null;
            }
            return dataAccumulator;
        }

        SeasonDataNew AddFixedPrices(
            Models.V2.PriceStructure.FixedPrices fixedPricesPrices,
            List<Models.V2.PriceStructure.FixedPriceTax> fixedPriceTaxes,
            int daysInMonth,
            SeasonDataNew dataAccumulator)
        {
            if (!dataAccumulator.FixedPricesDaysInMonthProcessed[daysInMonth])
            {
                AppendFixedPriceLevels(dataAccumulator.TariffPrice.PriceInfo.FixedPrices.FirstOrDefault(), fixedPricesPrices, fixedPriceTaxes, daysInMonth);
                dataAccumulator.FixedPricesDaysInMonthProcessed[daysInMonth] = true;
            }
            return dataAccumulator;
        }


        SeasonDataNew AddPowerPrices(
            Models.V2.PriceStructure.PowerPrices powerPricePrices,
            List<Models.V2.PriceStructure.PowerPriceTax> powerPriceTaxes,
            int daysInMonth,
            SeasonDataNew dataAccumulator)
        {
            if (!dataAccumulator.PowerPricesDaysInMonthProcessed[daysInMonth])
            {
                AppendPowerPriceLevels(dataAccumulator.TariffPrice.PriceInfo.PowerPrices.FirstOrDefault(), powerPricePrices, powerPriceTaxes, daysInMonth);
                dataAccumulator.PowerPricesDaysInMonthProcessed[daysInMonth] = true;
            }
            return dataAccumulator;
        }



        void AppendPowerPriceLevels(
            Models.V2.Digin.PowerPrices powerPrices,
            Models.V2.PriceStructure.PowerPrices powerPricePrices,
            List<Models.V2.PriceStructure.PowerPriceTax> powerPriceTaxes,
            int daysInMonth)
        {
            foreach (var PowerPricePrice in powerPricePrices.PowerPriceLevel)
            {
                var powerPriceLevel = powerPrices.PriceLevel.FirstOrDefault(a => a.Id == PowerPricePrice.LevelId);
                if (powerPriceLevel == null)
                {
                    powerPriceLevel = PriceLevelPowerPriceToPowerPriceLevel(PowerPricePrice, powerPriceTaxes);
                    powerPrices.PriceLevel.Add(powerPriceLevel);
                }
                //todo
                //                fixedPriceLevel.HourPrices.Add(CalcMonthlyFixedPrices(PowerPricePrice, powerPriceTaxes, daysInMonth));
            }
        }

        PowerPriceLevel PriceLevelPowerPriceToPowerPriceLevel(
            Models.V2.PriceStructure.PowerPriceLevel powerPriceLevel,
            List<Models.V2.PriceStructure.PowerPriceTax> powerPriceTaxes)
        {
            var retVal = new Models.V2.Digin.PowerPriceLevel();
            var vatTax = powerPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");

            retVal.Id = powerPriceLevel.LevelId;
            retVal.ValueMin = powerPriceLevel.LevelValueMin;
            retVal.ValueMax = powerPriceLevel.LevelValueMax;
            retVal.NextIdDown = powerPriceLevel.NextLevelIdDown;
            retVal.NextIdUp = powerPriceLevel.NextLevelIdUp;
            retVal.ValueUnitOfMeasure = powerPriceLevel.ValueUnitOfMeasure;
            retVal.MonthlyActivePowerTotalExVat = powerPriceLevel.MonthlyActivePowerTotalExVat;
            retVal.MonthlyActivePowerTotal = AddTaxes(retVal.MonthlyActivePowerTotalExVat, vatTax.TaxValue);
            retVal.MonthlyActivePowerExTaxes = retVal.MonthlyActivePowerTotalExVat;
            retVal.MonthlyActivePowerTaxes = retVal.MonthlyActivePowerTotal - retVal.MonthlyActivePowerTotalExVat;
            retVal.MonthlyReactivePowerTotalExVat = powerPriceLevel.MonthlyReactivePowerTotalExVat;
            retVal.MonthlyReactivePowerTotal = AddTaxes(retVal.MonthlyReactivePowerTotalExVat, vatTax.TaxValue);
            retVal.MonthlyReactivePowerExTaxes = powerPriceLevel.MonthlyReactivePowerTotalExVat;
            retVal.MonthlyReactivePowerTaxes = retVal.MonthlyReactivePowerTotal - retVal.MonthlyReactivePowerTotalExVat;
            retVal.MonthlyUnitOfMeasure = powerPriceLevel.MonthlyTotalUnitOfMeasure;
            retVal.HourPrices = new List<HourPowerPrices>();
            retVal.LevelInfo = powerPriceLevel.LevelInfo;
            retVal.Currency = powerPriceLevel.Currency;
            retVal.MonetaryUnitOfMeasure = powerPriceLevel.MonetaryUnitOfMeasure;
            return retVal;
        }


        void AppendFixedPriceLevels(
            Models.V2.Digin.FixedPrices fixedPrices,
            Models.V2.PriceStructure.FixedPrices fixedPricesPrices,
            List<Models.V2.PriceStructure.FixedPriceTax> fixedPriceTaxes,
            int daysInMonth)
        {
            foreach (var fixedPricesPrice in fixedPricesPrices.FixedPriceLevel)
            {
                var fixedPriceLevel = fixedPrices.PriceLevel.FirstOrDefault(a => a.Id == fixedPricesPrice.Id);
                if (fixedPriceLevel == null)
                {
                    fixedPriceLevel = PriceLevelPriceToFixedPriceLevel(fixedPricesPrice, fixedPriceTaxes);
                    fixedPrices.PriceLevel.Add(fixedPriceLevel);
                }
                fixedPriceLevel.HourPrices.Add(CalcMonthlyFixedPrices(fixedPricesPrice, fixedPriceTaxes, daysInMonth));
            }
        }

        FixedPrices ToFixedPrice(Models.V2.PriceStructure.TariffPrice tariffPricePeriod,
            Models.V2.PriceStructure.FixedPrices fixedPrices)
        {
            var retVal = new FixedPrices
            {
                Id = fixedPrices.Id,
                StartDate = tariffPricePeriod.StartDate,
                EndDate = tariffPricePeriod.EndDate,
                PriceLevel = new List<FixedPriceLevel>()
            };
            return retVal;
        }

        PowerPrices ToPowerPrice(Models.V2.PriceStructure.TariffPrice tariffPricePeriod,
            Models.V2.PriceStructure.PowerPrices powerPrices)
        {
            var retVal = new PowerPrices
            {
                Id = powerPrices.Id,
                StartDate = tariffPricePeriod.StartDate,
                EndDate = tariffPricePeriod.EndDate,
                PriceLevel = new List<PowerPriceLevel>()
            };
            return retVal;
        }


        FixedPriceLevel PriceLevelPriceToFixedPriceLevel(
            Models.V2.PriceStructure.FixedPriceLevel priceLevel,
            List<Models.V2.PriceStructure.FixedPriceTax> fixedPriceTaxes)
        {
            var retVal = new Models.V2.Digin.FixedPriceLevel();
            var vatTax = fixedPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");

            retVal.Id = priceLevel.LevelId;
            retVal.ValueMin = priceLevel.ValueMin;
            retVal.ValueMax = priceLevel.ValueMax;
            retVal.NextIdDown = priceLevel.NextIdDown;
            retVal.NextIdUp = priceLevel.NextIdUp;
            retVal.ValueUnitOfMeasure = priceLevel.ValueUnitOfMeasure;
            retVal.MonthlyTotal = AddTaxes(priceLevel.MonthlyTotalExVat, vatTax.TaxValue);
            retVal.MonthlyTotalExVat = priceLevel.MonthlyTotalExVat;
            retVal.MonthlyExTaxes = retVal.MonthlyTotalExVat;   //todo er det andre skatter enn vat som skal beregnes her ? ikke p.t. 2021.11.19
            retVal.MonthlyTaxes = retVal.MonthlyTotal - retVal.MonthlyExTaxes;
            retVal.HourPrices = new List<HourFixedPrices>();
            retVal.MonthlyUnitOfMeasure = priceLevel.MonthlyUnitOfMeasure;
            retVal.LevelInfo = priceLevel.LevelInfo;
            retVal.Currency = priceLevel.Currency;
            retVal.MonetaryUnitOfMeasure = priceLevel.MonetaryUnitOfMeasure;
            return retVal;
        }

        public Models.V2.Digin.HourFixedPrices CalcMonthlyFixedPrices(
            Models.V2.PriceStructure.FixedPriceLevel fixedPricePriceLevel,
            List<Models.V2.PriceStructure.FixedPriceTax> fixedPriceTaxes,
//            List<Models.V2.PriceStructure.FixedPriceTax> fixedPriceTaxes,
            int daysInMonth)
        {
            var vatTax = fixedPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");
            int hoursInMonth = daysInMonth * Constants.HoursInDay;
            var totalExVatPerHour = fixedPricePriceLevel.MonthlyTotalExVat / hoursInMonth;

            var retVal = new Models.V2.Digin.HourFixedPrices();
            retVal.Id = Guid.NewGuid().ToString();
            retVal.NumberOfDaysInMonth = daysInMonth;
            retVal.TotalExVat = RoundDouble(totalExVatPerHour, Constants.FixedPricesDecimals);
            retVal.Total = RoundDouble(AddTaxes(totalExVatPerHour, vatTax.TaxValue), Constants.FixedPricesDecimals);
            return retVal;
        }

        void ProcessMonth(DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate)
        {
            var fromDate = paramFromDate;
            while (fromDate.Ticks < paramToDate.Ticks)
            {
                var endDate = fromDate.AddDays(1) < paramToDate ? fromDate.AddDays(1) : paramToDate;
                //tasks.Add(ProcessDayAsync(season, fixedPrices, variableEnergyPrices, powerPrices, fromDate, endDate));
                fromDate = fromDate.AddDays(1);
            }

            throw new NotSupportedException();
        }



        public Models.V2.Digin.GridTariff ToGridTariff(
            Models.V2.PriceStructure.Company company, 
            Models.V2.PriceStructure.TariffType tariffType)
        {
            var retVal = new Models.V2.Digin.GridTariff();
            retVal.TariffType = _objectConversionHelper.ToTariffType(company,tariffType);
            return retVal;
        }

//        public async Task<List<Models.V2.Digin.PriceInfo>> ProcessTariffPriceAsync(
//            Models.V2.PriceStructure.TariffPrice tariffPrice, 
//            DateTimeOffset paramFromDate, 
//            DateTimeOffset paramToDate)
//        {
//            var tasks = new List<Task<List<Models.V2.Digin.PriceInfo>>>();
//            var retVal = new List<Models.V2.Digin.PriceInfo>();
//            var fromDate = paramFromDate;
//            while (fromDate < paramToDate)
//            {
//                var currMonthEndToDate = GetNextMonthEndDate(fromDate, paramToDate);
////                tasks.Add(ProcessMonthAsync(tariffPrice, fromDate, currMonthEndToDate));
//                fromDate = currMonthEndToDate;
//            }
//            foreach (var task in tasks)
//            {
//                retVal.AddRange(await task);
//            }
//            return retVal;
//        }


        //public async Task<List<Models.V2.Digin.PriceInfo>> ProcessMonthAsync(
        //    GridTariffApi.Lib.Models.V2.PriceStructure.TariffPrice tariffPrice, 
        //    DateTimeOffset paramFromDate, 
        //    DateTimeOffset paramToDate)
        //{
            
        //    //var tasks = new List<Task<List<Models.V2.Digin.PriceInfo>>>();
        //    //var retVal = new List<Models.V2.Digin.PriceInfo>();
        //    //var season = tariffPrice.Seasons.FirstOrDefault(x => x.Months.Contains(paramFromDate.Month));
        //    //var fixedPrices = CalcMonthlyFixePrices(season.FixedPrices, tariffPrice.Taxes.FixedPriceTaxes, paramFromDate.Year, paramFromDate.Month);
        //    //var variableEnergyPrices = CalcVariableEnergyPrice(season.EnergyPrice, tariffPrice.Taxes.EnergyPriceTaxes);
        //    //var powerPrices = CalcPowerPrices(season.PowerPrices, tariffPrice.Taxes.PowerPriceTaxes,paramFromDate.Year, paramFromDate.Month);
        //    //var fromDate = paramFromDate;
        //    //while (fromDate.Ticks < paramToDate.Ticks)
        //    //{
        //    //    var endDate = fromDate.AddDays(1) < paramToDate ? fromDate.AddDays(1) : paramToDate;
        //    //    tasks.Add(ProcessDayAsync(season, fixedPrices, variableEnergyPrices, powerPrices, fromDate, endDate));
        //    //    fromDate = fromDate.AddDays(1);
        //    //}
        //    //foreach (var task in tasks)
        //    //{
        //    //    retVal.AddRange(await task);
        //    //}
        //    //return retVal;
        //}

        //public List<Models.V2.Digin.PowerPrice> CalcPowerPrices(
        //    Models.V2.PriceStructure.PowerPrices powerPrices, 
        //    List<Models.V2.PriceStructure.PowerPriceTax> powerPriceTaxes,
        //    int year,
        //    int month)
        //{
        //    var retVal = new List<Models.V2.Digin.PowerPrice>();
        //    if (powerPrices != null)
        //    {
        //        int hoursInMonth = DateTime.DaysInMonth(year, month) * Constants.HoursInDay;
        //        var vatTax = GetPowerPriceTax(powerPriceTaxes, "vat");
        //        foreach (var priceLevel in powerPrices.PriceLevel)
        //        {
        //            var powerPrice = new Models.V2.Digin.PowerPrice();
        //            //todo
        //            //powerPrice.LevelId = priceLevel.LevelId;
        //            //if (priceLevel.LevelValueMin.HasValue)
        //            //{
        //            //    powerPrice.LevelValueMin = priceLevel.LevelValueMin.Value;
        //            //}
        //            //if (priceLevel.LevelValueMax.HasValue)
        //            //{
        //            //    powerPrice.LevelValueMax = priceLevel.LevelValueMax.Value;
        //            //}
        //            //if (priceLevel.NextLevelIdDown.HasValue)
        //            //{
        //            //    powerPrice.NextLevelIdDown = priceLevel.NextLevelIdDown.Value;
        //            //}
        //            //if (priceLevel.NextLevelIdUp.HasValue)
        //            //{
        //            //    powerPrice.NextLevelIdUp = priceLevel.NextLevelIdUp.Value;
        //            //}
        //            //powerPrice.LevelValueUnitOfMeasure = priceLevel.LevelValueUnitOfMeasure;
        //            //powerPrice.MonthlyActivePowerTotal = RoundDouble(priceLevel.MonthlyActivePowerTotal, Constants.PowerPriceDecimals);
        //            //powerPrice.MonthlyReactivePowerTotal = RoundDouble(priceLevel.MonthlyReactivePowerTotal, Constants.PowerPriceDecimals);
        //            ////                powerPrice.MonthlyTotalUnitOfMeasure = priceLevel.MonthlyTotalUnitOfMeasure;
        //            //powerPrice.LevelInfo = priceLevel.LevelInfo;
        //            //powerPrice.ActiveTotal = RoundDouble(powerPrice.MonthlyActivePowerTotal / hoursInMonth, Constants.PowerPriceDecimals);
        //            //powerPrice.ActiveTaxes = RoundDouble(CalcTaxes(powerPrice.ActiveTotal, vatTax),4);
        //            //powerPrice.ActivePowerExTaxes = RoundDouble(powerPrice.ActiveTotal - powerPrice.ActiveTaxes, Constants.PowerPriceDecimals);
        //            //powerPrice.ReactiveTotal = RoundDouble(powerPrice.MonthlyReactivePowerTotal / hoursInMonth, Constants.PowerPriceDecimals);
        //            //powerPrice.ReactiveTaxes = RoundDouble(CalcTaxes(powerPrice.ReactiveTotal, vatTax), Constants.PowerPriceDecimals);
        //            //powerPrice.ReactivePowerExTaxes = RoundDouble(powerPrice.ReactiveTotal - powerPrice.ReactiveTaxes, Constants.PowerPriceDecimals);
        //            //powerPrice.Currency = priceLevel.Currency;
        //            //powerPrice.MonetaryUnitOfMeasure = priceLevel.MonetaryUnitOfMeasure;

        //            retVal.Add(powerPrice);
        //        }
        //    }
        //    return retVal;
        //}

        public double RoundDouble(double value, int numDecimals)
        {
            double addValue = 1 / Math.Pow(10, numDecimals +1);
            return Math.Round(value + addValue, numDecimals);
        }

        public double CalcTaxes (double input, double vat)
        {
            return input-(input*100/(100+vat));
        }

        public double AddTaxes(double input, double vat)
        {
            return input + (input * (vat/100));
        }
        //todo
//        public Models.V2.Digin.PriceLevel ToPriceLevel(Models.V2.PriceStructure.PriceLevel inputPriceLevel)
//        {
//            var retVal = new Models.V2.Digin.PriceLevel();

//            retVal.LevelId = inputPriceLevel.LevelId;

//            if (inputPriceLevel.LevelValueMin.HasValue)
//            {
//                retVal.LevelValueMin = inputPriceLevel.LevelValueMin.Value;
//            }
//            if (inputPriceLevel.LevelValueMax.HasValue)
//            {
//                retVal.LevelValueMax = inputPriceLevel.LevelValueMax.Value;
//            }
//            if (inputPriceLevel.NextLevelIdDown.HasValue)
//            {
//                retVal.NextLevelIdDown = inputPriceLevel.NextLevelIdDown.Value;
//            }
//            if (inputPriceLevel.NextLevelIdUp.HasValue)
//            {
//                retVal.NextLevelIdUp = inputPriceLevel.NextLevelIdUp.Value;
//            }
//            retVal.LevelValueUnitOfMeasure = inputPriceLevel.LevelValueUnitOfMeasure;
//            retVal.MonthlyTotal = inputPriceLevel.MonthlyTotal;
////            retVal.MonthlyTotalUnitOfMeasure = inputPriceLevel.MonthlyTotalUnitOfMeasure;     //todo
//            retVal.LevelInfo = inputPriceLevel.LevelInfo;
//            retVal.Currency = inputPriceLevel.Currency;
//            retVal.MonetaryUnitOfMeasure = inputPriceLevel.MonetaryUnitOfMeasure;

//            return retVal;
//        }

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
//todo
//                priceInfo.StartTime = fromDate;
//                priceInfo.ExpiredAt = fromDate.AddHours(1);     //todo resolution fra prisstruktur
//                priceInfo.HoursShortName = $"{priceInfo.StartTime.Hour.ToString().PadLeft(2, '0')}-{(priceInfo.ExpiredAt.Hour).ToString().PadLeft(2, '0')}";
//                priceInfo.Season = season.Name;
////                priceInfo.PublicHoliday       todo
//                priceInfo.FixedPrices = new List<Models.V2.Digin.FixedPrices>();
//                priceInfo.FixedPrices.Add(fixedPrices);
//                priceInfo.VariablePrices = new Models.V2.Digin.VariablePrices();
//                priceInfo.VariablePrices.EnergyPrice = energyPrices[fromDate.Hour];
//                priceInfo.VariablePrices.PowerPriceLevel = new List<Models.V2.Digin.PowerPrice>();
//                foreach (var powerPrice in powerPrices)
//                {
//                    priceInfo.VariablePrices.PowerPriceLevel.Add(powerPrice);
//                }
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
            //todo
            //foreach (var priceLevel in priceStructureEnergyPrice.PriceLevel)
            //{
            //    var energyPrice = new Models.V2.Digin.EnergyPrice();
            //    energyPrice.Level = priceLevel.Level;
            //    energyPrice.Currency = priceLevel.Currency;
            //    energyPrice.MonetaryUnitOfMeasure = priceLevel.MonetaryUnitOfMeasure;

            //    energyPrice.Total = RoundDouble (priceLevel.Total,Constants.EnergyPriceDecimals);
            //    var energyExTaxes = CalcVariablePriceEnergyExTaxes(
            //        priceLevel.Total,
            //        consumptionTax,
            //        enovaTax,
            //        vatTax);
            //    energyPrice.EnergyExTaxes = RoundDouble(energyExTaxes, Constants.EnergyPriceDecimals);
            //    energyPrice.Taxes = RoundDouble(energyPrice.Total - energyPrice.EnergyExTaxes, Constants.EnergyPriceDecimals);
            //    foreach (var hour in priceLevel.Hours)
            //    {
            //        retval[hour] = energyPrice;
            //    }
            //}
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
