using GridTariffApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GridTariffApi.Database
{
    public class ElviaDbContext : DbContext
    {
        public ElviaDbContext(DbContextOptions<ElviaDbContext> options)
            : base(options) { }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<MeteringPointTariff> MeteringPointTariff { get; set; }
        public virtual DbSet<PriceStructure> PriceStructure { get; set; }
        public virtual DbSet<SyncStatus> SyncStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasKey(e => e.Id);
            modelBuilder.Entity<Company>().HasIndex(e => e.OrgNumber)
                .IsUnique();

            modelBuilder.Entity<SyncStatus>().HasKey(e => e.Id);
            modelBuilder.Entity<SyncStatus>().HasIndex(e => e.Table)
                .IsUnique();

            modelBuilder.Entity<MeteringPointTariff>().HasKey(e => e.Id);
            modelBuilder.Entity<MeteringPointTariff>().HasIndex(e => e.MeteringPointId)
                .IsUnique();

            modelBuilder.Entity<PriceStructure>().HasKey(e => e.Id);
        }
    }
}
