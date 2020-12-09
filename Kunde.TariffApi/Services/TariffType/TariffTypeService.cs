﻿using Kunde.TariffApi.EntityFramework;
using Kunde.TariffApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Kunde.TariffApi.Services.TariffType
{
    public class TariffTypeService : ITariffTypeService
    {
        private readonly TariffContext _tariffContext;
        public TariffTypeService(TariffContext tariffContext)
        {
            _tariffContext = tariffContext;
        }

        public TariffTypeContainer GetTariffTypes()
        {
            TariffTypeContainer tariffTypeContainer = new TariffTypeContainer();
            tariffTypeContainer.TariffTypes = _tariffContext.TariffType.Include(t => t.Company).Select(tariffType => new Models.TariffType
            {
                TariffKey = tariffType.TariffKey,
                Company = tariffType.Company.CompanyName,
                CustomerType = tariffType.CustomerType,
                Title = tariffType.Title,
                Resolution = tariffType.Resolution,
                Description = tariffType.Description
            }).ToList();
            return tariffTypeContainer;
        }
    }
}
