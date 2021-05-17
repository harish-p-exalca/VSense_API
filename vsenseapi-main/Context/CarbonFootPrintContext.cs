using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VSense.API.Context
{
    public partial class CarbonFootPrintContext : DbContext
    {
        public CarbonFootPrintContext()
        {
        }

        public CarbonFootPrintContext(DbContextOptions<CarbonFootPrintContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CurrentConsumption> CurrentConsumption { get; set; }
        public virtual DbSet<WaterConsumption> WaterConsumption { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.0.22;Database=CarbonFootPrint;User ID = vsign;Password=VSign@2020;Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrentConsumption>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Current)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnName("DeviceID")
                    .HasMaxLength(50);

                entity.Property(e => e.Watt)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WaterConsumption>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnName("DeviceID")
                    .HasMaxLength(50);

                entity.Property(e => e.Flow)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Qty)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
