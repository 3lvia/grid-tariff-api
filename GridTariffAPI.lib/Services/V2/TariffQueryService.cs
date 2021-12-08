using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.V2.Digin;
using GridTariffApi.Lib.Models.V2.Holidays;
using GridTariffApi.Lib.Services.Helpers;
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
        private readonly IServiceHelper _serviceHelper;
        public TariffQueryService(
            ITariffPriceCache tariffPriceCache,
            IObjectConversionHelper objectConversionHelper,
            IServiceHelper serviceHelper)
        {
            _tariffPriceCache = tariffPriceCache;
            _objectConversionHelper = objectConversionHelper;
            _serviceHelper = serviceHelper;
        }

        public async Task<GridTariffCollection> QueryTariffAsync(
            string tariffKey, 
            DateTimeOffset paramFromDate, 
            DateTimeOffset paramToDate)
        {
            var tariff = _tariffPriceCache.GetTariff(tariffKey);
            var tariffPrices = tariff.TariffPrices.ToList();
            tariffPrices.RemoveAll(x => x.EndDate <= paramFromDate || x.StartDate > paramToDate);
            var company = _tariffPriceCache.GetCompany();

            var gridTariffCollection = new GridTariffCollection();
            gridTariffCollection.GridTariff = ToGridTariff(company, tariff);
            var tariffPrice = ProcessTariffPrices(tariff, tariffPrices, paramFromDate, paramToDate);
            gridTariffCollection.GridTariff.TariffPrice = tariffPrice;
            await Task.CompletedTask;
            return gridTariffCollection;
        }

        public Models.V2.Digin.TariffPrice ProcessTariffPrices(
            Models.V2.PriceStructure.TariffType tariffType,
            List<Models.V2.PriceStructure.TariffPrice> tariffPrices,
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
            foreach (var tariffPricePrice in tariffPrices)
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
            var startDate = tariffPricePrice.StartDate <= paramFromDate ? paramFromDate : tariffPricePrice.StartDate.UtcDateTime;
            var endDate = tariffPricePrice.EndDate >= paramToDate ? paramToDate : tariffPricePrice.EndDate.UtcDateTime;
            var filteredHolidays = holidays.Where(a => a.Date >= startDate && a.Date <= endDate).ToList();
            var taxTimePeriods = SegmentByChangingTaxes(tariffPricePrice.Taxes, startDate, endDate);
            foreach (var taxTimePeriod in taxTimePeriods)
            {
                foreach (var season in tariffPricePrice.Seasons)
                {
                    var seasonIntersect = CalcSeasonIntersect(taxTimePeriod.StartDate, taxTimePeriod.EndDate, season.Months);
                    if (seasonIntersect != null)
                    {
                        var accumulator = InitAccumulator(tariffPricePrice,
                            seasonIntersect.StartDate,
                            seasonIntersect.EndDate);

                        accumulator = ProcessSeason(accumulator,
                            season,
                            seasonIntersect.StartDate,
                            seasonIntersect.EndDate,
                            filteredHolidays,
                            tariffType);

                            tariffPrice.PriceInfo.FixedPrices.AddRange(accumulator.TariffPrice.PriceInfo.FixedPrices);
                            tariffPrice.PriceInfo.PowerPrices.AddRange(accumulator.TariffPrice.PriceInfo.PowerPrices);
                            tariffPrice.PriceInfo.EnergyPrices.AddRange(accumulator.TariffPrice.PriceInfo.EnergyPrices);
                            tariffPrice.Hours.AddRange(accumulator.TariffPrice.Hours);
                    }
                }
            }
        }

        TimePeriod CalcSeasonIntersect(DateTimeOffset fromDate, DateTimeOffset toDate, IReadOnlyList<int> months)
        {
            var fromDateLocaled = _serviceHelper.GetTimeZonedDateTimeOffset(fromDate);
            int? startMonth = months.OrderBy(x => x).FirstOrDefault(x => x >= fromDateLocaled.Month);
            if (startMonth.HasValue && startMonth.Value > 0)
            {
//calc season start
                if (fromDateLocaled.Month != startMonth.Value)
                {
                    fromDateLocaled = fromDateLocaled.AddMonths(startMonth.Value - fromDateLocaled.Month);
                    fromDateLocaled = fromDateLocaled.AddDays(1 - fromDateLocaled.Day);
                }
                var seasonStart = fromDate.AddTicks(fromDateLocaled.ToUniversalTime().Ticks - fromDate.Ticks);
//calc season end
                fromDateLocaled = fromDateLocaled.AddMonths(1);
                while (months.Count(x => x == fromDateLocaled.Month) == 1)
                {
                    fromDateLocaled = fromDateLocaled.AddMonths(1);
                }
                fromDateLocaled = fromDateLocaled.AddDays(1 - fromDateLocaled.Day);
                var seasonEnd = fromDate.AddTicks(fromDateLocaled.ToUniversalTime().Ticks - fromDate.Ticks);

//return if intersection with fromdate/todate
                if (!((seasonStart > toDate) || (seasonEnd < fromDate)))
                {
                    return new TimePeriod()
                    {
                        StartDate = seasonStart > fromDate ? seasonStart: fromDate,
                        EndDate = seasonEnd < toDate ? seasonEnd : toDate
                    };
                }
            }
            return null;
        }

        SeasonDataAccumulator InitAccumulator(Models.V2.PriceStructure.TariffPrice tariffPrice, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            var retVal = new SeasonDataAccumulator();
            retVal.Taxes.FixedPriceTaxes = FilterByDate(tariffPrice.Taxes.FixedPriceTaxes, fromDate, toDate);
            retVal.Taxes.PowerPriceTaxes = FilterByDate(tariffPrice.Taxes.PowerPriceTaxes, fromDate, toDate);
            retVal.Taxes.EnergyPriceTaxes = FilterByDate(tariffPrice.Taxes.EnergyPriceTaxes, fromDate, toDate);
            return retVal;
        }

        List<TimePeriod> SegmentByChangingTaxes(Models.V2.PriceStructure.Taxes taxes, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var retVal = new List<TimePeriod>();
            var dates = new List<DateTimeOffset>();
            dates.Add(startDate);
            dates.Add(endDate);

            if (taxes.EnergyPriceTaxes != null)
            {
                dates.AddRange(taxes.EnergyPriceTaxes.Select(a => a.StartDate));
            }
            if (taxes.PowerPriceTaxes != null)
            {
                dates.AddRange(taxes.PowerPriceTaxes.Select(a => a.StartDate));
            }
            if (taxes.FixedPriceTaxes != null)
            {
                dates.AddRange(taxes.FixedPriceTaxes.Select(a => a.StartDate));
            }
            dates.RemoveAll(a => a < startDate || a > endDate);
            dates = dates.Distinct().OrderBy(a => a).ToList();
            for (int i = 0; i < dates.Count-1;i++)
            {
                retVal.Add(new TimePeriod() { StartDate = dates[i], EndDate = dates[i + 1] });
            }
            return retVal;
        }

        SeasonDataAccumulator ProcessSeason(SeasonDataAccumulator dataAccumulator,
            Models.V2.PriceStructure.Season season,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate,
            List<Holiday> holidays,
            Models.V2.PriceStructure.TariffType tariffType)
        {

            if (season.FixedPrices != null)
            {
                var fixedPrice = new FixedPrices {
                        Id = Guid.NewGuid().ToString(),
                        StartDate = _serviceHelper.DbTimeZoneDateToUtc(paramFromDate.DateTime),
                        EndDate = _serviceHelper.DbTimeZoneDateToUtc(paramToDate.DateTime),
                        PriceLevel = new List<FixedPriceLevel>() };
                dataAccumulator.TariffPrice.PriceInfo.FixedPrices.Add(fixedPrice);
            }
            if (season.PowerPrices != null)
            {
                var powerPrice = new PowerPrices
                {
                    Id = Guid.NewGuid().ToString(),
                    StartDate = _serviceHelper.DbTimeZoneDateToUtc(paramFromDate.DateTime),
                    EndDate = _serviceHelper.DbTimeZoneDateToUtc(paramToDate.DateTime),
                    PriceLevel = new List<PowerPriceLevel>()
                };
                dataAccumulator.TariffPrice.PriceInfo.PowerPrices.Add(powerPrice);
            }

            var fromDate = paramFromDate;
            while (fromDate < paramToDate)
            {
                var currMonthEndToDate = GetNextMonthEndDate(fromDate, paramToDate);
                var fromDateLocaled = _serviceHelper.GetTimeZonedDateTime(fromDate.UtcDateTime);
                if (season.Months.Contains(fromDateLocaled.Month))
                {
                    var daysInMonth = DateTime.DaysInMonth(fromDateLocaled.Year, fromDateLocaled.Month);
                    dataAccumulator = AddPriceLevels(dataAccumulator, season, paramFromDate, paramToDate, daysInMonth);
                    var hourSeasonIndex = BuildHourSeasonIndex(dataAccumulator.TariffPrice.PriceInfo, season.EnergyPrice, daysInMonth, tariffType.UsePublicHolidayOverride, tariffType.UseWeekendPriceOverride);

                    var filteredHolidays = holidays.Where(a => a.Date >= fromDate && a.Date <= currMonthEndToDate).ToList();
                    dataAccumulator = ProcessMonth(dataAccumulator, fromDate, currMonthEndToDate, hourSeasonIndex, filteredHolidays, tariffType.Resolution);
                }
                fromDate = currMonthEndToDate;
            }
            return dataAccumulator;
        }


        private SeasonDataAccumulator AddPriceLevels(SeasonDataAccumulator dataAccumulator, Models.V2.PriceStructure.Season season, DateTimeOffset paramFromDate, DateTimeOffset paramToDate, int daysInMonth)
        {
            dataAccumulator = AddFixedPrices(season.FixedPrices,daysInMonth,dataAccumulator);
            dataAccumulator = AddPowerPrices(season.PowerPrices,daysInMonth,dataAccumulator);
            dataAccumulator = AddEnergyPrices(season.EnergyPrice,dataAccumulator,season.Name,paramFromDate,paramToDate);
            return dataAccumulator;
        }

        IReadOnlyList<Models.V2.PriceStructure.FixedPriceTax> FilterByDate(IReadOnlyList<Models.V2.PriceStructure.FixedPriceTax> taxes, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            if (taxes != null)
            {
                return taxes.Where(a => a.StartDate < toDate && a.EndDate >= fromDate).ToList();
            }
            return taxes;
        }

        IReadOnlyList<Models.V2.PriceStructure.PowerPriceTax> FilterByDate(IReadOnlyList<Models.V2.PriceStructure.PowerPriceTax> taxes, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            if (taxes != null)
            {
                return taxes.Where(a => a.StartDate < toDate && a.EndDate >= fromDate).ToList();
            }
            return taxes;
        }
        IReadOnlyList<Models.V2.PriceStructure.EnergyPriceTax> FilterByDate(IReadOnlyList<Models.V2.PriceStructure.EnergyPriceTax> taxes, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            if (taxes != null)
            {
                return taxes.Where(a => a.StartDate < toDate && a.EndDate >= fromDate).ToList();
            }
            return taxes;
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
                    var energyPriceLevel = priceInfo.EnergyPrices.FirstOrDefault(a => a.Level == priceLevel.Level);
                    foreach (var hour in priceLevel.Hours)
                    {
                        retVal.EnergyInformation.HourArray[hour] = energyPriceLevel;
                    }
                }
            }
            if (!String.IsNullOrEmpty(usePublicHolidayOverride))
            {
                retVal.EnergyInformationHoliday = GenerateOverrideEnergyPricesData(energyPrice, priceInfo, usePublicHolidayOverride);
            }
            if (!String.IsNullOrEmpty(useWeekendPriceOverride))
            {
                retVal.EnergyInformationWeekend = GenerateOverrideEnergyPricesData(energyPrice, priceInfo, useWeekendPriceOverride);
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
            var priceLevel = priceInfo.EnergyPrices.FirstOrDefault();
            if (priceLevel != null)
            {
                for (int hour = 0; hour < Constants.HoursInDay; hour++)
                {
                    retVal.HourArray[hour] = priceLevel;
                }
            }
            return retVal;
        }


        SeasonDataAccumulator ProcessMonth(SeasonDataAccumulator dataAccumulator,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate,
            HourSeasonIndex hourSeasonIndex,
            List<Holiday> holidays,
            int tariffResolutionMinutes)

        {
            var fromDate = paramFromDate;
            while (fromDate.Ticks < paramToDate.Ticks)
            {
                bool isPublicHoliday = holidays.Exists(a => a.Date.Date == _serviceHelper.GetTimeZonedDateTime(fromDate.UtcDateTime).Date);
                bool isWeekend = fromDate.DayOfWeek == DayOfWeek.Saturday || fromDate.DayOfWeek == DayOfWeek.Sunday;
                var toDate = fromDate.AddDays(1) < paramToDate ? fromDate.AddDays(1) : paramToDate;
                dataAccumulator = ProcessDay(dataAccumulator, fromDate, toDate, hourSeasonIndex, tariffResolutionMinutes, isPublicHoliday, isWeekend);
                fromDate = fromDate.AddDays(1);

            }
            return dataAccumulator;
        }

        SeasonDataAccumulator ProcessDay(SeasonDataAccumulator dataAccumulator
            ,DateTimeOffset paramFromDate
            ,DateTimeOffset paramToDate
            ,HourSeasonIndex hourSeasonIndex
            ,int resolution,
            bool isPublicHoliday,
            bool isWeekend)
        {
            var fromDate = paramFromDate;
            var endDate = fromDate;
            while (endDate < paramToDate)
            {
                endDate = fromDate.AddMinutes(resolution);
                EnergyInformation energyInformation = DeciceEneryInformation(hourSeasonIndex, isPublicHoliday, isWeekend);
                var priceData = ToHour(fromDate, endDate, hourSeasonIndex, energyInformation, isPublicHoliday);
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

        Models.V2.Digin.Hours ToHour(DateTimeOffset startTime
            , DateTimeOffset expireAt
            , HourSeasonIndex hourSeasonIndex,
            EnergyInformation energyInformation,
            bool isPublicHoliday)
        {
            var retVal = new Models.V2.Digin.Hours();
            var localedHour = _serviceHelper.GetTimeZonedDateTimeOffset(startTime).Hour;

            retVal.StartTime = _serviceHelper.DbTimeZoneDateToUtc(startTime.DateTime);
            retVal.ExpiredAt = _serviceHelper.DbTimeZoneDateToUtc(expireAt.DateTime);
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
            retVal.EnergyPrice.Id = energyInformation.HourArray[localedHour].Id;
            retVal.EnergyPrice.Total = energyInformation.HourArray[localedHour].Total;
            retVal.EnergyPrice.TotalExVat = energyInformation.HourArray[localedHour].TotalExVat;
            retVal.IsPublicHoliday = isPublicHoliday;

            var startTimeLocaled = _serviceHelper.GetTimeZonedDateTimeOffset(retVal.StartTime.DateTime);
            var expireAtLocaled = _serviceHelper.GetTimeZonedDateTimeOffset(retVal.ExpiredAt.DateTime);

            retVal.ShortName = $"{((startTimeLocaled.Hour * 100) + startTimeLocaled.Minute).ToString().PadLeft(4, '0')}-{((expireAtLocaled.Hour * 100) + expireAtLocaled.Minute).ToString().PadLeft(4, '0')}";
            return retVal;
        }


        SeasonDataAccumulator AddEnergyPrices(
            Models.V2.PriceStructure.EnergyPrice energyPricesPrices,
            SeasonDataAccumulator dataAccumulator,
            string season,
            DateTimeOffset fromDate,
            DateTimeOffset toDate)
        {
            if (dataAccumulator.TariffPrice.PriceInfo.EnergyPrices.Count == 0)
            {
                AppendEnergyPriceLevels(dataAccumulator.TariffPrice.PriceInfo, energyPricesPrices, dataAccumulator.Taxes.EnergyPriceTaxes, season, fromDate, toDate);
            }
            return dataAccumulator;
        }


        void AppendEnergyPriceLevels(
            Models.V2.Digin.PriceInfo priceInfo,
            Models.V2.PriceStructure.EnergyPrice energyPricePrices,
            IReadOnlyList<Models.V2.PriceStructure.EnergyPriceTax> energyPriceTaxes,
            string season,
            DateTimeOffset fromDate,
            DateTimeOffset toDate)
        {
            foreach (var energyPriceLevelPrice in energyPricePrices.EnergyPriceLevel)
            {
                var energyPriceLevel = priceInfo.EnergyPrices.FirstOrDefault(a => a.Id == energyPriceLevelPrice.Id);
                if (energyPriceLevel == null)
                {
                    energyPriceLevel = PriceLevelEnergyPriceToEnergyPriceLevel(energyPricePrices,
                        energyPriceLevelPrice,
                        energyPriceTaxes,
                        season,
                        fromDate,
                        toDate); ;
                    priceInfo.EnergyPrices.Add(energyPriceLevel);
                }
            }
        }


        EnergyPrices PriceLevelEnergyPriceToEnergyPriceLevel(
            Models.V2.PriceStructure.EnergyPrice energyPricePrices,
            Models.V2.PriceStructure.EnergyPriceLevel energyPriceLevel,
            IReadOnlyList<Models.V2.PriceStructure.EnergyPriceTax> energyPriceTaxes,
            string season,
            DateTimeOffset fromDate,
            DateTimeOffset toDate)
        {
            //todo refactor for unittestability
            var retval = new EnergyPrices();

            var vatTax = energyPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");
            var consumptionTax = energyPriceTaxes.FirstOrDefault(x => x.TaxType == "consumptionTax");
            var enovaTax = energyPriceTaxes.FirstOrDefault(x => x.TaxType == "enovaTax");

            var vatTaxValue = vatTax != null ? vatTax.TaxValue : 0;
            var consumptionTaxValue = consumptionTax != null ? consumptionTax.TaxValue : 0;
            var enovaTaxValue = enovaTax != null ? enovaTax.TaxValue : 0;

            retval.Id = Guid.NewGuid().ToString();
            retval.StartDate = _serviceHelper.DbTimeZoneDateToUtc(fromDate.DateTime);
            retval.EndDate = _serviceHelper.DbTimeZoneDateToUtc(toDate.DateTime);
            retval.Season = season;

            retval.Level = energyPriceLevel.Level;

            retval.EnergyExTaxes = energyPriceLevel.EnergyExTaxes;
            retval.TotalExVat = energyPriceLevel.EnergyExTaxes + consumptionTaxValue + enovaTaxValue;
            retval.Total = retval.TotalExVat + CalcTaxes(retval.TotalExVat, vatTaxValue);
            retval.Taxes = retval.Total - retval.TotalExVat;

            retval.Currency = energyPricePrices.Currency;
            retval.MonetaryUnitOfMeasure = energyPricePrices.MonetaryUnitOfMeasure;

            retval.Total = RoundDouble(retval.Total,Constants.EnergyPriceDecimals);
            retval.TotalExVat = RoundDouble(retval.TotalExVat, Constants.EnergyPriceDecimals);
            retval.EnergyExTaxes = RoundDouble(retval.EnergyExTaxes, Constants.EnergyPriceDecimals);
            retval.Taxes = RoundDouble(retval.Taxes, Constants.EnergyPriceDecimals);
            return retval;
        }



        SeasonDataAccumulator AddFixedPrices(
            Models.V2.PriceStructure.FixedPrices fixedPricesPrices,
            int daysInMonth,
            SeasonDataAccumulator dataAccumulator)
        {
            if (!dataAccumulator.FixedPricesDaysInMonthProcessed[daysInMonth])
            {
                AppendFixedPriceLevels(dataAccumulator.TariffPrice.PriceInfo.FixedPrices.FirstOrDefault(), 
                    fixedPricesPrices, dataAccumulator.Taxes.FixedPriceTaxes, 
                    daysInMonth);
                dataAccumulator.FixedPricesDaysInMonthProcessed[daysInMonth] = true;
            }
            return dataAccumulator;
        }


        SeasonDataAccumulator AddPowerPrices(
            Models.V2.PriceStructure.PowerPrices powerPricePrices,
            int daysInMonth,
            SeasonDataAccumulator dataAccumulator)
        {
            if (!dataAccumulator.PowerPricesDaysInMonthProcessed[daysInMonth] && powerPricePrices != null)
            {
                AppendPowerPriceLevels(
                    dataAccumulator.TariffPrice.PriceInfo.PowerPrices.FirstOrDefault(), 
                    powerPricePrices, 
                    dataAccumulator.Taxes.PowerPriceTaxes, 
                    daysInMonth);
                dataAccumulator.PowerPricesDaysInMonthProcessed[daysInMonth] = true;
            }
            return dataAccumulator;
        }

        void AppendPowerPriceLevels(
            Models.V2.Digin.PowerPrices powerPrices,
            Models.V2.PriceStructure.PowerPrices powerPricePrices,
            IReadOnlyList<Models.V2.PriceStructure.PowerPriceTax> powerPriceTaxes,
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
            IReadOnlyList<Models.V2.PriceStructure.PowerPriceTax> powerPriceTaxes,
            int daysInMonth)
        {
            var vatTax = powerPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");
            int hoursInMonth = daysInMonth * Constants.HoursInDay;

            var activeTotalExVat = powerPriceLevel.MonthlyActivePowerExTaxes / hoursInMonth;
            var activeTotal = AddTaxes(activeTotalExVat, vatTax.TaxValue);
            var reactiveTotalExVat = powerPriceLevel.MonthlyReactivePowerExTaxes / hoursInMonth;
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
            IReadOnlyList<Models.V2.PriceStructure.PowerPriceTax> powerPriceTaxes)
        {
            var retVal = new Models.V2.Digin.PowerPriceLevel();
            retVal.Id = powerPriceLevel.Id;
            retVal.ValueMin = powerPriceLevel.ValueMin;
            retVal.ValueMax = powerPriceLevel.ValueMax;
            retVal.NextIdDown = powerPriceLevel.NextIdDown;
            retVal.NextIdUp = powerPriceLevel.NextIdUp;
            retVal.ValueUnitOfMeasure = powerPriceLevel.ValueUnitOfMeasure;
            CalcPowerPriceLevelValues(retVal, powerPriceLevel, powerPriceTaxes);
            retVal.MonthlyUnitOfMeasure = powerPriceLevel.MonthlyUnitOfMeasure;
            retVal.HourPrices = new List<HourPowerPrices>();
            retVal.LevelInfo = powerPriceLevel.LevelInfo;
            retVal.Currency = powerPriceLevel.Currency;
            retVal.MonetaryUnitOfMeasure = powerPriceLevel.MonetaryUnitOfMeasure;
            return retVal;
        }

        void CalcPowerPriceLevelValues(Models.V2.Digin.PowerPriceLevel powerPriceLevel, Models.V2.PriceStructure.PowerPriceLevel powerPriceLevelPrice, IReadOnlyList<Models.V2.PriceStructure.PowerPriceTax> powerPriceTaxes)
        {
            var vatTax = powerPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");
            powerPriceLevel.MonthlyActivePowerExTaxes = powerPriceLevelPrice.MonthlyActivePowerExTaxes;
            powerPriceLevel.MonthlyActivePowerTotalExVat = powerPriceLevelPrice.MonthlyActivePowerExTaxes;
            powerPriceLevel.MonthlyActivePowerTotal = AddTaxes(powerPriceLevel.MonthlyActivePowerExTaxes, vatTax.TaxValue);
            powerPriceLevel.MonthlyActivePowerTaxes = powerPriceLevel.MonthlyActivePowerTotal - powerPriceLevel.MonthlyActivePowerTotalExVat;

            powerPriceLevel.MonthlyReactivePowerExTaxes = powerPriceLevelPrice.MonthlyReactivePowerExTaxes;
            powerPriceLevel.MonthlyReactivePowerTotalExVat = powerPriceLevelPrice.MonthlyReactivePowerExTaxes;
            powerPriceLevel.MonthlyReactivePowerTotal = AddTaxes(powerPriceLevel.MonthlyReactivePowerExTaxes, vatTax.TaxValue);
            powerPriceLevel.MonthlyReactivePowerTotalExVat = powerPriceLevel.MonthlyReactivePowerTotal - powerPriceLevel.MonthlyReactivePowerTotalExVat;

            powerPriceLevel.MonthlyActivePowerExTaxes = RoundDouble(powerPriceLevel.MonthlyActivePowerExTaxes, Constants.PowerPriceDecimals);
            powerPriceLevel.MonthlyActivePowerTotalExVat = RoundDouble(powerPriceLevel.MonthlyActivePowerTotalExVat, Constants.PowerPriceDecimals);
            powerPriceLevel.MonthlyActivePowerTotal = RoundDouble(powerPriceLevel.MonthlyActivePowerTotal, Constants.PowerPriceDecimals);
            powerPriceLevel.MonthlyActivePowerTaxes = RoundDouble(powerPriceLevel.MonthlyActivePowerTaxes, Constants.PowerPriceDecimals);

            powerPriceLevel.MonthlyReactivePowerExTaxes = RoundDouble(powerPriceLevel.MonthlyReactivePowerExTaxes, Constants.PowerPriceDecimals);
            powerPriceLevel.MonthlyReactivePowerTotalExVat = RoundDouble(powerPriceLevel.MonthlyReactivePowerTotalExVat, Constants.PowerPriceDecimals);
            powerPriceLevel.MonthlyReactivePowerTotal = RoundDouble(powerPriceLevel.MonthlyReactivePowerTotal, Constants.PowerPriceDecimals);
            powerPriceLevel.MonthlyReactivePowerTotalExVat = RoundDouble(powerPriceLevel.MonthlyReactivePowerTotalExVat, Constants.PowerPriceDecimals);
        }

        void AppendFixedPriceLevels(
            Models.V2.Digin.FixedPrices fixedPrices,
            Models.V2.PriceStructure.FixedPrices fixedPricesPrices,
            IReadOnlyList<Models.V2.PriceStructure.FixedPriceTax> fixedPriceTaxes,
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

        FixedPriceLevel PriceLevelPriceToFixedPriceLevel(
            Models.V2.PriceStructure.FixedPriceLevel priceLevel,
            IReadOnlyList<Models.V2.PriceStructure.FixedPriceTax> fixedPriceTaxes)
        {
            var retVal = new Models.V2.Digin.FixedPriceLevel();
            var vatTax = fixedPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");

            retVal.Id = priceLevel.Id;
            retVal.ValueMin = priceLevel.ValueMin;
            retVal.ValueMax = priceLevel.ValueMax;
            retVal.NextIdDown = priceLevel.NextIdDown;
            retVal.NextIdUp = priceLevel.NextIdUp;
            retVal.ValueUnitOfMeasure = priceLevel.ValueUnitOfMeasure;
            retVal.MonthlyExTaxes = priceLevel.MonthlyFixedExTaxes;
            retVal.MonthlyTotal = AddTaxes(priceLevel.MonthlyFixedExTaxes, vatTax.TaxValue);
            retVal.MonthlyTotalExVat = priceLevel.MonthlyFixedExTaxes;
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
            IReadOnlyList<Models.V2.PriceStructure.FixedPriceTax> fixedPriceTaxes,
            int daysInMonth)
        {
            var vatTax = fixedPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");
            int hoursInMonth = daysInMonth * Constants.HoursInDay;
            var totalExVatPerHour = fixedPricePriceLevel.MonthlyFixedExTaxes / hoursInMonth;

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
            var localedFromDate = new DateTimeOffset(_serviceHelper.GetTimeZonedDateTime(fromDate.UtcDateTime));
            var monthEndDate = localedFromDate.AddMonths(1);
            monthEndDate = new DateTimeOffset(monthEndDate.Year, monthEndDate.Month, 1, 0, 0, 0, monthEndDate.Offset).UtcDateTime;
            if (monthEndDate < toDate)
            {
                return monthEndDate;
            }
            return toDate;
        }
    }
}
