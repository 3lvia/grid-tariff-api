﻿using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.Digin;
using GridTariffApi.Lib.Models.Holidays;
using GridTariffApi.Lib.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GridTariffApi.Lib.Exceptions;
using GridTariffApi.Lib.Models.PriceStructure;
using EnergyPrice = GridTariffApi.Lib.Models.Digin.EnergyPrice;
using FixedPriceLevel = GridTariffApi.Lib.Models.Digin.FixedPriceLevel;
using FixedPrices = GridTariffApi.Lib.Models.Digin.FixedPrices;
using PowerPriceLevel = GridTariffApi.Lib.Models.Digin.PowerPriceLevel;
using PowerPrices = GridTariffApi.Lib.Models.Digin.PowerPrices;
using TariffPrice = GridTariffApi.Lib.Models.Digin.TariffPrice;

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
            var meteringPointsInformations = await _tariffPriceCache.GetMeteringPointInformationsAsync(paramFromDate, paramToDate, meteringPoints);
            var ProductKeys = meteringPointsInformations.Select(x => x.ProductKey).Distinct();
            var tasks = new List<Task<GridTariffCollection>>();
            foreach (var productKey in ProductKeys)
            {
                var gridTariffMeteringPoints = meteringPointsInformations.Where(x => x.ProductKey == productKey).ToList();
                tasks.Add(GenerateTariffAndAppendMeteringPointsAsync(productKey, paramFromDate, paramToDate, gridTariffMeteringPoints));
            }
            foreach (var task in tasks)
            {
                retVal.GridTariffCollections.Add(await task);
            }
            return retVal;
        }

        public virtual async Task<GridTariffCollection> GenerateTariffAndAppendMeteringPointsAsync(string productKey,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate,
            List<MeteringPointInformation> meteringPointInformation)
        {
            bool isMapToFixedPriceLevel = _serviceHelper.TimePeriodIsIncludingLocaleToday(paramFromDate, paramToDate);
            var gridTariff = await QueryTariffUsingProductKeyAsync(productKey, paramFromDate, paramToDate);
            gridTariff.MeteringPointsAndPriceLevels = new List<MeteringPointsAndPriceLevels>();

            if (isMapToFixedPriceLevel)
            {
                //query overlaps localed "today"
                var currentFixedPrices = GetFixedPricesValidToday(gridTariff.GridTariff?.TariffPrice?.PriceInfo?.FixedPrices);
                if (currentFixedPrices != null)
                {
                    var priceLevels = AppendMeteringPointsToPriceLevels(meteringPointInformation, currentFixedPrices);
                    foreach (var priceLevel in priceLevels)
                    {
                        gridTariff.MeteringPointsAndPriceLevels.Add(priceLevel);
                    }
                }
                else
                {
                    var priceLevel = MeteringPointsToPriceLevel(null, null, meteringPointInformation);
                    gridTariff.MeteringPointsAndPriceLevels.Add(priceLevel);
                }
            }
            else
            {
                //query does not overlap localed "today".
                //connect meteringpoints to tariff, but do not set fixedprice or pricelevelid
                var priceLevel = MeteringPointsToPriceLevel(null, null, meteringPointInformation);
                gridTariff.MeteringPointsAndPriceLevels.Add(priceLevel);
            }
            return gridTariff;
        }

        public virtual FixedPrices GetFixedPricesValidToday(List<FixedPrices> fixedPrices)
        {
            return fixedPrices?.FirstOrDefault(x => _serviceHelper.TimePeriodIsIncludingLocaleToday(x.StartDate, x.EndDate));
        }

        public virtual List<MeteringPointsAndPriceLevels> AppendMeteringPointsToPriceLevels(List<MeteringPointInformation> meteringPointInformations, FixedPrices fixedPrices)
        {
            var retVal = new List<MeteringPointsAndPriceLevels>();

            //mp missing maxConsumption and more than one pricelevel (do not set pricelevelid)
            var meteringPointsNoPriceLevel = meteringPointInformations.Where(x => !x.MaxConsumption.HasValue && fixedPrices.PriceLevels.Count != 1).ToDictionary(x => x.MeteringPointId, x => x);
            if (meteringPointsNoPriceLevel.Count > 0)
            {
                retVal.Add(MeteringPointsToPriceLevel(fixedPrices.Id, null, meteringPointsNoPriceLevel.Values.ToList()));
            }

            //mp not missing maxConsumption (set pricelevelid)
            //mp missing maxConsumption and exactly one pricelevel (set pricelevelid)
            var meteringPointsPricelevel = meteringPointInformations.Where(x => !meteringPointsNoPriceLevel.ContainsKey(x.MeteringPointId)).ToList();
            if (meteringPointsPricelevel.Count > 0)
            {
                foreach (var fixedPriceLevel in fixedPrices.PriceLevels)
                {
                    var meteringPointAndPriceLevel = MeteringPointsAndPriceLevelsMatchingConsumption(fixedPrices.Id, fixedPriceLevel, meteringPointsPricelevel);
                    if (meteringPointAndPriceLevel != null)
                    {
                        retVal.Add(meteringPointAndPriceLevel);
                    }
                }
            }
            return retVal;
        }

        public MeteringPointsAndPriceLevels MeteringPointsAndPriceLevelsMatchingConsumption(string fixedPriceId, FixedPriceLevel fixedPriceLevel, List<MeteringPointInformation> meteringPointInformation)
        {
            MeteringPointsAndPriceLevels retVal = null;
            var minVal = fixedPriceLevel.ValueMin ?? double.MinValue;
            var maxVal = fixedPriceLevel.ValueMax ?? double.MaxValue;

            var mpInformations = meteringPointInformation.Where(x => (!fixedPriceLevel.ValueMin.HasValue && !fixedPriceLevel.ValueMax.HasValue)
                || (x.MaxConsumption.HasValue && minVal <= x.MaxConsumption && x.MaxConsumption < maxVal)).ToList();
            if (mpInformations.Count > 0)
            {
                retVal = MeteringPointsToPriceLevel(fixedPriceId, fixedPriceLevel.Id, mpInformations);
            }
            return retVal;
        }

        public virtual MeteringPointsAndPriceLevels MeteringPointsToPriceLevel(string fixedPriceId, string fixedPriceLevelId, List<MeteringPointInformation> mpInformations)
        {
            var meteringPointAndPriceLevel = new MeteringPointsAndPriceLevels()
            {
                CurrentFixedPriceLevel = new CurrentFixedPriceLevel(),
                MeteringPoints = new MeteringPoints()
            };

            foreach (var mpInformation in mpInformations)
            {
                var mpDetails = new MeteringPointDetails() { MeteringPointId = mpInformation.MeteringPointId };
                if (mpInformation.MaxConsumptionLastUpdated.HasValue)
                {
                    mpDetails.LastUpdated = _serviceHelper.ToConfiguredTimeZone(mpInformation.MaxConsumptionLastUpdated.Value);
                }

                meteringPointAndPriceLevel.MeteringPoints.Add(mpDetails);
            }
            meteringPointAndPriceLevel.CurrentFixedPriceLevel.Id = fixedPriceId;
            meteringPointAndPriceLevel.CurrentFixedPriceLevel.LevelId = fixedPriceLevelId;
            return meteringPointAndPriceLevel;
        }

        public virtual async Task<GridTariffCollection> QueryTariffUsingTariffKeyAsync(
            string tariffKey,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate)
        {
            var tariffs = await _tariffPriceCache.GetTariffsAsync();
            var tariff = tariffs?.FirstOrDefault(x => x.TariffKey == tariffKey);
            if (tariff != null)
            {
                return await QueryTariffUsingProductKeyAsync(tariff.Product, paramFromDate, paramToDate);
            }
            return await QueryTariffUsingProductKeyAsync(String.Empty, paramFromDate, paramToDate);
        }


        public virtual async Task<GridTariffCollection> QueryTariffUsingProductKeyAsync(
            string productKey,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate)
        {
            var tariffs = await _tariffPriceCache.GetTariffsAsync();
            var tariff = tariffs?.FirstOrDefault(x => x.Product == productKey);
            if (tariff == null)
            {
                return new GridTariffCollection();
            }
            var tariffPrices = tariff.TariffPrices.ToList();
            tariffPrices.RemoveAll(x => x.EndDate <= paramFromDate || x.StartDate >= paramToDate);
            var company = await _tariffPriceCache.GetCompanyAsync();

            var gridTariffCollection = new GridTariffCollection
            {
                GridTariff = ToGridTariff(company, tariff)
            };
            gridTariffCollection.GridTariff.TariffType.LastUpdated = tariff.LastUpdated;
            var tariffPrice = await ProcessTariffPricesAsync(tariff, tariffPrices, paramFromDate, paramToDate);
            gridTariffCollection.GridTariff.TariffPrice = tariffPrice;
            return gridTariffCollection;
        }

        public async Task<Models.Digin.TariffPrice> ProcessTariffPricesAsync(
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

            var holidays = await _tariffPriceCache.GetHolidaysAsync(paramFromDate, paramToDate);
            foreach (var tariffPricePrice in tariffPrices)
            {
                await ProcessTariffPriceAsync(paramFromDate,
                    paramToDate,
                    tariffPrice,
                    tariffPricePrice,
                    holidays,
                    tariffType);
            }

            Cleanup(tariffPrice);
            return tariffPrice;
        }

        private static void Cleanup(TariffPrice tariffPrice)
        {
            if (tariffPrice.PriceInfo.FixedPrices.Count == 0)
            {
                tariffPrice.PriceInfo.FixedPrices = null;
            }
            if (tariffPrice.PriceInfo.PowerPrices.Count == 0)
            {
                tariffPrice.PriceInfo.PowerPrices = null;
            }
            if (tariffPrice.PriceInfo.EnergyPrices.Count == 0)
            {
                tariffPrice.PriceInfo.EnergyPrices = null;
            }
            if (tariffPrice.Hours.Count == 0)
            {
                tariffPrice.Hours = null;
            }
        }

        private async Task ProcessTariffPriceAsync(DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate,
            TariffPrice tariffPrice,
            Models.PriceStructure.TariffPrice tariffPricePrice,
            IReadOnlyList<Holiday> holidays,
            Models.PriceStructure.TariffType tariffType)
        {
            var tasks = new List<Task<SeasonDataAccumulator>>();
            var startDate = tariffPricePrice.StartDate <= paramFromDate ? paramFromDate : tariffPricePrice.StartDate.UtcDateTime;
            var endDate = tariffPricePrice.EndDate >= paramToDate ? paramToDate : tariffPricePrice.EndDate.UtcDateTime;

            if (tariffPrice.PriceInfo.FixedPrices == null)
            {
                tariffPrice.PriceInfo.FixedPrices = new List<FixedPrices>();
            }
            var fixedPriceTaxes = FilterFixedPricesTaxByDate(tariffPricePrice.Taxes.FixedPriceTaxes, startDate, endDate);

            var fixedPrices = GenerateFixedPrices(startDate, endDate, tariffPricePrice.FixedPrices, fixedPriceTaxes);
            tariffPrice.PriceInfo.FixedPrices.Add(fixedPrices);

            var filteredHolidays = holidays.Where(a => a.Date >= startDate && a.Date <= endDate).ToList();
            var taxTimePeriods = SegmentByChangingTaxes(tariffPricePrice.Taxes, startDate, endDate);
            foreach (var taxTimePeriod in taxTimePeriods)
            {
                foreach (var season in tariffPricePrice.Seasons)
                {
                    var seasonIntersects = _serviceHelper.GetMonthPeriods(taxTimePeriod.StartDate, taxTimePeriod.EndDate, season.Months);
                    foreach (var seasonIntersect in seasonIntersects)
                    {
                        tasks.Add(ProcessSeasonAsync(
                            tariffPrice, 
                            tariffPricePrice, 
                            tariffType, 
                            filteredHolidays, 
                            season, 
                            seasonIntersect,
                            fixedPrices));
                    }
                }
            }
            foreach (var task in tasks)
            {
                var accumulator = await task;
                tariffPrice.PriceInfo.PowerPrices.AddRange(accumulator.TariffPrice.PriceInfo.PowerPrices);
                tariffPrice.PriceInfo.EnergyPrices.AddRange(accumulator.TariffPrice.PriceInfo.EnergyPrices);
                tariffPrice.Hours.AddRange(accumulator.TariffPrice.Hours);
            }
        }

        private async Task<SeasonDataAccumulator> ProcessSeasonAsync(
            TariffPrice tariffPrice, 
            Models.PriceStructure.TariffPrice tariffPricePrice, 
            Models.PriceStructure.TariffType tariffType, 
            List<Holiday> filteredHolidays, 
            Models.PriceStructure.Season season, 
            TimePeriod seasonIntersect,
            FixedPrices fixedPrices)
        {
            var accumulator = InitAccumulator(tariffPricePrice,
                seasonIntersect.StartDate,
                seasonIntersect.EndDate);

            accumulator = await ProcessSeasonAsync(accumulator,
                season,
                seasonIntersect.StartDate,
                seasonIntersect.EndDate,
                filteredHolidays,
                tariffType,
                fixedPrices
                );
            return accumulator;
        }

        async Task<SeasonDataAccumulator> ProcessSeasonAsync(SeasonDataAccumulator dataAccumulator,
            Models.PriceStructure.Season season,
            DateTimeOffset paramFromDate,
            DateTimeOffset paramToDate,
            List<Holiday> holidays,
            Models.PriceStructure.TariffType tariffType,
            FixedPrices fixedPrices)
        {
            if (season.PowerPrices != null)
            {
                var powerPrice = new PowerPrices
                {
                    Id = Guid.NewGuid().ToString(),
                    StartDate = _serviceHelper.ToConfiguredTimeZone(paramFromDate),
                    EndDate = _serviceHelper.ToConfiguredTimeZone(paramToDate),
                    PriceLevels = new List<PowerPriceLevel>()
                };

                dataAccumulator.TariffPrice.PriceInfo.PowerPrices.Add(powerPrice);
            }

            List<int> daysInMonthToBeProcessed = GetDistinctFixedPriceMonths(paramFromDate, paramToDate);
            dataAccumulator = AddPriceLevels(dataAccumulator, season, paramFromDate, paramToDate, daysInMonthToBeProcessed);

            var fromDate = paramFromDate;
            while (fromDate < paramToDate)
            {
                var currMonthEndToDate = GetNextMonthEndDate(fromDate, paramToDate);
                var fromDateLocaled = _serviceHelper.ToConfiguredTimeZone(fromDate);
                if (season.Months.Contains(fromDateLocaled.Month))
                {
                    var daysInMonth = DateTime.DaysInMonth(fromDateLocaled.Year, fromDateLocaled.Month);
                    var hourSeasonIndex = BuildHourSeasonIndex(
                        dataAccumulator.TariffPrice.PriceInfo, 
                        season.EnergyPrice, 
                        daysInMonth, 
                        tariffType.UsePublicHolidayOverride, 
                        tariffType.UseWeekendPriceOverride, 
                        fixedPrices);

                    var filteredHolidays = holidays.Where(a => a.Date >= fromDate && a.Date <= currMonthEndToDate).ToList();
                    dataAccumulator = await ProcessMonthAsync(dataAccumulator, fromDate, currMonthEndToDate, hourSeasonIndex, filteredHolidays, tariffType.Resolution);
                }
                fromDate = currMonthEndToDate;
            }
            return dataAccumulator;
        }
        public FixedPrices GenerateFixedPrices(DateTimeOffset fromDateUtc,
            DateTimeOffset toDateUtc,
            Models.PriceStructure.FixedPrices fixedPricesPrices,
            IReadOnlyList<Models.PriceStructure.FixedPriceTax> fixedPriceTaxes)
        {
            var retVal = new FixedPrices()
            {
                Id = fixedPricesPrices.Id,
                StartDate = _serviceHelper.ToConfiguredTimeZone(fromDateUtc),
                EndDate = _serviceHelper.ToConfiguredTimeZone(toDateUtc),
                PriceLevels = new List<FixedPriceLevel>()
            };
            List<int> daysInMonthToBeProcessed = GetDistinctFixedPriceMonths(fromDateUtc, toDateUtc);


            foreach (var pricesFixedPriceLevel in fixedPricesPrices.FixedPriceLevel)
            {
                var priceLevel = PriceLevelPriceToFixedPriceLevel(pricesFixedPriceLevel, fixedPriceTaxes);
                foreach (var daysInMonth in daysInMonthToBeProcessed)
                {
                    priceLevel.HourPrices.Add(CalcMonthlyFixedPrices(pricesFixedPriceLevel, fixedPriceTaxes, daysInMonth, Guid.NewGuid().ToString()));
                }
                retVal.PriceLevels.Add(priceLevel);

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
                var fixedPriceLevel = fixedPrices.PriceLevels.FirstOrDefault(a => a.Id == fixedPricesPrice.Id);
                if (fixedPriceLevel == null)
                {
                    fixedPriceLevel = PriceLevelPriceToFixedPriceLevel(fixedPricesPrice, fixedPriceTaxes);
                    fixedPrices.PriceLevels.Add(fixedPriceLevel);
                }
                if (!fixedPriceLevel.HourPrices.Any(x => x.NumberOfDaysInMonth == daysInMonth))
                {
                    fixedPriceLevel.HourPrices.Add(CalcMonthlyFixedPrices(fixedPricesPrice, fixedPriceTaxes, daysInMonth, daysInMonthHourIdentificator));
                }
            }
        }

        public List<int> GetDistinctFixedPriceMonths(DateTimeOffset fromDateUtc, DateTimeOffset toDateUtc)
        {
            var fromDateLocaled = _serviceHelper.ToConfiguredTimeZone(fromDateUtc);
            fromDateLocaled = fromDateLocaled.AddDays(1 - fromDateLocaled.Day);
            fromDateLocaled = fromDateLocaled.AddHours(-fromDateLocaled.Hour);
            var toDateLocaled = _serviceHelper.ToConfiguredTimeZone(toDateUtc);

            List<int> daysInMonthToBeProcessed = new List<int>();
            while (fromDateLocaled < toDateLocaled)
            {
                var daysInMonth = DateTime.DaysInMonth(fromDateLocaled.Year, fromDateLocaled.Month);
                daysInMonthToBeProcessed.Add(daysInMonth);
                fromDateLocaled = fromDateLocaled.AddMonths(1);
            }
            return daysInMonthToBeProcessed.Distinct().ToList();
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

        private SeasonDataAccumulator AddPriceLevels(SeasonDataAccumulator dataAccumulator, Models.PriceStructure.Season season, DateTimeOffset paramFromDate, DateTimeOffset paramToDate, List<int> daysInMonths)
        {
            dataAccumulator = AddPowerPrices(season.PowerPrices, daysInMonths, dataAccumulator);
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
            Models.PriceStructure.EnergyPrice energyPrice
            , int daysInMonth,
            string usePublicHolidayOverride,
            string useWeekendPriceOverride,
            FixedPrices fixedPrices)

        {
            var retVal = new HourSeasonIndex();
            if (fixedPrices != null)
            {
                var monthPrice = fixedPrices.PriceLevels.FirstOrDefault().HourPrices.FirstOrDefault(a => a.NumberOfDaysInMonth == daysInMonth);
                retVal.FixedPriceValue = new PriceElement
                {
                    Id = fixedPrices.Id,
                    IdDaysInMonth = monthPrice.Id
                };
            }
            var powerPrice = accumulatorPriceInfo.PowerPrices.FirstOrDefault();
            if (powerPrice != null)
            {
                var monthPrice = powerPrice.PriceLevels.FirstOrDefault().HourPrices.FirstOrDefault(a => a.NumberOfDaysInMonth == daysInMonth);
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

        async Task<SeasonDataAccumulator> ProcessMonthAsync(SeasonDataAccumulator dataAccumulator,
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

                DateTimeOffset toDate = _serviceHelper.DecideEndOfDay(paramToDate, fromDate);
                dataAccumulator = await ProcessDayAsync(dataAccumulator, fromDate, toDate, hourSeasonIndex, tariffResolutionMinutes, isPublicHoliday, isWeekend);

                fromDate = toDate;
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

        async Task<SeasonDataAccumulator> ProcessDayAsync(SeasonDataAccumulator dataAccumulator
            , DateTimeOffset paramFromDate
            , DateTimeOffset paramToDate
            , HourSeasonIndex hourSeasonIndex
            , int resolution,
            bool isPublicHoliday,
            bool isWeekend)
        {
            var fromDate = paramFromDate;
            var endDate = fromDate;
            EnergyInformation energyInformation = await DecideEneryInformation(hourSeasonIndex, isPublicHoliday, isWeekend);
            while (endDate < paramToDate)
            {
                endDate = fromDate.AddMinutes(resolution);
                var priceData = ToHour(fromDate, endDate, hourSeasonIndex, energyInformation, isPublicHoliday);
                dataAccumulator.TariffPrice.Hours.Add(priceData);
                fromDate = endDate;
            }
            return dataAccumulator;
        }

        public Task<EnergyInformation> DecideEneryInformation(HourSeasonIndex hourSeasonIndex, bool isPublicHoliday, bool isWeekend)
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
            return Task.FromResult(energyInformation);
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


        public void AppendEnergyPriceLevels(
            Models.Digin.PriceInfo priceInfo,
            Models.PriceStructure.EnergyPrice energyPricePrices,
            IReadOnlyList<Models.PriceStructure.EnergyPriceTax> energyPriceTaxes,
            string season,
            DateTimeOffset fromDate,
            DateTimeOffset toDate)
        {
            if (energyPricePrices?.EnergyPriceLevel != null)
            {
                foreach (var energyPriceLevelPrice in energyPricePrices.EnergyPriceLevel)
                {
                    var energyPriceLevel = priceInfo.EnergyPrices?.FirstOrDefault(a => a.Id == energyPriceLevelPrice.Id);
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

            var vatTaxPercentage = LookupEnergyPriceTaxValue(energyPriceTaxes, "vat", true);
            var consumptionTaxValue = LookupEnergyPriceTaxValue(energyPriceTaxes, "consumptionTax", false);
            var enovaTaxValue = LookupEnergyPriceTaxValue(energyPriceTaxes, "enovaTax", false);

            retval.Id = energyPriceLevel.Id;
            retval.StartDate = _serviceHelper.ToConfiguredTimeZone(fromDate);
            retval.EndDate = _serviceHelper.ToConfiguredTimeZone(toDate);
            retval.Season = season;

            retval.Level = energyPriceLevel.Level;

            // Prices and taxes in absolute prices (kr/kWh or similar). VAT is calculated as a percentage of the sum of other prices and taxes.
            retval.EnergyExTaxes = energyPriceLevel.EnergyExTaxes;
            retval.TotalExVat = energyPriceLevel.EnergyExTaxes + consumptionTaxValue + enovaTaxValue;
            retval.Total = AddVatTax(retval.TotalExVat, vatTaxPercentage);
            retval.Taxes = retval.Total - retval.EnergyExTaxes;

            retval.Currency = energyPricePrices.Currency;
            retval.MonetaryUnitOfMeasure = energyPricePrices.MonetaryUnitOfMeasure;

            retval.Total = RoundDouble(retval.Total, Constants.EnergyPriceDecimals);
            retval.TotalExVat = RoundDouble(retval.TotalExVat, Constants.EnergyPriceDecimals);
            retval.EnergyExTaxes = RoundDouble(retval.EnergyExTaxes, Constants.EnergyPriceDecimals);
            retval.Taxes = RoundDouble(retval.Taxes, Constants.EnergyPriceDecimals);
            return retval;
        }

        private static double LookupEnergyPriceTaxValue(IReadOnlyList<EnergyPriceTax> energyPriceTaxes, string taxType, bool requirePercentage)
        {
            // TODO: vurdere om vi må sjekke gyldighetsperiode for tax ift. gjeldende periode her.
            var tax = energyPriceTaxes?.FirstOrDefault(x => x.TaxType == taxType);

            if (tax == null)
            {
                return 0.0;
            }

            if (requirePercentage && tax.TaxUom != "%")
            {
                throw new GridTariffLibException($"{taxType} is expected to have unit of measure %, but is specified in {tax.TaxUom}, which is not supported");
            }

            return tax.TaxValue;
        }

        SeasonDataAccumulator AddPowerPrices(
            Models.PriceStructure.PowerPrices powerPricePrices,
            List<int> daysInMonths,
            SeasonDataAccumulator dataAccumulator)
        {
            AppendPowerPriceLevels(
                dataAccumulator.TariffPrice.PriceInfo.PowerPrices?.FirstOrDefault(),
                powerPricePrices,
                dataAccumulator.Taxes.PowerPriceTaxes,
                daysInMonths);
            return dataAccumulator;
        }


        public void AppendPowerPriceLevels(
            Models.Digin.PowerPrices powerPrices,
            Models.PriceStructure.PowerPrices powerPricePrices,
            IReadOnlyList<Models.PriceStructure.PowerPriceTax> powerPriceTaxes,
            List<int> daysInMonths)
        {
            if (powerPricePrices?.PowerPriceLevel != null)
            {
                foreach (var powerPricePrice in powerPricePrices?.PowerPriceLevel)
                {
                    var powerPriceLevel = PriceLevelPowerPriceToPowerPriceLevel(powerPricePrice, powerPriceTaxes);
                    foreach (var daysInMonth in daysInMonths)
                    {
                        powerPriceLevel.HourPrices.Add(CalcMonthlyPowerPrices(powerPricePrice, powerPriceTaxes, daysInMonth));
                    }
                    powerPrices.PriceLevels.Add(powerPriceLevel);
                }

            }
        }

        public Models.Digin.HourPowerPrices CalcMonthlyPowerPrices(
            Models.PriceStructure.PowerPriceLevel powerPriceLevel,
            IReadOnlyList<Models.PriceStructure.PowerPriceTax> powerPriceTaxes,
            int daysInMonth)
        {
            var vatTax = powerPriceTaxes?.FirstOrDefault(x => x.TaxType == "vat");
            double vatTaxValue = vatTax != null ? vatTax.TaxValue : 0;
            int hoursInMonth = daysInMonth * Constants.HoursInDay;

            var activeTotalExVat = powerPriceLevel.MonthlyActivePowerExTaxes / hoursInMonth;
            var activeTotal = AddVatTax(activeTotalExVat, vatTaxValue);
            var reactiveTotalExVat = powerPriceLevel.MonthlyReactivePowerExTaxes / hoursInMonth;
            var reactiveTotal = AddVatTax(reactiveTotalExVat, vatTaxValue);

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
            var vatTax = powerPriceTaxes?.FirstOrDefault(x => x.TaxType == "vat");
            double vatTaxValue = vatTax != null ? vatTax.TaxValue : 0;
            powerPriceLevel.MonthlyActivePowerExTaxes = powerPriceLevelPrice.MonthlyActivePowerExTaxes;
            powerPriceLevel.MonthlyActivePowerTotalExVat = powerPriceLevelPrice.MonthlyActivePowerExTaxes;
            powerPriceLevel.MonthlyActivePowerTotal = AddVatTax(powerPriceLevel.MonthlyActivePowerExTaxes, vatTaxValue);
            powerPriceLevel.MonthlyActivePowerTaxes = powerPriceLevel.MonthlyActivePowerTotal - powerPriceLevel.MonthlyActivePowerTotalExVat;

            powerPriceLevel.MonthlyReactivePowerExTaxes = powerPriceLevelPrice.MonthlyReactivePowerExTaxes;
            powerPriceLevel.MonthlyReactivePowerTotalExVat = powerPriceLevelPrice.MonthlyReactivePowerExTaxes;
            powerPriceLevel.MonthlyReactivePowerTotal = AddVatTax(powerPriceLevel.MonthlyReactivePowerExTaxes, vatTaxValue);
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
            retVal.MonthlyTotal = AddVatTax(priceLevel.MonthlyFixedExTaxes, vatTaxValue);
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
                Total = RoundDouble(AddVatTax(totalExVatPerHour, vatTaxValue), Constants.FixedPricesDecimals)
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

        public double AddVatTax(double input, double vat)
        {
            return input + (input * (vat / 100));
        }

        public DateTimeOffset GetNextMonthEndDate(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            var localedToDate = _serviceHelper.GetStartOfNextMonth(fromDate);
            if (localedToDate < toDate)
            {
                return localedToDate;
            }
            return toDate;
        }

    }
}
