using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.Digin;
using GridTariffApi.Lib.Models.Holidays;
using GridTariffApi.Lib.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.Lib.Services
{
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

        public async Task<TariffQueryRequestMeteringPointsResult> QueryMeteringPointsTariffsAsync(
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate,
            List<String> meteringPoints)
        {
            var retVal = new TariffQueryRequestMeteringPointsResult
            {
                GridTariffCollections = new List<GridTariffCollection>()
            };
            var meteringPointsInformations = _tariffPriceCache.GetMeteringPointInformation(meteringPoints);
            var tariffKeys = meteringPointsInformations.Select(x => x.TariffKey).Distinct();
            foreach (var tariffKey in tariffKeys)
            {
                var gridTariffMeteringPoints = meteringPointsInformations.Where(x => x.TariffKey == tariffKey).ToList();
                var gridTariff = await GenerateTariffAndAppendMeteringPoints(tariffKey, paramFromDate, paramToDate, gridTariffMeteringPoints);
                retVal.GridTariffCollections.Add(gridTariff);
            }
            return retVal;
        }

        public virtual async Task<GridTariffCollection> GenerateTariffAndAppendMeteringPoints(string tariffKey,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate,
            List<MeteringPointInformation> meteringPointInformation)
        {
            var gridTariff = await QueryTariffAsync(tariffKey, paramFromDate, paramToDate);
            gridTariff.MeteringPointsAndPriceLevels = new List<MeteringPointsAndPriceLevels>();

            AppendMeteringPointsToPriceLevels(meteringPointInformation, gridTariff);
            return gridTariff;
        }

        public virtual void AppendMeteringPointsToPriceLevels(List<MeteringPointInformation> meteringPointInformation, GridTariffCollection gridTariff)
        {
            //todo should be some of filtering here (only current month?), thus no need for foreach fixedprices
            foreach (var fixedPrice in gridTariff.GridTariff.TariffPrice.PriceInfo.FixedPrices)
            {
                foreach (var fixedPriceLevel in fixedPrice.PriceLevel)
                {
                    var meteringPointAndPriceLevel = CheckPriceLevelForMeteringPoints(meteringPointInformation, fixedPrice, fixedPriceLevel);
                    if (meteringPointAndPriceLevel != null)
                    {
                        gridTariff.MeteringPointsAndPriceLevels.Add(meteringPointAndPriceLevel);
                    }
                }
            }
        }

        public MeteringPointsAndPriceLevels CheckPriceLevelForMeteringPoints(List<MeteringPointInformation> meteringPointInformation, FixedPrices fixedPrice, FixedPriceLevel fixedPriceLevel)
        {
            MeteringPointsAndPriceLevels retVal = null;

            var minVal = fixedPriceLevel.ValueMin ?? double.MinValue;
            var maxVal = fixedPriceLevel.ValueMax ?? double.MaxValue;

            var mpInformations = meteringPointInformation.Where(x => minVal <= x.MaxConsumption && x.MaxConsumption < maxVal).ToList();
            if (mpInformations.Count > 0)
            {
                retVal = MeteringPointsToPriceLevel(fixedPrice, fixedPriceLevel, mpInformations);
            }
            return retVal;
        }

        public MeteringPointsAndPriceLevels MeteringPointsToPriceLevel(FixedPrices fixedPrice, FixedPriceLevel fixedPriceLevel, List<MeteringPointInformation> mpInformations)
        {
            var meteringPointAndPriceLevel = new MeteringPointsAndPriceLevels()
            {
                CurrentFixedPriceLevel = new CurrentFixedPriceLevel(),
                MeteringPointIds = new MeteringPointIds()
            };

            foreach (var mpInformation in mpInformations)
            {
                meteringPointAndPriceLevel.MeteringPointIds.Add(mpInformation.MeteringPointId);
            }
            meteringPointAndPriceLevel.CurrentFixedPriceLevel.Id = fixedPrice.Id;
            meteringPointAndPriceLevel.CurrentFixedPriceLevel.LevelId = fixedPriceLevel.Id;
            meteringPointAndPriceLevel.CurrentFixedPriceLevel.LevelValue = null;
            //TODO LastUpdated should be set per meteringpoint. Change needed in DIGIN.
            //            meteringPointAndPriceLevel.CurrentFixedPriceLevel.LastUpdated
            return meteringPointAndPriceLevel;
        }

        public virtual async Task<GridTariffCollection> QueryTariffAsync(
            string tariffKey,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate)
        {
            var tariff = _tariffPriceCache.GetTariff(tariffKey);
            var tariffPrices = tariff.TariffPrices.ToList();
            tariffPrices.RemoveAll(x => x.EndDate <= paramFromDate || x.StartDate > paramToDate);
            var company = _tariffPriceCache.GetCompany();

            var gridTariffCollection = new GridTariffCollection
            {
                GridTariff = ToGridTariff(company, tariff)
            };
            gridTariffCollection.GridTariff.TariffType.LastUpdated = tariff.LastUpdated;
            var tariffPrice = ProcessTariffPrices(tariff, tariffPrices, paramFromDate, paramToDate);
            gridTariffCollection.GridTariff.TariffPrice = tariffPrice;
            await Task.CompletedTask;
            return gridTariffCollection;
        }

        public Models.Digin.TariffPrice ProcessTariffPrices(
            Models.PriceStructure.TariffType tariffType,
            List<Models.PriceStructure.TariffPrice> tariffPrices,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate)
        {
            var tariffPrice = new Models.Digin.TariffPrice
            {
                PriceInfo = new Models.Digin.PriceInfo()
            };
            tariffPrice.PriceInfo.FixedPrices = new List<Models.Digin.FixedPrices>();
            tariffPrice.PriceInfo.PowerPrices = new List<Models.Digin.PowerPrices>();
            tariffPrice.PriceInfo.EnergyPrices = new List<Models.Digin.EnergyPrices>();
            tariffPrice.Hours = new List<Models.Digin.Hours>();

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
            Models.PriceStructure.TariffPrice tariffPricePrice,
            IReadOnlyList<Holiday> holidays,
            Models.PriceStructure.TariffType tariffType)
        {
            var startDate = tariffPricePrice.StartDate <= paramFromDate ? paramFromDate : tariffPricePrice.StartDate.UtcDateTime;
            var endDate = tariffPricePrice.EndDate >= paramToDate ? paramToDate : tariffPricePrice.EndDate.UtcDateTime;

            tariffPrice.PriceInfo.FixedPrices = new List<FixedPrices>();
            var fixedPriceTaxes = FilterFixedPricesTaxByDate(tariffPricePrice.Taxes.FixedPriceTaxes, startDate, endDate);
            tariffPrice.PriceInfo.FixedPrices.Add(GenerateFixedPrices(startDate, endDate, tariffPricePrice.FixedPrices, fixedPriceTaxes));

            var filteredHolidays = holidays.Where(a => a.Date >= startDate && a.Date <= endDate).ToList();
            var taxTimePeriods = SegmentByChangingTaxes(tariffPricePrice.Taxes, startDate, endDate);
            foreach (var taxTimePeriod in taxTimePeriods)
            {
                foreach (var season in tariffPricePrice.Seasons)
                {
                    var seasonIntersects = CalcSeasonIntersects(taxTimePeriod.StartDate, taxTimePeriod.EndDate, season.Months);
                    foreach (var seasonIntersect in seasonIntersects)
                    {
                        var accumulator = InitAccumulator(tariffPricePrice,
                            seasonIntersect.StartDate,
                            seasonIntersect.EndDate);

                        accumulator = ProcessSeason(accumulator,
                            season,
                            seasonIntersect.StartDate,
                            seasonIntersect.EndDate,
                            filteredHolidays,
                            tariffType,
                            tariffPrice
                            );

                        tariffPrice.PriceInfo.PowerPrices.AddRange(accumulator.TariffPrice.PriceInfo.PowerPrices);
                        tariffPrice.PriceInfo.EnergyPrices.AddRange(accumulator.TariffPrice.PriceInfo.EnergyPrices);
                        tariffPrice.Hours.AddRange(accumulator.TariffPrice.Hours);
                    }
                }
            }
        }

        public FixedPrices GenerateFixedPrices(DateTimeOffset fromDateUtc,
            DateTimeOffset toDateUtc,
            Models.PriceStructure.FixedPrices fixedPricesPrices,
            IReadOnlyList<Models.PriceStructure.FixedPriceTax> fixedPriceTaxes)
        {
            var retVal = new FixedPrices()
            {
                Id = Guid.NewGuid().ToString(),
                StartDate = _serviceHelper.ToConfiguredTimeZone(fromDateUtc),
                EndDate = _serviceHelper.ToConfiguredTimeZone(toDateUtc),
                PriceLevel = new List<FixedPriceLevel>()
            };
            List<int> daysInMonthToBeProcessed = GetDistinctFixedPriceMonths(fromDateUtc, toDateUtc);

            foreach (var daysInMonth in daysInMonthToBeProcessed)
            {
                AppendFixedPriceLevels(retVal, fixedPricesPrices, fixedPriceTaxes, daysInMonth);
            }
            return retVal;
        }

        public void AppendFixedPriceLevels(
            Models.Digin.FixedPrices fixedPrices,
            Models.PriceStructure.FixedPrices fixedPricesPrices,
            IReadOnlyList<Models.PriceStructure.FixedPriceTax> fixedPriceTaxes,
            int daysInMonth)
        {
            var daysInMonthHourIdentificator = Guid.NewGuid().ToString();
            foreach (var fixedPricesPrice in fixedPricesPrices.FixedPriceLevel)
            {
                var fixedPriceLevel = fixedPrices.PriceLevel.FirstOrDefault(a => a.Id == fixedPricesPrice.Id);
                if (fixedPriceLevel == null)
                {
                    fixedPriceLevel = PriceLevelPriceToFixedPriceLevel(fixedPricesPrice, fixedPriceTaxes);
                    fixedPrices.PriceLevel.Add(fixedPriceLevel);
                }
                if (!fixedPriceLevel.HourPrices.Any(x => x.NumberOfDaysInMonth == daysInMonth))
                {
                    fixedPriceLevel.HourPrices.Add(CalcMonthlyFixedPrices(fixedPricesPrice, fixedPriceTaxes, daysInMonth, daysInMonthHourIdentificator));
                }
            }
        }

        public List<int> GetDistinctFixedPriceMonths(DateTimeOffset fromDateUtc, DateTimeOffset toDateUtc)
        {
            var fromDateLocaled = _serviceHelper.ToConfiguredTimeZone(fromDateUtc.DateTime);
            fromDateLocaled = fromDateLocaled.AddDays(1 - fromDateLocaled.Day);
            var toDateLocaled = _serviceHelper.ToConfiguredTimeZone(toDateUtc.DateTime);

            List<int> daysInMonthToBeProcessed = new List<int>();
            while (fromDateLocaled < toDateLocaled)
            {
                var daysInMonth = DateTime.DaysInMonth(fromDateLocaled.Year, fromDateLocaled.Month);
                daysInMonthToBeProcessed.Add(daysInMonth);
                fromDateLocaled = fromDateLocaled.AddMonths(1);
            }
            return daysInMonthToBeProcessed.Distinct().ToList();
        }

        List<TimePeriod> CalcSeasonIntersects(DateTimeOffset fromDate, DateTimeOffset toDate, IReadOnlyList<int> months)
        {
            var retVal = new List<TimePeriod>();
            var fromDateLocaled = _serviceHelper.ToConfiguredTimeZone(fromDate);
            int? startMonth = months.OrderBy(x => x).FirstOrDefault(x => x >= fromDateLocaled.Month);
            if (startMonth.HasValue && startMonth.Value > 0)
            {
                DateTimeOffset seasonStart = CalcSeasonStart(fromDate, ref fromDateLocaled, startMonth);
                DateTimeOffset seasonEnd = CalcSeasonEnd(fromDate, months, fromDateLocaled);

                if (!((seasonStart > toDate) || (seasonEnd < fromDate)))
                {
                    retVal.AddRange(AccumulateSeasonIntersects(fromDate, toDate, months, seasonStart, seasonEnd));
                }
            }
            return retVal;
        }

        private List<TimePeriod> AccumulateSeasonIntersects(DateTimeOffset fromDate, DateTimeOffset toDate, IReadOnlyList<int> months, DateTimeOffset seasonStart, DateTimeOffset seasonEnd)
        {
            var retVal = new List<TimePeriod>();
            var finalStartDate = seasonStart > fromDate ? seasonStart : fromDate;
            var finalEndDate = seasonEnd < toDate ? seasonEnd : toDate;

            if (finalStartDate != finalEndDate)
            {
                retVal.Add(new TimePeriod()
                {
                    StartDate = finalStartDate,
                    EndDate = finalEndDate
                });
            }
            if (finalEndDate < toDate)
            {
                retVal.AddRange(CalcSeasonIntersects(finalEndDate, toDate, months));
            }
            return retVal;
        }

        private DateTimeOffset CalcSeasonStart(DateTimeOffset fromDate, ref DateTimeOffset fromDateLocaled, int? startMonth)
        {
            if (fromDateLocaled.Month != startMonth.Value)
            {
                fromDateLocaled = fromDateLocaled.AddMonths(startMonth.Value - fromDateLocaled.Month);
            }
            fromDateLocaled = fromDateLocaled.AddDays(1 - fromDateLocaled.Day).AddHours(-fromDateLocaled.Hour).AddMinutes(-fromDate.Minute);
            var seasonStartTimeLocaledAndTimeZoneCorrected = _serviceHelper.DbTimeZoneDateToUtc(fromDateLocaled.DateTime);
            var seasonStart = fromDate.AddTicks(seasonStartTimeLocaledAndTimeZoneCorrected.UtcDateTime.Ticks - fromDate.Ticks);
            return seasonStart;
        }

        private DateTimeOffset CalcSeasonEnd(DateTimeOffset fromDate, IReadOnlyList<int> months, DateTimeOffset fromDateLocaled)
        {
            fromDateLocaled = fromDateLocaled.AddMonths(1);
            while (months.Count(x => x == fromDateLocaled.Month) == 1)
            {
                fromDateLocaled = fromDateLocaled.AddMonths(1);
            }
            fromDateLocaled = fromDateLocaled.AddDays(1 - fromDateLocaled.Day).AddHours(-fromDateLocaled.Hour).AddMinutes(-fromDate.Minute);
            var seasonEndTimeLocaledAndTimeZoneCorrected = _serviceHelper.DbTimeZoneDateToUtc(fromDateLocaled.DateTime);
            var seasonEnd = fromDate.AddTicks(seasonEndTimeLocaledAndTimeZoneCorrected.UtcDateTime.Ticks - fromDate.Ticks);
            return seasonEnd;
        }

        SeasonDataAccumulator InitAccumulator(Models.PriceStructure.TariffPrice tariffPrice, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            var retVal = new SeasonDataAccumulator();
            retVal.Taxes.PowerPriceTaxes = FilterPowePriceTaxesByDate(tariffPrice.Taxes.PowerPriceTaxes, fromDate, toDate);
            retVal.Taxes.EnergyPriceTaxes = FilterEnergyPriceTaxesByDate(tariffPrice.Taxes.EnergyPriceTaxes, fromDate, toDate);
            return retVal;
        }

        List<TimePeriod> SegmentByChangingTaxes(Models.PriceStructure.Taxes taxes, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var retVal = new List<TimePeriod>();
            var dates = new List<DateTimeOffset>
            {
                startDate,
                endDate
            };

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
            for (int i = 0; i < dates.Count - 1; i++)
            {
                retVal.Add(new TimePeriod() { StartDate = dates[i], EndDate = dates[i + 1] });
            }
            return retVal;
        }

        SeasonDataAccumulator ProcessSeason(SeasonDataAccumulator dataAccumulator,
            Models.PriceStructure.Season season,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate,
            List<Holiday> holidays,
            Models.PriceStructure.TariffType tariffType,
            TariffPrice tariffPrice)
        {
            if (season.PowerPrices != null)
            {
                var powerPrice = new PowerPrices
                {
                    Id = Guid.NewGuid().ToString(),
                    StartDate = _serviceHelper.ToConfiguredTimeZone(paramFromDate),
                    EndDate = _serviceHelper.ToConfiguredTimeZone(paramToDate),
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
                    var hourSeasonIndex = BuildHourSeasonIndex(dataAccumulator.TariffPrice.PriceInfo, tariffPrice.PriceInfo, season.EnergyPrice, daysInMonth, tariffType.UsePublicHolidayOverride, tariffType.UseWeekendPriceOverride);
                    var filteredHolidays = holidays.Where(a => a.Date >= fromDate && a.Date <= currMonthEndToDate).ToList();
                    dataAccumulator = ProcessMonth(dataAccumulator, fromDate, currMonthEndToDate, hourSeasonIndex, filteredHolidays, tariffType.Resolution);
                }
                fromDate = currMonthEndToDate;
            }
            return dataAccumulator;
        }


        private SeasonDataAccumulator AddPriceLevels(SeasonDataAccumulator dataAccumulator, Models.PriceStructure.Season season, DateTimeOffset paramFromDate, DateTimeOffset paramToDate, int daysInMonth)
        {
            dataAccumulator = AddPowerPrices(season.PowerPrices, daysInMonth, dataAccumulator);
            dataAccumulator = AddEnergyPrices(season.EnergyPrice, dataAccumulator, season.Name, paramFromDate, paramToDate);
            return dataAccumulator;
        }

        public IReadOnlyList<Models.PriceStructure.FixedPriceTax> FilterFixedPricesTaxByDate(IReadOnlyList<Models.PriceStructure.FixedPriceTax> taxes, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            if (taxes != null)
            {
                return taxes.Where(a => a.StartDate < toDate && a.EndDate > fromDate).ToList();
            }
            return taxes;
        }

        public IReadOnlyList<Models.PriceStructure.PowerPriceTax> FilterPowePriceTaxesByDate(IReadOnlyList<Models.PriceStructure.PowerPriceTax> taxes, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            if (taxes != null)
            {
                return taxes.Where(a => a.StartDate < toDate && a.EndDate > fromDate).ToList();
            }
            return taxes;
        }

        public IReadOnlyList<Models.PriceStructure.EnergyPriceTax> FilterEnergyPriceTaxesByDate(IReadOnlyList<Models.PriceStructure.EnergyPriceTax> taxes, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            if (taxes != null)
            {
                return taxes.Where(a => a.StartDate < toDate && a.EndDate > fromDate).ToList();
            }
            return taxes;
        }


        HourSeasonIndex BuildHourSeasonIndex(Models.Digin.PriceInfo accumulatorPriceInfo,
            Models.Digin.PriceInfo fixedPricePriceInfo,
            Models.PriceStructure.EnergyPrice energyPrice
            , int daysInMonth,
            string usePublicHolidayOverride,
            string useWeekendPriceOverride)

        {
            var retVal = new HourSeasonIndex();

            var fixedPrice = fixedPricePriceInfo.FixedPrices.FirstOrDefault();
            if (fixedPrice != null)
            {
                var monthPrice = fixedPrice.PriceLevel.FirstOrDefault().HourPrices.FirstOrDefault(a => a.NumberOfDaysInMonth == daysInMonth);
                retVal.FixedPriceValue = new PriceElement
                {
                    Id = fixedPrice.Id,
                    IdDaysInMonth = monthPrice.Id
                };
            }
            var powerPrice = accumulatorPriceInfo.PowerPrices.FirstOrDefault();
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
                retVal.EnergyInformation = new EnergyInformation
                {
                    HourArray = new EnergyPrices[Constants.HoursInDay]
                };

                foreach (var priceLevel in energyPrice.EnergyPriceLevel)
                {
                    var energyPriceLevel = accumulatorPriceInfo.EnergyPrices.FirstOrDefault(a => a.Level == priceLevel.Level);
                    foreach (var hour in priceLevel.Hours)
                    {
                        retVal.EnergyInformation.HourArray[hour] = energyPriceLevel;
                    }
                }
            }
            retVal.EnergyInformationHoliday = GenerateOverrideEnergyPricesData(accumulatorPriceInfo, usePublicHolidayOverride);
            retVal.EnergyInformationWeekend = GenerateOverrideEnergyPricesData(accumulatorPriceInfo, useWeekendPriceOverride);
            return retVal;
        }

        public EnergyInformation GenerateOverrideEnergyPricesData(Models.Digin.PriceInfo priceInfo, string level)
        {
            EnergyInformation retVal = null;
            if (!String.IsNullOrEmpty(level))
            {
                var priceLevel = priceInfo.EnergyPrices.FirstOrDefault(a => a.Level == level);
                if (priceLevel != null)
                {
                    retVal = new EnergyInformation
                    {
                        HourArray = new EnergyPrices[Constants.HoursInDay]
                    };
                    for (int hour = 0; hour < Constants.HoursInDay; hour++)
                    {
                        retVal.HourArray[hour] = priceLevel;
                    }
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
                bool isPublicHoliday = IsPublicHoliday(holidays, fromDate);
                bool isWeekend = IsWeekend(fromDate);
                var toDate = fromDate.AddDays(1) < paramToDate ? fromDate.AddDays(1) : paramToDate;
                dataAccumulator = ProcessDay(dataAccumulator, fromDate, toDate, hourSeasonIndex, tariffResolutionMinutes, isPublicHoliday, isWeekend);
                fromDate = fromDate.AddDays(1);

            }
            return dataAccumulator;
        }

        public bool IsWeekend(DateTimeOffset fromDate)
        {
            var localdDate = _serviceHelper.GetTimeZonedDateTime(fromDate.UtcDateTime).Date;
            return localdDate.DayOfWeek == DayOfWeek.Saturday || localdDate.DayOfWeek == DayOfWeek.Sunday;
        }

        public bool IsPublicHoliday(List<Holiday> holidays, DateTimeOffset fromDate)
        {
            return holidays.Exists(a => a.Date.Date == _serviceHelper.GetTimeZonedDateTime(fromDate.UtcDateTime).Date);
        }

        SeasonDataAccumulator ProcessDay(SeasonDataAccumulator dataAccumulator
            , DateTimeOffset paramFromDate
            , DateTimeOffset paramToDate
            , HourSeasonIndex hourSeasonIndex
            , int resolution,
            bool isPublicHoliday,
            bool isWeekend)
        {
            var fromDate = paramFromDate;
            var endDate = fromDate;
            EnergyInformation energyInformation = DecideEneryInformation(hourSeasonIndex, isPublicHoliday, isWeekend);
            while (endDate < paramToDate)
            {
                endDate = fromDate.AddMinutes(resolution);
                var priceData = ToHour(fromDate, endDate, hourSeasonIndex, energyInformation, isPublicHoliday);
                dataAccumulator.TariffPrice.Hours.Add(priceData);
                fromDate = endDate;
            }
            return dataAccumulator;
        }

        public EnergyInformation DecideEneryInformation(HourSeasonIndex hourSeasonIndex, bool isPublicHoliday, bool isWeekend)
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

        public Models.Digin.Hours ToHour(DateTimeOffset startTime
            , DateTimeOffset expireAt
            , HourSeasonIndex hourSeasonIndex,
            EnergyInformation energyInformation,
            bool isPublicHoliday)
        {
            var retVal = new Models.Digin.Hours
            {
                StartTime = _serviceHelper.ToConfiguredTimeZone(startTime),
                ExpiredAt = _serviceHelper.ToConfiguredTimeZone(expireAt),
                FixedPrice = new FixedPrice()
                {
                    Id = hourSeasonIndex.FixedPriceValue.Id,
                    HourId = hourSeasonIndex.FixedPriceValue.IdDaysInMonth
                }
            };

            if (hourSeasonIndex.PowerPriceValue != null)
            {
                retVal.PowerPrice = new PowerPrice()
                {
                    Id = hourSeasonIndex.PowerPriceValue.Id,
                    HourId = hourSeasonIndex.PowerPriceValue.IdDaysInMonth
                };
            }

            retVal.EnergyPrice = new EnergyPrice
            {
                Id = energyInformation.HourArray[retVal.StartTime.Hour].Id,
                Total = energyInformation.HourArray[retVal.StartTime.Hour].Total,
                TotalExVat = energyInformation.HourArray[retVal.StartTime.Hour].TotalExVat
            };
            retVal.IsPublicHoliday = isPublicHoliday;
            retVal.ShortName = $"{((retVal.StartTime.Hour * 100) + retVal.StartTime.Minute).ToString().PadLeft(4, '0')}-{((retVal.ExpiredAt.Hour * 100) + retVal.ExpiredAt.Minute).ToString().PadLeft(4, '0')}";
            return retVal;
        }


        SeasonDataAccumulator AddEnergyPrices(
            Models.PriceStructure.EnergyPrice energyPricesPrices,
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
            Models.Digin.PriceInfo priceInfo,
            Models.PriceStructure.EnergyPrice energyPricePrices,
            IReadOnlyList<Models.PriceStructure.EnergyPriceTax> energyPriceTaxes,
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
                        toDate);
                    priceInfo.EnergyPrices.Add(energyPriceLevel);
                }
            }
        }


        public EnergyPrices PriceLevelEnergyPriceToEnergyPriceLevel(
            Models.PriceStructure.EnergyPrice energyPricePrices,
            Models.PriceStructure.EnergyPriceLevel energyPriceLevel,
            IReadOnlyList<Models.PriceStructure.EnergyPriceTax> energyPriceTaxes,
            string season,
            DateTimeOffset fromDate,
            DateTimeOffset toDate)
        {
            var retval = new EnergyPrices();

            var vatTax = energyPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");
            var consumptionTax = energyPriceTaxes.FirstOrDefault(x => x.TaxType == "consumptionTax");
            var enovaTax = energyPriceTaxes.FirstOrDefault(x => x.TaxType == "enovaTax");

            var vatTaxValue = vatTax != null ? vatTax.TaxValue : 0;
            var consumptionTaxValue = consumptionTax != null ? consumptionTax.TaxValue : 0;
            var enovaTaxValue = enovaTax != null ? enovaTax.TaxValue : 0;

            retval.Id = Guid.NewGuid().ToString();
            retval.StartDate = _serviceHelper.ToConfiguredTimeZone(fromDate);
            retval.EndDate = _serviceHelper.ToConfiguredTimeZone(toDate);
            retval.Season = season;

            retval.Level = energyPriceLevel.Level;

            retval.EnergyExTaxes = energyPriceLevel.EnergyExTaxes;
            retval.TotalExVat = energyPriceLevel.EnergyExTaxes + consumptionTaxValue + enovaTaxValue;
            retval.Total = AddTaxes(retval.TotalExVat, vatTaxValue);
            retval.Taxes = retval.Total - retval.TotalExVat;

            retval.Currency = energyPricePrices.Currency;
            retval.MonetaryUnitOfMeasure = energyPricePrices.MonetaryUnitOfMeasure;

            retval.Total = RoundDouble(retval.Total, Constants.EnergyPriceDecimals);
            retval.TotalExVat = RoundDouble(retval.TotalExVat, Constants.EnergyPriceDecimals);
            retval.EnergyExTaxes = RoundDouble(retval.EnergyExTaxes, Constants.EnergyPriceDecimals);
            retval.Taxes = RoundDouble(retval.Taxes, Constants.EnergyPriceDecimals);
            return retval;
        }

        SeasonDataAccumulator AddPowerPrices(
            Models.PriceStructure.PowerPrices powerPricePrices,
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
            Models.Digin.PowerPrices powerPrices,
            Models.PriceStructure.PowerPrices powerPricePrices,
            IReadOnlyList<Models.PriceStructure.PowerPriceTax> powerPriceTaxes,
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

        public Models.Digin.HourPowerPrices CalcMonthlyPowerPrices(
            Models.PriceStructure.PowerPriceLevel powerPriceLevel,
            IReadOnlyList<Models.PriceStructure.PowerPriceTax> powerPriceTaxes,
            int daysInMonth)
        {
            var vatTax = powerPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");
            double vatTaxValue = vatTax != null ? vatTax.TaxValue : 0;
            int hoursInMonth = daysInMonth * Constants.HoursInDay;

            var activeTotalExVat = powerPriceLevel.MonthlyActivePowerExTaxes / hoursInMonth;
            var activeTotal = AddTaxes(activeTotalExVat, vatTaxValue);
            var reactiveTotalExVat = powerPriceLevel.MonthlyReactivePowerExTaxes / hoursInMonth;
            var reactiveTotal = AddTaxes(reactiveTotalExVat, vatTaxValue);

            var retVal = new Models.Digin.HourPowerPrices
            {
                Id = Guid.NewGuid().ToString(),
                NumberOfDaysInMonth = daysInMonth,
                ActiveTotal = RoundDouble(activeTotal, Constants.PowerPriceDecimals),
                ActiveTotalExVat = RoundDouble(activeTotalExVat, Constants.PowerPriceDecimals),
                ReactiveTotal = RoundDouble(reactiveTotal, Constants.PowerPriceDecimals),
                ReactiveTotalExVat = RoundDouble(reactiveTotalExVat, Constants.PowerPriceDecimals)
            };
            return retVal;
        }



        public PowerPriceLevel PriceLevelPowerPriceToPowerPriceLevel(
            Models.PriceStructure.PowerPriceLevel powerPriceLevel,
            IReadOnlyList<Models.PriceStructure.PowerPriceTax> powerPriceTaxes)
        {
            var retVal = new Models.Digin.PowerPriceLevel
            {
                Id = powerPriceLevel.Id,
                ValueMin = powerPriceLevel.ValueMin,
                ValueMax = powerPriceLevel.ValueMax,
                NextIdDown = powerPriceLevel.NextIdDown,
                NextIdUp = powerPriceLevel.NextIdUp,
                ValueUnitOfMeasure = powerPriceLevel.ValueUnitOfMeasure
            };
            CalcPowerPriceLevelValues(retVal, powerPriceLevel, powerPriceTaxes);
            retVal.MonthlyUnitOfMeasure = powerPriceLevel.MonthlyUnitOfMeasure;
            retVal.HourPrices = new List<HourPowerPrices>();
            retVal.LevelInfo = powerPriceLevel.LevelInfo;
            retVal.Currency = powerPriceLevel.Currency;
            retVal.MonetaryUnitOfMeasure = powerPriceLevel.MonetaryUnitOfMeasure;
            return retVal;
        }

        void CalcPowerPriceLevelValues(Models.Digin.PowerPriceLevel powerPriceLevel, Models.PriceStructure.PowerPriceLevel powerPriceLevelPrice, IReadOnlyList<Models.PriceStructure.PowerPriceTax> powerPriceTaxes)
        {
            var vatTax = powerPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");
            double vatTaxValue = vatTax != null ? vatTax.TaxValue : 0;
            powerPriceLevel.MonthlyActivePowerExTaxes = powerPriceLevelPrice.MonthlyActivePowerExTaxes;
            powerPriceLevel.MonthlyActivePowerTotalExVat = powerPriceLevelPrice.MonthlyActivePowerExTaxes;
            powerPriceLevel.MonthlyActivePowerTotal = AddTaxes(powerPriceLevel.MonthlyActivePowerExTaxes, vatTaxValue);
            powerPriceLevel.MonthlyActivePowerTaxes = powerPriceLevel.MonthlyActivePowerTotal - powerPriceLevel.MonthlyActivePowerTotalExVat;

            powerPriceLevel.MonthlyReactivePowerExTaxes = powerPriceLevelPrice.MonthlyReactivePowerExTaxes;
            powerPriceLevel.MonthlyReactivePowerTotalExVat = powerPriceLevelPrice.MonthlyReactivePowerExTaxes;
            powerPriceLevel.MonthlyReactivePowerTotal = AddTaxes(powerPriceLevel.MonthlyReactivePowerExTaxes, vatTaxValue);
            powerPriceLevel.MonthlyReactivePowerTaxes = powerPriceLevel.MonthlyReactivePowerTotal - powerPriceLevel.MonthlyReactivePowerTotalExVat;

            powerPriceLevel.MonthlyActivePowerExTaxes = RoundDouble(powerPriceLevel.MonthlyActivePowerExTaxes, Constants.PowerPriceDecimals);
            powerPriceLevel.MonthlyActivePowerTotalExVat = RoundDouble(powerPriceLevel.MonthlyActivePowerTotalExVat, Constants.PowerPriceDecimals);
            powerPriceLevel.MonthlyActivePowerTotal = RoundDouble(powerPriceLevel.MonthlyActivePowerTotal, Constants.PowerPriceDecimals);
            powerPriceLevel.MonthlyActivePowerTaxes = RoundDouble(powerPriceLevel.MonthlyActivePowerTaxes, Constants.PowerPriceDecimals);

            powerPriceLevel.MonthlyReactivePowerExTaxes = RoundDouble(powerPriceLevel.MonthlyReactivePowerExTaxes, Constants.PowerPriceDecimals);
            powerPriceLevel.MonthlyReactivePowerTotalExVat = RoundDouble(powerPriceLevel.MonthlyReactivePowerTotalExVat, Constants.PowerPriceDecimals);
            powerPriceLevel.MonthlyReactivePowerTotal = RoundDouble(powerPriceLevel.MonthlyReactivePowerTotal, Constants.PowerPriceDecimals);
            powerPriceLevel.MonthlyReactivePowerTaxes = RoundDouble(powerPriceLevel.MonthlyReactivePowerTaxes, Constants.PowerPriceDecimals);
        }

        public FixedPriceLevel PriceLevelPriceToFixedPriceLevel(
            Models.PriceStructure.FixedPriceLevel priceLevel,
            IReadOnlyList<Models.PriceStructure.FixedPriceTax> fixedPriceTaxes)
        {
            var retVal = new Models.Digin.FixedPriceLevel();
            var vatTax = fixedPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");
            double vatTaxValue = vatTax != null ? vatTax.TaxValue : 0;

            retVal.Id = priceLevel.Id;
            retVal.ValueMin = priceLevel.ValueMin;
            retVal.ValueMax = priceLevel.ValueMax;
            retVal.NextIdDown = priceLevel.NextIdDown;
            retVal.NextIdUp = priceLevel.NextIdUp;
            retVal.ValueUnitOfMeasure = priceLevel.ValueUnitOfMeasure;
            retVal.MonthlyExTaxes = priceLevel.MonthlyFixedExTaxes;
            retVal.MonthlyTotal = AddTaxes(priceLevel.MonthlyFixedExTaxes, vatTaxValue);
            retVal.MonthlyTotalExVat = priceLevel.MonthlyFixedExTaxes;
            retVal.MonthlyTaxes = retVal.MonthlyTotal - retVal.MonthlyExTaxes;
            retVal.HourPrices = new List<HourFixedPrices>();
            retVal.MonthlyUnitOfMeasure = priceLevel.MonthlyUnitOfMeasure;
            retVal.LevelInfo = priceLevel.LevelInfo;
            retVal.Currency = priceLevel.Currency;
            retVal.MonetaryUnitOfMeasure = priceLevel.MonetaryUnitOfMeasure;
            return retVal;
        }

        public Models.Digin.HourFixedPrices CalcMonthlyFixedPrices(
            Models.PriceStructure.FixedPriceLevel fixedPricePriceLevel,
            IReadOnlyList<Models.PriceStructure.FixedPriceTax> fixedPriceTaxes,
            int daysInMonth,
            string daysInMonthHourIdentificator)
        {
            var vatTax = fixedPriceTaxes.FirstOrDefault(x => x.TaxType == "vat");
            var vatTaxValue = vatTax != null ? vatTax.TaxValue : 0;
            int hoursInMonth = daysInMonth * Constants.HoursInDay;
            var totalExVatPerHour = fixedPricePriceLevel.MonthlyFixedExTaxes / hoursInMonth;

            var retVal = new Models.Digin.HourFixedPrices
            {
                Id = daysInMonthHourIdentificator,
                NumberOfDaysInMonth = daysInMonth,
                TotalExVat = RoundDouble(totalExVatPerHour, Constants.FixedPricesDecimals),
                Total = RoundDouble(AddTaxes(totalExVatPerHour, vatTaxValue), Constants.FixedPricesDecimals)
            };
            return retVal;
        }

        public Models.Digin.GridTariff ToGridTariff(
            Models.PriceStructure.Company company,
            Models.PriceStructure.TariffType tariffType)
        {
            var retVal = new Models.Digin.GridTariff
            {
                TariffType = _objectConversionHelper.ToTariffType(company, tariffType)
            };
            return retVal;
        }

        public double RoundDouble(double value, int numDecimals)
        {
            double addValue = 1 / Math.Pow(10, numDecimals + 1);
            return Math.Round(value + addValue, numDecimals);
        }

        public double AddTaxes(double input, double vat)
        {
            return input + (input * (vat / 100));
        }

        public DateTimeOffset GetNextMonthEndDate(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            var localedFromDate = _serviceHelper.ToConfiguredTimeZone(fromDate.UtcDateTime);
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
