using Kunde.TariffApi.EntityFramework;
using Kunde.TariffApi.Models.TariffQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kunde.TariffApiTests
{
    public class TestHelper
    {
        public TestHelper()
        {
            
        }

        public Company GetCompanyElvia ()
        {
            return new Company()
            {
                Id = 1,
                Company1 = "Elvia AS"
            };
        }

        public Company GetCompanyFoobar()
        {
            return new Company()
            {
                Id = 2,
                Company1 = "Foobar Inc"
            };
        }

        public Tarifftype GetTariffRush()
        {
            return new Tarifftype()
            {
                Tariffkey = "private_tou_rush",
                Companyid = 1,
                Customertype = "private",
                Title = "Nettleie Rush & Ro",
                Resolution = 60,
                Description = "Tariff focused on lowering energy consumption during high consumption periods of the day"
            };
        }

        public Tarifftype GetTariffDayNight()
        {
            return new Tarifftype()
            {
                Tariffkey = "private_tou_daynight",
                Companyid = 1,
                Customertype = "private",
                Title = "Nettleie Dag&Natt",
                Resolution = 60,
                Description = "Tariff focused on moving energy consumption from day to night"
            };
        }


        public bool Contains(List<TariffApi.Models.TariffType> model, Tarifftype db)
        {
            foreach (var tariffType in model)
            {
                if (
                    tariffType.Company.Equals(db.Company.Company1)
                    && tariffType.CustomerType.Equals(db.Customertype)
                    && tariffType.Title.Equals(db.Title)
                    && tariffType.Resolution.Equals(db.Resolution)
                    && tariffType.Description.Equals(db.Description))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
