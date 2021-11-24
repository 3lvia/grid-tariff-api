using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.V2.Digin;
using GridTariffApi.Lib.Models.V2.Holidays;
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
            gridTariffCollection.GridTariff = ToGridTariff(company, tariff);
            tariff.TariffPrices.RemoveAll(x => x.EndDate <= paramFromDate || x.StartDate > paramToDate);
            var tariffPrice = ProcessTariffPrices(tariff, paramFromDate, paramToDate);
            gridTariffCollection.GridTariff.TariffPrice = tariffPrice;
            await Task.CompletedTask;
            return gridTariffCollection;
        }

        public Models.V2.Digin.TariffPrice ProcessTariffPrices(
            Models.V2.PriceStructure.TariffType tariffType,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate)
        {
            var tariffPrice = new Models.V2.Digin.TariffPrice();
            tariffPrice.PriceInfo = new Models.V2.Digin.PriceInfo();
            tariffPrice.PriceInfo.FixedPrices = new List<Models.V2.Digin.FixedPrices>();
            tariffPrice.PriceInfo.PowerPrices = new List<Models.V2.Digin.PowerPrices>();
            tariffPrice.PriceInfo.EnergyPrices = new List<Models.V2.Digin.EnergyPrices>();
            tariffPrice.Hours = new List<Models.V2.Digin.Hours>();

            var holidays = _tariffPriceCache.GetHolidays(paramFromDate, paramToDate);
            foreach (var tariffPricePrice in tariffType.TariffPrices)
            {
                ProcessTariffPrice(paramFromDate,
                    paramToDate,
                    tariffPrice,
                    tariffPricePrice,
                    holidays,
                    tariffType);
            }
            return tariffPrice;
        }

        private void ProcessTariffPrice(DateTimeOffset paramFromDate, 
            DateTimeOffset paramToDate, 
            TariffPrice tariffPrice, 
            Models.V2.PriceStructure.TariffPrice tariffPricePrice,
            List<Holiday> holidays,
            Models.V2.PriceStructure.TariffType tariffType)
        {

            var startDate = tariffPricePrice.StartDate <= paramFromDate ? paramFromDate : tariffPricePrice.StartDate;
            var endDate = tariffPricePrice.EndDate > paramToDate ? paramToDate : tariffPricePrice.EndDate;
            var filteredHolidays = holidays.Where(a => a.Date >= startDate && a.Date <= endDate).ToList();

            foreach (var season in tariffPricePrice.Seasons)
            {
                var accumulator = ProcessSeason(
                    season,
                    tariffPricePrice,
                    startDate,
                    endDate,
                    filteredHolidays,
                    tariffType);

                if (accumulator != null)
                {
                    tariffPrice.PriceInfo.FixedPrices.AddRange(accumulator.TariffPrice.PriceInfo.FixedPrices);
                    tariffPrice.PriceInfo.PowerPrices.AddRange(accumulator.TariffPrice.PriceInfo.PowerPrices);
                    tariffPrice.PriceInfo.EnergyPrices.AddRange(accumulator.TariffPrice.PriceInfo.EnergyPrices);
                    tariffPrice.Hours.AddRange(accumulator.TariffPrice.Hours);
                }
            }
        }

        SeasonDataNew ProcessSeason(Models.V2.PriceStructure.Season season,
            Models.V2.PriceStructure.TariffPrice tariffPricePrice,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate,
            List<Holiday> holidays,
            Models.V2.PriceStructure.TariffType tariffType)
        {
            var dataAccumulator = new SeasonDataNew() { };
            if (season.FixedPrices != null)
            {
                dataAccumulator.TariffPrice.PriceInfo.FixedPrices.Add(ToFixedPrice(tariffPricePrice, season.FixedPrices));
            }
            if (season.PowerPrices != null)
            {
                dataAccumulator.TariffPrice.PriceInfo.PowerPrices.Add(ToPowerPrice(tariffPricePrice, season.PowerPrices));
            }

            var fromDate = paramFromDate;
            while (fromDate < paramToDate)
            {
                var currMonthEndToDate = GetNextMonthEndDate(fromDate, paramToDate);
                if (season.Months.Contains(fromDate.Month))
                {
                    var daysInMonth = DateTime.DaysInMonth(fromDate.Year,fromDate.Month);
                    dataAccumulator = AddFixedPrices(season.FixedPrices, tariffPricePrice.Taxes.FixedPriceTaxes, daysInMonth, dataAccumulator);
                    dataAccumulator = AddPowerPrices(season.PowerPrices, tariffPricePrice.Taxes.PowerPriceTaxes, daysInMonth, dataAccumulator);
                    dataAccumulator = AddEnergyPrices(season.EnergyPrice, tariffPricePrice.Taxes.EnergyPriceTaxes, daysInMonth, dataAccumulator,season.Name, paramFromDate, paramToDate); //todo korrekt fra/tuldato

                    var filteredHolidays = holidays.Where(a => a.Date >= fromDate && a.Date <= currMonthEndToDate).ToList();
                    var hourSeasonIndex = BuildHourSeasonIndex(dataAccumulator.TariffPrice.PriceInfo, season.EnergyPrice, daysInMonth, tariffType.UsePublicHolidayOverride, tariffType.UseWeekendPriceOverride);
                    dataAccumulator = ProcessMonth(dataAccumulator, fromDate, currMonthEndToDate, hourSeasonIndex, filteredHolidays, tariffType.Resolution);
                }
                fromDate = currMonthEndToDate;
            }
            if (dataAccumulator.TariffPrice.PriceInfo.FixedPrices.First().PriceLevel.Count == 0)
            {
                return null;
            }
            return dataAccumulator;
        }

        HourSeasonIndex BuildHourSeasonIndex(Models.V2.Digin.PriceInfo priceInfo
            , Models.V2.PriceStructure.EnergyPrice energyPrice
            , int daysInMonth,
            string usePublicHolidayOverride,
            string useWeekendPriceOverride)

        {
            var retVal = new HourSeasonIndex();

            var fixedPrice = priceInfo.FixedPrices.FirstOrDefault();
            if (fixedPrice != null)
            {
                var monthPrice = fixedPrice.PriceLevel.FirstOrDefault().HourPrices.FirstOrDefault(a => a.NumberOfDaysInMonth == daysInMonth);       //todo hvilken hourprices skal egentlig benyttes? venter på samtale med are.
                //todo are skal det gjenbrukes id, dvs alle fixedprices for en gitt måned skal ha samme id.
                retVal.FixedPriceValue = new PriceElement
                {
                    Id = fixedPrice.Id,
                    IdDaysInMonth = monthPrice.Id
                };
            }
            var powerPrice = priceInfo.PowerPrices.FirstOrDefault();
            if (powerPrice != null)
            {
                var monthPrice = powerPrice.PriceLevel.FirstOrDefault().HourPrices.FirstOrDefault(a => a.NumberOfDaysInMonth == daysInMonth);
                retVal.PowerPriceValue = new PriceElement()
                {
                    Id = powerPrice.Id,
                    IdDaysInMonth = monthPrice.Id
                };
            }

            if (energyPrice != null)
            {
                retVal.EnergyInformation = new EnergyInformation();
                retVal.EnergyInformation.HourArray = new EnergyPrices[Constants.HoursInDay];

                foreach (var priceLevel in energyPrice.EnergyPriceLevel)
                {
                    var energyPriceLevel = priceInfo.EnergyPrices.FirstOrDefault(a => a.Id == priceLevel.Id);
                    foreach (var hour in priceLevel.Hours)
                    {
                        retVal.EnergyInformation.HourArray[hour] = energyPriceLevel;
                    }
                }
            }
            if (!String.IsNullOrEmpty(usePublicHolidayOverride))
            {
                retVal.EnergyInformationWeekend = GenerateOverrideEnergyPricesData(energyPrice, priceInfo, usePublicHolidayOverride);
            }
            if (!String.IsNullOrEmpty(useWeekendPriceOverride))
            {
                retVal.EnergyInformationWeekend = GenerateOverrideEnergyPricesData( energyPrice, priceInfo, useWeekendPriceOverride);
            }

            return retVal;
        }

        EnergyInformation GenerateOverrideEnergyPricesData(
            Models.V2.PriceStructure.EnergyPrice energyPrice, 
            Models.V2.Digin.PriceInfo priceInfo, string level)
        {
            var retVal = new EnergyInformation();
            retVal.HourArray = new EnergyPrices[Constants.HoursInDay];
            var priceLevelPrice = energyPrice.EnergyPriceLevel.FirstOrDefault(a => a.Level == level);
            var priceLevel = priceInfo.EnergyPrices.FirstOrDefault(a => a.Id == priceLevelPrice.Id);
            if (priceLevel != null)
            {
                for (int hour = 0; hour < Constants.HoursInDay; hour++)
                {
                    retVal.HourArray[hour] = priceLevel;
                }
            }
            return retVal;
        }


        SeasonDataNew ProcessMonth(SeasonDataNew dataAccumulator,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate,
            HourSeasonIndex hourSeasonIndex,
            List<Holiday> holidays,
            int tariffResolutionMinutes)

        {
            var fromDate = paramFromDate;
            while (fromDate.Ticks < paramToDate.Ticks)
            {
                bool isPublicHoliday = holidays.Exists(a => a.Date.Day == fromDate.Day);
                bool isWeekend = fromDate.DayOfWeek == DayOfWeek.Saturday || fromDate.DayOfWeek == DayOfWeek.Sunday;
                var toDate = fromDate.AddDays(1) < paramToDate ? fromDate.AddDays(1) : paramToDate;
                dataAccumulator = ProcessDay(dataAccumulator, fromDate, toDate, hourSeasonIndex, tariffResolutionMinutes, isPublicHoliday, isWeekend);
                fromDate = fromDate.AddDays(1);

            }
            return dataAccumulator;
        }

        SeasonDataNew ProcessDay(SeasonDataNew dataAccumulator
            ,DateTimeOffset paramFromDate
            ,DateTimeOffset paramToDate
            ,HourSeasonIndex hourSeasonIndex
            ,int resolution,
            bool isPublicHoliday,
            bool isWeekend)
        {
            var fromDate = paramFromDate;
            while (fromDate < paramToDate)
            {
                var endDate = fromDate.AddMinutes(resolution);
                EnergyInformation energyInformation = DeciceEneryInformation(hourSeasonIndex, isPublicHoliday, isWeekend);
                var priceData = ToHours(fromDate, endDate, hourSeasonIndex, energyInformation, isPublicHoliday);
                dataAccumulator.TariffPrice.Hours.Add(priceData);
                fromDate = endDate;
            }
            return dataAccumulator;
        }

        private static EnergyInformation DeciceEneryInformation(HourSeasonIndex hourSeasonIndex, bool isPublicHoliday, bool isWeekend)
        {
            EnergyInformation energyInformation;
            if (isPublicHoliday && hourSeasonIndex.EnergyInformationHoliday != null)
            {
                energyInformation = hourSeasonIndex.EnergyInformationHoliday;
            }
            else if (isWeekend && hourSeasonIndex.EnergyInformationWeekend != null)
            {
                energyInformation = hourSeasonIndex.EnergyInformationWeekend;
            }
            else
            {
                energyInformation = hourSeasonIndex.EnergyInformation;
            }
            return energyInformation;
        }

        Models.V2.Digin.Hours ToHours(DateTimeOffset startTime
            , DateTimeOffset expireAt
            , HourSeasonIndex hourSeasonIndex,
            EnergyInformation energyInformation,
            bool isPublicHoliday)
        {
            var retVal = new Models.V2.Digin.Hours();
            retVal.StartTime = startTime;
            retVal.ExpiredAt = expireAt;

            retVal.FixedPrice = new FixedPrice()
            {
                Id = hourSeasonIndex.FixedPriceValue.Id,
                HourId = hourSeasonIndex.FixedPriceValue.IdDaysInMonth
            };

            if (hourSeasonIndex.PowerPriceValue != null)
            {
                retVal.PowerPrice = new PowerPrice()
                {
                    Id = hourSeasonIndex.PowerPriceValue.Id,
                    HourId = hourSeasonIndex.PowerPriceValue.IdDaysInMonth
                };
            }

            retVal.EnergyPrice = new EnergyPrice();
            retVal.EnergyPrice.Id = energyInformation.HourArray[startTime.Hour].Id;
            retVal.EnergyPrice.Total = energyInformation.HourArray[startTime.Hour].Total;
            retVal.EnergyPrice.TotalExVat = energyInformation.HourArray[startTime.Hour].TotalExVat;
            retVal.IsPublicHoliday = isPublicHoliday;
            retVal.ShortName = $"{((startTime.Hour * 100) + startTime.Minute).ToString().PadLeft(4, '0')}-{((expireAt.Hour * 100) + expireAt.Minute).ToString().PadLeft(4, '0')}";
            return retVal;
        }


        SeasonDataNew AddEnergyPrices(
            Models.V2.PriceStructure.EnergyPrice energyPricesPrices,
            List<Models.V2.PriceStructure.EnergyPriceTax> energyPriceTaxes,
            int daysInMonth,
            SeasonDataNew dataAccumulator,
            string season,
            DateTimeOffset fromDate,
            DateTimeOffset toDate)
        {
            if (!dataAccumulator.EnergyPricesDaysInMonthProcessed[daysInMonth])
            {
                AppendEnergyPriceLevels(dataAccumulator.TariffPrice.PriceInfo/*.EnergyPrices.FirstOrDefault()*/, energyPricesPrices, energyPriceTaxes,season, fromDate, toDate);
                dataAccumulator.EnergyPricesDaysInMonthProcessed[daysInMonth] = true;
            }
            return dataAccumulator;
        }


        void AppendEnergyPriceLevels(
            Models.V2.Digin.PriceInfo priceInfo,
            Models.V2.PriceStructure.EnergyPrice energyPricePrices,
            List<Models.V2.PriceStructure.EnergyPriceTax> energyPriceTaxes,
            string season,
            DateTimeOffset fromDate,
            DateTimeOffset toDate)
        {
            foreach (var energyPriceLevelPrice in energyPricePrices.EnergyPriceLevel)
            {
                var energyPriceLevel = priceInfo.EnergyPrices.FirstOrDefault(a => a.Id == energyPriceLevelPrice.Id);
                if (energyPriceLevel == null)
                {
                    energyPriceLevel = PriceLevelEnergyPriceToEnergyPriceLevel(energyPricePrices, energyPriceLevelPrice, energyPriceTaxes, season, fromDate, toDate);
                    priceInfo.EnergyPrices.Add(energyPriceLevel);
                }
            }
        }

        EnergyPrices PriceLevelEnergyPriceToEnergyPriceLevel(
            Models.V2.PriceStructure.EnergyPrice energyPricePrices,
            Models.V2.PriceStructure.EnergyPriceLevel energyPriceLevel,
            List<Models.V2.PriceStructure.EnergyPriceTax> energyPriceTaxes,
            string season,
            DateTimeOffset fromDate,
            DateTimeOffset toDate)
        {
            var retval = new EnergyPrices();

            var vatTax = energyPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");
            var consumptionTax = energyPriceTaxes.FirstOrDefault(x => x.TaxType == "consumptionTax");
            var enovaTax = energyPriceTaxes.FirstOrDefault(x => x.TaxType == "enovaTax");

            var energyExTaxes = CalcVariablePriceEnergyExTaxes(         //todo sjekk med are om beregningene er korrekt, endret siden presizeopt struktur
                energyPriceLevel.Total,
                consumptionTax,
                enovaTax,
                vatTax);

            retval.Id = energyPriceLevel.Id;
            retval.StartDate = fromDate;
            retval.EndDate = toDate;
            retval.Season = season;

            retval.Level = energyPriceLevel.Level;
            retval.Total = energyPriceLevel.Total;
            retval.TotalExVat = energyPriceLevel.Total - CalcTaxes(energyPriceLevel.Total, vatTax.TaxValue);
            retval.EnergyExTaxes = energyExTaxes;
            retval.Taxes = retval.Total - retval.EnergyExTaxes;
            retval.Currency = energyPricePrices.Currency;
            retval.MonetaryUnitOfMeasure = energyPricePrices.MonetaryUnitOfMeasure;

            retval.Total = RoundDouble(retval.Total,Constants.EnergyPriceDecimals);
            retval.TotalExVat = RoundDouble(retval.TotalExVat, Constants.EnergyPriceDecimals);
            retval.EnergyExTaxes = RoundDouble(retval.EnergyExTaxes, Constants.EnergyPriceDecimals);
            retval.Taxes = RoundDouble(retval.Taxes, Constants.EnergyPriceDecimals);
            return retval;
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
            if (!dataAccumulator.PowerPricesDaysInMonthProcessed[daysInMonth] && powerPricePrices != null)
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
            foreach (var powerPricePrice in powerPricePrices.PowerPriceLevel)
            {
                var powerPriceLevel = powerPrices.PriceLevel.FirstOrDefault(a => a.Id == powerPricePrice.Id);
                if (powerPriceLevel == null)
                {
                    powerPriceLevel = PriceLevelPowerPriceToPowerPriceLevel(powerPricePrice, powerPriceTaxes);
                    powerPrices.PriceLevel.Add(powerPriceLevel);
                }
                powerPriceLevel.HourPrices.Add(CalcMonthlyPowerPrices(powerPricePrice, powerPriceTaxes, daysInMonth));
            }
        }

        public Models.V2.Digin.HourPowerPrices CalcMonthlyPowerPrices(
            Models.V2.PriceStructure.PowerPriceLevel powerPriceLevel,
            List<Models.V2.PriceStructure.PowerPriceTax> powerPriceTaxes,
            int daysInMonth)
        {
            var vatTax = powerPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");
            int hoursInMonth = daysInMonth * Constants.HoursInDay;

            var activeTotalExVat = powerPriceLevel.MonthlyActivePowerTotalExVat / hoursInMonth;
            var activeTotal = AddTaxes(activeTotalExVat, vatTax.TaxValue);
            var reactiveTotalExVat = powerPriceLevel.MonthlyReactivePowerTotalExVat / hoursInMonth;
            var reactiveTotal = AddTaxes(reactiveTotalExVat, vatTax.TaxValue);

            var retVal = new Models.V2.Digin.HourPowerPrices();
            retVal.Id = Guid.NewGuid().ToString();
            retVal.NumberOfDaysInMonth = daysInMonth;
            retVal.ActiveTotal = RoundDouble(activeTotal,Constants.PowerPriceDecimals);
            retVal.ActiveTotalExVat = RoundDouble(activeTotalExVat, Constants.PowerPriceDecimals);
            retVal.ReactiveTotal = RoundDouble(reactiveTotal, Constants.PowerPriceDecimals);
            retVal.ReactiveTotalExVat = RoundDouble(reactiveTotalExVat, Constants.PowerPriceDecimals);
            return retVal;
        }



        PowerPriceLevel PriceLevelPowerPriceToPowerPriceLevel(
            Models.V2.PriceStructure.PowerPriceLevel powerPriceLevel,
            List<Models.V2.PriceStructure.PowerPriceTax> powerPriceTaxes)
        {
            var retVal = new Models.V2.Digin.PowerPriceLevel();
            var vatTax = powerPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");

            retVal.Id = powerPriceLevel.Id;
            retVal.ValueMin = powerPriceLevel.ValueMin;
            retVal.ValueMax = powerPriceLevel.ValueMax;
            retVal.NextIdDown = powerPriceLevel.NextIdDown;
            retVal.NextIdUp = powerPriceLevel.NextIdUp;
            retVal.ValueUnitOfMeasure = powerPriceLevel.ValueUnitOfMeasure;
            retVal.MonthlyActivePowerTotalExVat = powerPriceLevel.MonthlyActivePowerTotalExVat;
            retVal.MonthlyActivePowerTotal = AddTaxes(retVal.MonthlyActivePowerTotalExVat, vatTax.TaxValue);
            retVal.MonthlyActivePowerExTaxes = retVal.MonthlyActivePowerTotalExVat;
            retVal.MonthlyActivePowerTaxes = retVal.MonthlyActivePowerTotal - retVal.MonthlyActivePowerTotalExVat;
            retVal.MonthlyReactivePowerTotalExVat = powerPriceLevel.MonthlyReactivePowerTotalExVat;
            retVal.MonthlyReactivePowerTotal = AddTaxes(retVal.MonthlyReactivePowerTotalExVat, vatTax.TaxValue);
            retVal.MonthlyReactivePowerExTaxes = powerPriceLevel.MonthlyReactivePowerTotalExVat;
            retVal.MonthlyReactivePowerTaxes = retVal.MonthlyReactivePowerTotal - retVal.MonthlyReactivePowerTotalExVat;
            retVal.MonthlyUnitOfMeasure = powerPriceLevel.MonthlyUnitOfMeasure;
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

            retVal.Id = priceLevel.Id;
            retVal.ValueMin = priceLevel.ValueMin;
            retVal.ValueMax = priceLevel.ValueMax;
            retVal.NextIdDown = priceLevel.NextIdDown;
            retVal.NextIdUp = priceLevel.NextIdUp;
            retVal.ValueUnitOfMeasure = priceLevel.ValueUnitOfMeasure;
            retVal.MonthlyTotal = AddTaxes(priceLevel.MonthlyTotalExVat, vatTax.TaxValue);
            retVal.MonthlyTotalExVat = priceLevel.MonthlyTotalExVat;
            retVal.MonthlyExTaxes = retVal.MonthlyTotalExVat;
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

        public Models.V2.Digin.GridTariff ToGridTariff(
            Models.V2.PriceStructure.Company company, 
            Models.V2.PriceStructure.TariffType tariffType)
        {
            var retVal = new Models.V2.Digin.GridTariff();
            retVal.TariffType = _objectConversionHelper.ToTariffType(company,tariffType);
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

        public double AddTaxes(double input, double vat)
        {
            return input + (input * (vat/100));
        }

        public double CalcVariablePriceEnergyExTaxes(double total, Models.V2.PriceStructure.EnergyPriceTax consumptionTax, Models.V2.PriceStructure.EnergyPriceTax enovaTax, Models.V2.PriceStructure.EnergyPriceTax vatTax)
        {
            double consTax = consumptionTax != null ? consumptionTax.TaxValue : 0;
            double enoTax = enovaTax != null ? enovaTax.TaxValue : 0;
            double vatTaxes = vatTax != null ? vatTax.TaxValue : 0;

            double retVal = total - CalcTaxes(total, vatTaxes) - consTax - enoTax;
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
