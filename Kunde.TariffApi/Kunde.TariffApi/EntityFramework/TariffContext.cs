using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kunde.TariffApi.EntityFramework
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
        public virtual DbSet<Fixedpriceconfig> Fixedpriceconfig { get; set; }
        public virtual DbSet<Fixedpricelevel> Fixedpricelevel { get; set; }
        public virtual DbSet<Hours> Hours { get; set; }
        public virtual DbSet<Pricelevel> Pricelevel { get; set; }
        public virtual DbSet<Publicholiday> Publicholiday { get; set; }
        public virtual DbSet<Season> Season { get; set; }
        public virtual DbSet<Tarifftype> Tarifftype { get; set; }
        public virtual DbSet<Uom> Uom { get; set; }
        public virtual DbSet<Variablepriceconfig> Variablepriceconfig { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;Initial Catalog=Elvia_effektAPITest_0_06;integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Company1)
                    .IsRequired()
                    .HasColumnName("company")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fixedpriceconfig>(entity =>
            {
                entity.ToTable("fixedpriceconfig");

                entity.HasIndex(e => new { e.Tarifftypeid, e.Seasonid, e.Monthno, e.Pricelevelid, e.Pricefromdate, e.Pricetodate })
                    .HasName("uc_fixedpriceconfig")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fixed)
                    .HasColumnName("fixed")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Monthno).HasColumnName("monthno");

                entity.Property(e => e.Pricefromdate)
                    .HasColumnName("pricefromdate")
                    .HasColumnType("date");

                entity.Property(e => e.Pricelevelid).HasColumnName("pricelevelid");

                entity.Property(e => e.Pricetodate)
                    .HasColumnName("pricetodate")
                    .HasColumnType("date");

                entity.Property(e => e.Seasonid).HasColumnName("seasonid");

                entity.Property(e => e.Tarifftypeid).HasColumnName("tarifftypeid");

                entity.Property(e => e.Taxes)
                    .HasColumnName("taxes")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Uomid).HasColumnName("uomid");

                entity.HasOne(d => d.Pricelevel)
                    .WithMany(p => p.Fixedpriceconfig)
                    .HasForeignKey(d => d.Pricelevelid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fixedpric__price__68487DD7");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Fixedpriceconfig)
                    .HasForeignKey(d => d.Seasonid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fixedpric__seaso__6754599E");

                entity.HasOne(d => d.Tarifftype)
                    .WithMany(p => p.Fixedpriceconfig)
                    .HasForeignKey(d => d.Tarifftypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fixedpric__tarif__66603565");

                entity.HasOne(d => d.Uom)
                    .WithMany(p => p.Fixedpriceconfig)
                    .HasForeignKey(d => d.Uomid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__fixedpric__uomid__693CA210");
            });

            modelBuilder.Entity<Fixedpricelevel>(entity =>
            {
                entity.ToTable("fixedpricelevel");

                entity.HasIndex(e => e.Pricelevel)
                    .HasName("UQ__fixedpri__EDDD99B6AEC43134")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Levelinfo)
                    .IsRequired()
                    .HasColumnName("levelinfo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pricelevel)
                    .IsRequired()
                    .HasColumnName("pricelevel")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hours>(entity =>
            {
                entity.ToTable("hours");

                entity.HasIndex(e => e.Hour)
                    .HasName("UQ__hours__7F30AF4E38C64628")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Expiredattext)
                    .IsRequired()
                    .HasColumnName("expiredattext")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hour).HasColumnName("hour");

                entity.Property(e => e.Hourshortname)
                    .IsRequired()
                    .HasColumnName("hourshortname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Starttimetext)
                    .IsRequired()
                    .HasColumnName("starttimetext")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pricelevel>(entity =>
            {
                entity.ToTable("pricelevel");

                entity.HasIndex(e => e.Pricelevel1)
                    .HasName("UQ__pricelev__EDDD99B6F0E3D123")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Pricelevel1)
                    .IsRequired()
                    .HasColumnName("pricelevel")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Publicholiday>(entity =>
            {
                entity.ToTable("publicholiday");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Holidaydate)
                    .HasColumnName("holidaydate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Season>(entity =>
            {
                entity.ToTable("season");

                entity.HasIndex(e => e.Season1)
                    .HasName("UQ__season__BC91B1706B5B0E8A")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Season1)
                    .IsRequired()
                    .HasColumnName("season")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tarifftype>(entity =>
            {
                entity.ToTable("tarifftype");

                entity.HasIndex(e => new { e.Customertype, e.Title })
                    .HasName("uc_tarifftype")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Customertype)
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

                entity.Property(e => e.Tariffkey)
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
                    .WithMany(p => p.Tarifftype)
                    .HasForeignKey(d => d.Companyid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tarifftyp__compa__5070F446");
            });

            modelBuilder.Entity<Uom>(entity =>
            {
                entity.ToTable("uom");

                entity.HasIndex(e => new { e.Currency, e.Uom1 })
                    .HasName("uc_uom")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasColumnName("currency")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Uom1)
                    .IsRequired()
                    .HasColumnName("uom")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Variablepriceconfig>(entity =>
            {
                entity.ToTable("variablepriceconfig");

                entity.HasIndex(e => new { e.Tarifftypeid, e.Seasonid, e.Monthno, e.Pricelevelid, e.Pricefromdate, e.Pricetodate, e.Hours })
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

                entity.Property(e => e.Monthno).HasColumnName("monthno");

                entity.Property(e => e.Power)
                    .HasColumnName("power_")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Pricefromdate)
                    .HasColumnName("pricefromdate")
                    .HasColumnType("date");

                entity.Property(e => e.Pricelevelid).HasColumnName("pricelevelid");

                entity.Property(e => e.Pricetodate)
                    .HasColumnName("pricetodate")
                    .HasColumnType("date");

                entity.Property(e => e.Seasonid).HasColumnName("seasonid");

                entity.Property(e => e.Tarifftypeid).HasColumnName("tarifftypeid");

                entity.Property(e => e.Taxenergy)
                    .HasColumnName("taxenergy")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Taxenova)
                    .HasColumnName("taxenova")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Taxmva)
                    .HasColumnName("taxmva")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Uomid).HasColumnName("uomid");

                entity.HasOne(d => d.Pricelevel)
                    .WithMany(p => p.Variablepriceconfig)
                    .HasForeignKey(d => d.Pricelevelid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__variablep__price__6EF57B66");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Variablepriceconfig)
                    .HasForeignKey(d => d.Seasonid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__variablep__seaso__6E01572D");

                entity.HasOne(d => d.Tarifftype)
                    .WithMany(p => p.Variablepriceconfig)
                    .HasForeignKey(d => d.Tarifftypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__variablep__tarif__6D0D32F4");

                entity.HasOne(d => d.Uom)
                    .WithMany(p => p.Variablepriceconfig)
                    .HasForeignKey(d => d.Uomid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__variablep__uomid__6FE99F9F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
