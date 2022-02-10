using GridTariffApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GridTariffApi.Database
{
    public class ElviaDbContext : DbContext
    {
        public ElviaDbContext(DbContextOptions<ElviaDbContext> options)
            : base(options) { }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<MeteringPointTariff> MeteringPointTariff { get; set; }
        public virtual DbSet<PriceStructure> PriceStructure { get; set; }
        public virtual DbSet<IntegrationConfig> IntegrationConfig { get; set; }

    }
}
