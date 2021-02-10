using GridTariffApi.Lib.EntityFramework;
using GridTariffApi.Lib.Models.Internal;
using GridTariffApi.Lib.Models.TariffQuery;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GridTariffApi.Lib.Services.TariffQuery
{
    public class TariffQueryService : ITariffQueryService
    {
        private readonly TariffContext _tariffContext;

        private readonly int _fixedPriceUnitOfMeasureId = 4;
        private static string _lowTariffHours = "0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23";

        public TariffQueryService(TariffContext tariffContext)
        {
            _tariffContext = tariffContext;
        }

        public TariffQueryRequestMeteringPointsResult QueryTariff(List<string> meteringPoints, DateTime startDateTime, DateTime endDateTime)
        {
            var result = new TariffQueryRequestMeteringPointsResult() { GridTariffCollections = new List<GridTariffCollection>()};
            var meteringPointTariffs = GetMeteringPointTariffs(meteringPoints);

            foreach (var tariffKey in meteringPointTariffs.Select(x => x.GridTariff).Distinct().ToList())
            {
                var gridTariffCollection = new GridTariffCollection() { };
                gridTariffCollection.GridTariff = QueryTariff(tariffKey, startDateTime, endDateTime).GridTariff;
                gridTariffCollection.MeteringPointIds = meteringPointTariffs.Where(x => x.GridTariff.Equals(tariffKey)).Select(y => y.MeteringPoint).ToList();
                result.GridTariffCollections.Add(gridTariffCollection);
            }
            return result;
        }

        public List<GridTariffWithMeteringPoints> GetMeteringPointTariffs(List<string> meteringPoints)
        {
            return _tariffContext.MeteringPointProducts.Where(m => meteringPoints.Contains(m.MeteringpointId)).Select(
                s => new GridTariffWithMeteringPoints
                {
                    MeteringPoint = s.MeteringpointId,
                    GridTariff = s.TariffKey
                }).ToList();
        }

        public TariffQueryResult QueryTariff(string tariffKey, DateTime paramFromDate, DateTime paramToDate)
        {
            DateTime dbQueryFromDate = paramFromDate.Date;
            DateTime dbQueryToDate = paramToDate.Date.AddDays(1).AddMinutes(-1);

            String fixedPriceUnitOfMeasure = _tariffContext.Uom.Where(u => u.Id == _fixedPriceUnitOfMeasureId).FirstOrDefault().Unit;
            var tariffType = _tariffContext.TariffType.Where(t => t.TariffKey.Equals(tariffKey)).Include(t => t.Company).FirstOrDefault();
            Dictionary<DateTime, String> publicHolidays = _tariffContext.PublicHoliday.Where(
                p => p.HolidayDate >= dbQueryFromDate
                && p.HolidayDate <= dbQueryToDate)
                .ToDictionary(p => p.HolidayDate, p => p.Description);

            TariffQueryResult tariffQueryResult = InitTariffQueryResult(tariffType);
            tariffQueryResult = ProcessTimePeriodPerDay(paramFromDate, paramToDate, tariffType.Id, fixedPriceUnitOfMeasure, publicHolidays, tariffQueryResult);
            return tariffQueryResult;
        }

        private TariffQueryResult ProcessTimePeriodPerDay(DateTime paramFromDate,
            DateTime paramToDate,
            int tariffTypeId,
            string fixedPriceUnitOfMeasure,
            Dictionary<DateTime, String> publicHolidays,
            TariffQueryResult tariffQueryResult)
        {
            int currMonth = int.MinValue;
            Dictionary<int, FixedPriceConfig> currFixedPrices = null;
            Dictionary<int, VariablePriceConfig> currVariablePrices = null;
            List<FixedPrices> currentFixedPrices = null;
            String currSeason = String.Empty;

            while (paramFromDate <= paramToDate)
            {
                DateTime queryToDate = GetNextToDate(paramFromDate, paramToDate);
                bool isPublicHoliday = publicHolidays.ContainsKey(paramFromDate.Date);

                if (currMonth != paramFromDate.Month)   //new month, find appropiate tariffs/season, calculate fixed tariffs
                {
                    currFixedPrices = GetFixedPricesForGivenMonth(paramFromDate, queryToDate, tariffTypeId);
                    currVariablePrices = GetVariablePricesForGivenMonth(paramFromDate, queryToDate, tariffTypeId);
                    currentFixedPrices = CalculateFixedPricesForGivenMonth(currFixedPrices, paramFromDate.Year, paramFromDate.Month, fixedPriceUnitOfMeasure);
                    currSeason = currFixedPrices.First().Value.Season.Description;
                    currMonth = paramFromDate.Month;
                }
                tariffQueryResult.GridTariff.TariffPrice.PriceInfo.AddRange(
                    ProcessDay(paramFromDate,
                        queryToDate,
                        isPublicHoliday,
                        currentFixedPrices,
                        currVariablePrices,
                        currSeason));

                paramFromDate = paramFromDate.AddDays(1).Date;
            }
            return tariffQueryResult;
        }

        private static TariffQueryResult InitTariffQueryResult(EntityFramework.TariffType tariffType)
        {
            return new TariffQueryResult()
            {
                GridTariff = new GridTariff
                {
                    TariffType = new Models.TariffQuery.TariffType()
                    {
                        TariffKey = tariffType.TariffKey,
                        Company = tariffType.Company.CompanyName,
                        CustomerType = tariffType.CustomerType,
                        Title = tariffType.Title,
                        Resolution = tariffType.Resolution,
                        Description = tariffType.Description,
                    },
                    TariffPrice = new TariffPrice()
                    {
                        PriceInfo = new List<PriceInfo>()
                    }
                }
            };
        }

        private static DateTime GetNextToDate(DateTime queryFromDate, DateTime paramToDate)
        {
            if (queryFromDate.Date == paramToDate.Date)     //last day to process, limit to hhmmdd as in request
            {
                return paramToDate;
            }
            return queryFromDate.Date.AddDays(1).AddMinutes(-1); //not last day to process, process to end of day
        }

        private Dictionary<int, VariablePriceConfig> GetVariablePricesForGivenMonth(DateTime queryFromDate, DateTime queryToDate, int tariffTypeId)
        {
            return _tariffContext.VariablePriceconfig.Where(v => v.TariffTypeDd == tariffTypeId
                && v.MonthNo == queryFromDate.Month
                && v.PriceFromDate.Date <= queryToDate.Date
                && v.PriceToDate.Date >= queryFromDate.Date)
                .Include(v => v.Uom)
                .Include(v => v.PriceLevel)
                .ToDictionary(v => v.Id, v => v);
        }

        private Dictionary<int, FixedPriceConfig> GetFixedPricesForGivenMonth(DateTime queryFromDate, DateTime queryToDate, int tariffTypeId)
        {
            return _tariffContext.FixedPriceConfig.Where(f => f.TariffTypeId == tariffTypeId
                && f.MonthNo == queryFromDate.Month
                && f.PriceFromDate.Date <= queryToDate.Date
                && f.PriceToDate.Date >= queryFromDate.Date)
                .Include(f => f.PriceLevel)
                .Include(f => f.Uom)
                .Include(f => f.Season)
                .ToDictionary(f => f.Id, f => f);
        }

        private List<PriceInfo> ProcessDay(DateTime fromTime,
            DateTime toTime,
            bool isPublicHoliday,
            List<FixedPrices> fixedPrices,
            Dictionary<int, VariablePriceConfig> variablePrices,
            String season)
        {
            var priceInfos = new List<PriceInfo>();
            bool isLowTariff = isPublicHoliday || fromTime.DayOfWeek == DayOfWeek.Saturday || fromTime.DayOfWeek == DayOfWeek.Sunday;
            Dictionary<int, VariablePrice> calculatedVariablePrices = CalcVariablePricesDay(variablePrices, fromTime.Hour, toTime.Hour, isLowTariff);

            while (fromTime.Date == toTime.Date && fromTime.Hour <= toTime.Hour)
            {
                priceInfos.Add(new PriceInfo()
                {
                    StartTime = fromTime.Date.AddHours(fromTime.Hour),
                    ExpiredAt = fromTime.Date.AddHours(fromTime.Hour + 1),
                    HoursShortName = $"{fromTime.Hour.ToString().PadLeft(2, '0')}-{(fromTime.Hour + 1).ToString().PadLeft(2, '0')}",
                    Season = season,
                    PublicHoliday = isPublicHoliday,
                    FixedPrices = fixedPrices,
                    VariablePrice = calculatedVariablePrices[fromTime.Hour]
                });
                fromTime = fromTime.AddHours(1);
            }
            return priceInfos;
        }

        private Dictionary<int, VariablePrice> CalcVariablePricesDay(Dictionary<int, VariablePriceConfig> variablePrices, int fromHour, int toHour, bool isLowTariff)
        {
            if (isLowTariff)
            {
                var calculatedVariablePrices = new Dictionary<int, VariablePrice>();
                IEnumerable<int> configHours = from hour in _lowTariffHours.Split(';') select int.Parse(hour);

                VariablePriceConfig lowTariffVariablePriceConfig = variablePrices.OrderBy(v => v.Value.PriceLevel.SortOrder).FirstOrDefault().Value;
                CalcVariablePricesDay(fromHour, toHour, calculatedVariablePrices, lowTariffVariablePriceConfig, configHours);
                return calculatedVariablePrices;
            }
            return CalcVariablePricesDay(fromHour, toHour, variablePrices);
        }

        Dictionary<int, VariablePrice> CalcVariablePricesDay(int fromHour, int toHour, Dictionary<int, VariablePriceConfig> variablepriceconfigs)
        {
            Dictionary<int, VariablePrice> variablePrices = new Dictionary<int, VariablePrice>();
            foreach (VariablePriceConfig variablePriceConfig in variablepriceconfigs.Values)
            {
                IEnumerable<int> configHours = from hour in variablePriceConfig.Hours.Split(';') select int.Parse(hour);
                CalcVariablePricesDay(fromHour, toHour, variablePrices, variablePriceConfig, configHours);
            }
            return variablePrices;
        }

        private void CalcVariablePricesDay(int fromHour, int toHour, Dictionary<int, VariablePrice> variablePrices, VariablePriceConfig variablePriceConfig, IEnumerable<int> configHours)
        {
            IEnumerable<int> matchedHours = configHours.Where(h => fromHour <= h && h <= toHour);
            foreach (int matchedHour in matchedHours)
            {
                variablePrices.Add(matchedHour,
                new VariablePrice()
                {
                    Total = variablePriceConfig.Total,
                    Energy = variablePriceConfig.Energy,
                    Power = variablePriceConfig.Power,
                    Taxes = variablePriceConfig.TaxMva + variablePriceConfig.TaxEnova + variablePriceConfig.TaxEnergy,
                    Level = variablePriceConfig.PriceLevel.PriceLevelDescription,
                    Currency = variablePriceConfig.Uom.Currency,
                    Uom = variablePriceConfig.Uom.Unit
                });
            }
        }

        private List<FixedPrices> CalculateFixedPricesForGivenMonth(Dictionary<int, FixedPriceConfig> fixedpriceconfigs, int year, int month, string unitOfMeasure)
        {
            const int hoursInDay = 24;
            var fixedPrices = new List<FixedPrices>();
            int daysInMonth = DateTime.DaysInMonth(year, month);

            foreach (FixedPriceConfig fixedPriceConfig in fixedpriceconfigs.Values)
            {
                var fixedPriceConfigContainer = new FixedPrices() { PriceLevel = new List<Models.TariffQuery.PriceLevel>() };
                var priceLevel = new Models.TariffQuery.PriceLevel()
                {
                    Level = fixedPriceConfig.PriceLevel.PriceLevel,
                    LevelInfo = fixedPriceConfig.PriceLevel.LevelInfo,
                    Taxes = decimal.Round((fixedPriceConfig.Taxes / (daysInMonth * hoursInDay)), 4),
                    Fixed = decimal.Round((fixedPriceConfig.Fixed / (daysInMonth * hoursInDay)), 4),
                    Currency = fixedPriceConfig.Uom.Currency,
                    Uom = unitOfMeasure
                };
                priceLevel.Total = priceLevel.Taxes + priceLevel.Fixed;
                fixedPriceConfigContainer.PriceLevel.Add(priceLevel);
                fixedPrices.Add(fixedPriceConfigContainer);
            }
            return fixedPrices;
        }
    }
}
