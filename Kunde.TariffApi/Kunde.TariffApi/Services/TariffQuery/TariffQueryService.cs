using Kunde.TariffApi.EntityFramework;
using Kunde.TariffApi.Models.TariffQuery;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Kunde.TariffApi.Services.TariffQuery
{
    public class TariffQueryService : ITariffQueryService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly TariffContext _tariffContext;

        private readonly int _fixedPriceUomId = 4;
        private Uom _fixedPriceUom = null;
        private static string _lowTariffHours = "0;1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23";

        public TariffQueryService(IServiceScopeFactory scopeFactory, TariffContext tariffContext)
        {
            _scopeFactory = scopeFactory;
            _tariffContext = tariffContext;
        }

        public TariffQueryResult QueryTariff(string tariffKey, DateTime paramFromDate, DateTime paramToDate)
        {
            TariffQueryResult tariffQueryResult = new TariffQueryResult();
            DateTime queryFromDate = new DateTime(paramFromDate.Year, paramFromDate.Month, paramFromDate.Day);
            DateTime queryToDate = new DateTime(paramToDate.Year, paramToDate.Month, paramToDate.Day, 23, 59, 59);

            IEnumerable<int> relevantMonths = Enumerable.Range(0, 13).Select(a => queryFromDate.AddMonths(a))
                   .TakeWhile(a => a < queryToDate)
                   .Select(a => a.Month);

            using (IServiceScope scope = _scopeFactory.CreateScope())
            {
                using (TariffContext dbContext = scope.ServiceProvider.GetRequiredService<TariffContext>())
                {
                    Tarifftype tariffType = dbContext.Tarifftype.Where(t => t.Tariffkey.Equals(tariffKey)).FirstOrDefault();
                    Company company = dbContext.Company.Where(c => c.Id == tariffType.Companyid).FirstOrDefault();

                    Dictionary<int, Uom> uoms = dbContext.Uom.ToDictionary(u => u.Id, u=> u);
                    _fixedPriceUom = uoms[_fixedPriceUomId];

                    Dictionary<DateTime,String> publicHolidays = dbContext.Publicholiday.Where(p => p.Holidaydate >= queryFromDate && p.Holidaydate <= queryToDate)
                        .ToDictionary(p => p.Holidaydate,p => p.Description);
                    List<Season> seasons = dbContext.Season.ToList();

                    List<Fixedpricelevel> fixedPriceLevels = dbContext.Fixedpricelevel.ToList();
                    Dictionary<int,Fixedpriceconfig> fixedPrices = dbContext.Fixedpriceconfig.
                        Where(f => f.Tarifftype.Tariffkey.Equals(tariffKey)
                            && f.Pricefromdate < queryToDate
                            && f.Pricetodate > queryFromDate
                            && relevantMonths.Contains(f.Monthno)).ToDictionary(f=>f.Id, f => f);

                    List<Pricelevel> priceLevels = dbContext.Pricelevel.ToList();
                    Dictionary<int,Variablepriceconfig> variablePrices = dbContext.Variablepriceconfig.
                        Where(v => v.Tarifftype.Tariffkey.Equals(tariffKey)
                            && v.Pricefromdate < queryToDate
                            && v.Pricetodate > queryFromDate
                            && relevantMonths.Contains(v.Monthno)).ToDictionary(v => v.Id, v => v); ;

                    tariffQueryResult.GridTariff = new GridTariff
                    {
                        TariffType = new Models.TariffQuery.TariffType()
                        {
                            Company = tariffType.Company.Company1,
                            CustomerType = tariffType.Customertype,
                            Title = tariffType.Title,
                            Resolution = tariffType.Resolution,
                            Description = tariffType.Description,
                        },
                        TariffPrice = new TariffPrice()
                        {
                            PriceInfo = new List<PriceInfo>()
                        }
                    };

                    IDictionary<int,Fixedpriceconfig> currFixedPrices = null;
                    IDictionary<int,Variablepriceconfig> currVariablePrices = null;
                    Season currSeason = null;
                    int currMonth = -1;
                    while (queryFromDate <= paramToDate)
                    {
                        queryToDate = new DateTime(queryFromDate.Year, queryFromDate.Month, queryFromDate.Day, 23, 59, 59);
                        if (queryFromDate.Date == paramToDate.Date)
                        {
                            queryToDate = paramToDate;
                        }

                        if (currMonth != queryFromDate.Month)
                        {
                            currFixedPrices = fixedPrices.Where(f => f.Value.Monthno == queryFromDate.Month).ToDictionary(f=>f.Key,f=>f.Value); //verified only changes at month (email)
                            currVariablePrices = variablePrices.Where(v => v.Value.Monthno == queryFromDate.Month).ToDictionary(v => v.Key, v => v.Value);
                            currSeason = currFixedPrices.First().Value.Season;
                            currMonth = queryFromDate.Month;
                        }

                        //todo do we really need to filter per day, or only changes per month?
                        IDictionary<int, Variablepriceconfig> currDayVariablePrices = currVariablePrices.Where(v => v.Value.Pricefromdate <= queryFromDate && v.Value.Pricetodate >= queryToDate)
                            .ToDictionary(v => v.Key, v => v.Value); ;

                        tariffQueryResult.GridTariff.TariffPrice.PriceInfo.AddRange(
                        ProcessDay(queryFromDate,
                            queryToDate,
                            ref publicHolidays,
                            ref currFixedPrices,                                
                            ref currDayVariablePrices,
                            ref currSeason));
                        queryFromDate = queryFromDate.AddDays(1);
                    }
                };
            };
            return tariffQueryResult;
        }

        private List<PriceInfo> ProcessDay(DateTime fromTime, DateTime toTime, ref Dictionary<DateTime,String> publicHolidays, ref IDictionary<int,Fixedpriceconfig> fixedPrices, ref IDictionary<int,Variablepriceconfig> variablePrices, ref Season season)
        {
            List<PriceInfo> priceInfos = new List<PriceInfo>();
            IDictionary<int, VariablePrice> calculatedVariablePrices = null;

            int fromHour = fromTime.Hour;
            int toHour = toTime.Hour;

            bool isPublicHoliday = publicHolidays.ContainsKey(fromTime.Date);
            bool isLowTariff = isPublicHoliday || fromTime.DayOfWeek == DayOfWeek.Saturday || fromTime.DayOfWeek == DayOfWeek.Sunday;

            List<FixedPrices> fixedPricesDay = GetMonthlyFixedPrices(ref fixedPrices, fromTime.Year, fromTime.Month);

            if (isLowTariff)
            {
                Variablepriceconfig lowTariffVariablePriceConfig = null;
                foreach (Variablepriceconfig variablepriceconfig in variablePrices.Values)
                {
                    if (lowTariffVariablePriceConfig == null || variablepriceconfig.Pricelevel.Sortorder < lowTariffVariablePriceConfig.Pricelevel.Sortorder)
                    {
                        lowTariffVariablePriceConfig = variablepriceconfig;
                    }
                }
                calculatedVariablePrices = new Dictionary<int, VariablePrice>();
                IEnumerable<int> configHours = from hour in _lowTariffHours.Split(';') select int.Parse(hour);
                CalcVariablePricesDay(fromHour, toHour, ref calculatedVariablePrices, lowTariffVariablePriceConfig,configHours);
            }
            else
            {
                calculatedVariablePrices = CalcVariablePricesDay(fromHour, toHour, ref variablePrices);
            }

            while (fromHour <= toHour)
            {
                PriceInfo priceInfo = new PriceInfo()
                {
                    StartTime = fromTime.AddHours(fromHour),
                    ExpireAt = fromTime.AddHours(fromHour + 1),
                    HoursShortName = $"{fromHour.ToString().PadLeft(2,'0')}-{(fromHour + 1).ToString().PadLeft(2, '0')}",
                    Season = season.Season1,
                    PublicHoliday = isPublicHoliday ? "yes" : "no"
                };
                priceInfo.FixedPrices = fixedPricesDay;
                priceInfo.VariablePrice = calculatedVariablePrices[fromHour];
                priceInfos.Add(priceInfo);
                fromHour++;
            }
            return priceInfos;
        }

        IDictionary<int, VariablePrice> CalcVariablePricesDay(int fromHour, int toHour, ref IDictionary<int,Variablepriceconfig> variablepriceconfigs)
        {
            IDictionary<int, VariablePrice> variablePrices = new Dictionary<int, VariablePrice>();
            foreach (Variablepriceconfig variablePriceConfig in variablepriceconfigs.Values)
            {
                IEnumerable<int> configHours = from hour in variablePriceConfig.Hours.Split(';') select int.Parse(hour);
                CalcVariablePricesDay(fromHour, toHour, ref variablePrices,variablePriceConfig, configHours);
            }
            return variablePrices;
        }

        private void CalcVariablePricesDay(int fromHour, int toHour, ref IDictionary<int, VariablePrice> variablePrices, Variablepriceconfig variablePriceConfig, IEnumerable<int> configHours)
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
                    Taxes = variablePriceConfig.Taxmva + variablePriceConfig.Taxenova + variablePriceConfig.Taxenergy,
                    Level = variablePriceConfig.Pricelevel.Pricelevel1,
                    Currency = variablePriceConfig.Uom.Currency,
                    Uom = variablePriceConfig.Uom.Uom1
                });
            }
        }

        private List<FixedPrices> GetMonthlyFixedPrices(ref IDictionary<int,Fixedpriceconfig> fixedpriceconfigs, int year, int month)
        {
            const int hoursInDay = 24;
            List<FixedPrices> fixedPrices = new List<FixedPrices>();
            int daysInMonth = DateTime.DaysInMonth(year, month);

            foreach (Fixedpriceconfig fixedPriceConfig in fixedpriceconfigs.Values)
            {
                FixedPrices fixedPriceConfigContainer  = new FixedPrices() { PriceLevel = new List<PriceLevel>() };

                PriceLevel priceLevel = new PriceLevel()
                {
                    Level = fixedPriceConfig.Pricelevel.Pricelevel,
                    LevelInfo = fixedPriceConfig.Pricelevel.Levelinfo,
                    Taxes = Decimal.Round((fixedPriceConfig.Taxes / (daysInMonth * hoursInDay)),4),
                    Fixed = Decimal.Round((fixedPriceConfig.Fixed / (daysInMonth * hoursInDay)),4),
                    Currency = fixedPriceConfig.Uom.Currency,
                    Uom = _fixedPriceUom.Uom1
                };
                priceLevel.Total = priceLevel.Taxes + priceLevel.Fixed;
                fixedPriceConfigContainer.PriceLevel.Add(priceLevel);
                fixedPrices.Add(fixedPriceConfigContainer);
            }
            return fixedPrices;
        }
    }
}
