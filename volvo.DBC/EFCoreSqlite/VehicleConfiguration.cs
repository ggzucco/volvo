using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using volvo.DBI;
using volvo.Shared;

namespace volvo.DBC.EFCoreSqlite
{
    public class VehicleSharedConfiguration : IVolvoEntityTypeConfiguration<VehicleShared>
    {
        public void Configure(EntityTypeBuilder<VehicleShared> VehicleBuilder)
        {
            VehicleBuilder.HasKey(vehicle => vehicle.IdVehicle);
            VehicleBuilder.HasIndex(vehicle => new { vehicle.IdVehicle, vehicle.IdModelVehicle });

            VehicleBuilder.Property(vehicle => vehicle.IdVehicle).IsRequired().ValueGeneratedOnAdd();
            VehicleBuilder.Property(vehicle => vehicle.YearManufacturing).IsRequired().HasMaxLength(4);
            VehicleBuilder.Property(vehicle => vehicle.YearModel).IsRequired().HasMaxLength(4);
        }
    }
}