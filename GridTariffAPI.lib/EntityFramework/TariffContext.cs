using Microsoft.EntityFrameworkCore;

namespace GridTariffApi.Lib.EntityFramework
{
    public partial class TariffContext : DbContext
    {
        public TariffContext()
        {
        }

        public TariffContext(DbContextOptions<TariffContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<FixedPriceConfig> FixedPriceConfig { get; set; }
        public virtual DbSet<FixedPriceLevel> FixedPriceLevel { get; set; }
        public virtual DbSet<PriceLevel> PriceLevel { get; set; }
        public virtual DbSet<PublicHoliday> PublicHoliday { get; set; }
        public virtual DbSet<Season> Season { get; set; }
        public virtual DbSet<TariffType> TariffType { get; set; }
        public virtual DbSet<UnitOfMeasure> Uom { get; set; }
        public virtual DbSet<VariablePriceConfig> VariablePriceconfig { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("company")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FixedPriceConfig>(entity =>
            {
                entity.ToTable("fixedpriceconfig");

                entity.HasIndex(e => new { e.TariffTypeId, e.SeasonId, e.MonthNo, e.PriceLevelId, e.PriceFromDate, e.PriceToDate })
                    .HasName("uc_fixedpriceconfig")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fixed)
                    .HasColumnName("fixed")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.MonthNo).HasColumnName("monthno");

                entity.Property(e => e.PriceFromDate)
                    .HasColumnName("pricefromdate")
                    .HasColumnType("date");

                entity.Property(e => e.PriceLevelId).HasColumnName("pricelevelid");

                entity.Property(e => e.PriceToDate)
                    .HasColumnName("pricetodate")
                    .HasColumnType("date");

                entity.Property(e => e.SeasonId).HasColumnName("seasonid");

                entity.Property(e => e.TariffTypeId).HasColumnName("tarifftypeid");

                entity.Property(e => e.Taxes)
                    .HasColumnName("taxes")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.UomId).HasColumnName("uomid");

                entity.HasOne(d => d.PriceLevel)
                    .WithMany(p => p.FixedPriceConfig)
                    .HasForeignKey(d => d.PriceLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fixedpric__price__5224328E");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.FixedPriceConfig)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fixedpric__seaso__531856C7");

                entity.HasOne(d => d.TariffType)
                    .WithMany(p => p.FixedPriceConfig)
                    .HasForeignKey(d => d.TariffTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fixedpric__tarif__540C7B00");

                entity.HasOne(d => d.Uom)
                    .WithMany(p => p.FixedPriceConfig)
                    .HasForeignKey(d => d.UomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fixedpric__uomid__55009F39");
            });

            modelBuilder.Entity<FixedPriceLevel>(entity =>
            {
                entity.ToTable("fixedpricelevel");

                entity.HasIndex(e => e.PriceLevel)
                    .HasName("UQ__fixedpri__EDDD99B6130E6CC1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LevelInfo)
                    .IsRequired()
                    .HasColumnName("levelinfo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PriceLevel)
                    .IsRequired()
                    .HasColumnName("pricelevel")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PriceLevel>(entity =>
            {
                entity.ToTable("pricelevel");

                entity.HasIndex(e => e.PriceLevelDescription)
                    .HasName("UQ__pricelev__EDDD99B6B060FA0B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PriceLevelDescription)
                    .IsRequired()
                    .HasColumnName("pricelevel")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SortOrder).HasColumnName("sortorder");
            });

            modelBuilder.Entity<PublicHoliday>(entity =>
            {
                entity.ToTable("publicholiday");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HolidayDate)
                    .HasColumnName("holidaydate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Season>(entity =>
            {
                entity.ToTable("season");

                entity.HasIndex(e => e.Description)
                    .HasName("UQ__season__BC91B170D949B744")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("season")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TariffType>(entity =>
            {
                entity.ToTable("tarifftype");

                entity.HasIndex(e => new { e.CustomerType, e.Title })
                    .HasName("uc_tarifftype")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("companyid");

                entity.Property(e => e.CustomerType)
                    .IsRequired()
                    .HasColumnName("customertype")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Resolution).HasColumnName("resolution");

                entity.Property(e => e.TariffKey)
                    .IsRequired()
                    .HasColumnName("tariffkey")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TariffType)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tarifftyp__compa__55F4C372");
            });

            modelBuilder.Entity<UnitOfMeasure>(entity =>
            {
                entity.ToTable("uom");

                entity.HasIndex(e => new { e.Currency, e.Unit })
                    .HasName("uc_uom")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasColumnName("currency")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasColumnName("uom")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VariablePriceConfig>(entity =>
            {
                entity.ToTable("variablepriceconfig");

                entity.HasIndex(e => new { e.TariffTypeDd, e.SeasonId, e.MonthNo, e.PriceLevelId, e.PriceFromDate, e.PriceToDate, e.Hours })
                    .HasName("uc_variablepriceconfig")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Energy)
                    .HasColumnName("energy")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Hours)
                    .IsRequired()
                    .HasColumnName("hours")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MonthNo).HasColumnName("monthno");

                entity.Property(e => e.Power)
                    .HasColumnName("power_")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.PriceFromDate)
                    .HasColumnName("pricefromdate")
                    .HasColumnType("date");

                entity.Property(e => e.PriceLevelId).HasColumnName("pricelevelid");

                entity.Property(e => e.PriceToDate)
                    .HasColumnName("pricetodate")
                    .HasColumnType("date");

                entity.Property(e => e.SeasonId).HasColumnName("seasonid");

                entity.Property(e => e.TariffTypeDd).HasColumnName("tarifftypeid");

                entity.Property(e => e.TaxEnergy)
                    .HasColumnName("taxenergy")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.TaxEnova)
                    .HasColumnName("taxenova")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.TaxMva)
                    .HasColumnName("taxmva")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.UomId).HasColumnName("uomid");

                entity.HasOne(d => d.PriceLevel)
                    .WithMany(p => p.VariablePriceConfig)
                    .HasForeignKey(d => d.PriceLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__variablep__price__56E8E7AB");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.VariablePriceConfig)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__variablep__seaso__57DD0BE4");

                entity.HasOne(d => d.TariffType)
                    .WithMany(p => p.VariablePriceConfig)
                    .HasForeignKey(d => d.TariffTypeDd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__variablep__tarif__58D1301D");

                entity.HasOne(d => d.Uom)
                    .WithMany(p => p.VariablePriceConfig)
                    .HasForeignKey(d => d.UomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__variablep__uomid__59C55456");
            });
        }
    }
}
