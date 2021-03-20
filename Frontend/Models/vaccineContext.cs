using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace prueba.Models
{
    public partial class vaccineContext : DbContext
    {
        public vaccineContext()
        {
        }

        public vaccineContext(DbContextOptions<vaccineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citizens> Citizens { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Records> Records { get; set; }
        public virtual DbSet<Vaccines> Vaccines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;uid=root;database=vaccine", x => x.ServerVersion("10.4.17-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citizens>(entity =>
            {
                entity.ToTable("citizens");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(55)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasColumnName("id_number")
                    .HasColumnType("varchar(11)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(55)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Provinces>(entity =>
            {
                entity.ToTable("provinces");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Records>(entity =>
            {
                entity.ToTable("records");

                entity.HasIndex(e => e.Citizen)
                    .HasName("Records_citizen_Citizens_id");

                entity.HasIndex(e => e.Province)
                    .HasName("Records_province_provinces_id");

                entity.HasIndex(e => e.Vaccine)
                    .HasName("Records_vaccine_Vaccines_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Citizen)
                    .HasColumnName("citizen")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstVacDate)
                    .HasColumnName("first_vac_date")
                    .HasColumnType("timestamp");

                entity.Property(e => e.LastVacDate)
                    .HasColumnName("last_vac_date")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Province)
                    .HasColumnName("province")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Vaccine)
                    .HasColumnName("vaccine")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CitizenNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.Citizen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Records_citizen_Citizens_id");

                entity.HasOne(d => d.ProvinceNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.Province)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Records_province_provinces_id");

                entity.HasOne(d => d.VaccineNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.Vaccine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Records_vaccine_Vaccines_id");
            });

            modelBuilder.Entity<Vaccines>(entity =>
            {
                entity.ToTable("vaccines");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amounted)
                    .HasColumnName("amounted")
                    .HasColumnType("int(100)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
