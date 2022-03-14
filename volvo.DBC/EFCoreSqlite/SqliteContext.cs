using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using volvo.DBI;
using volvo.Shared;
using volvo.DBC.EFCoreSqlite;

namespace volvo.DBC.EFCoreSqlite
{
    public class SqliteContext : DbContext
    {
        #region DbSet
        public DbSet<VehicleShared>? Vehicle { get; set; }
        public DbSet<ModelVehicleShared> ModelVehicle { get; set; }

        #endregion DbSet

        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=VolvoDb.db;", b => b.MigrationsAssembly("Volvo.Server"));
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleSharedConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ModelVehicleSharedConfiguration).Assembly);

            modelBuilder.Entity<ModelVehicleShared>().HasData(new ModelVehicleShared { IdModelVehicle = 1, NameModelVehicle = "FH" });
            modelBuilder.Entity<ModelVehicleShared>().HasData(new ModelVehicleShared { IdModelVehicle = 2, NameModelVehicle = "FM" });
            modelBuilder.Entity<VehicleShared>().HasData(new VehicleShared { IdModelVehicle = 1, IdVehicle = 1, YearManufacturing = 2022, YearModel = 2022 });
            modelBuilder.Entity<VehicleShared>().HasData(new VehicleShared { IdModelVehicle = 2, IdVehicle = 2, YearManufacturing = 2022, YearModel = 2023 });
        }
    }
}