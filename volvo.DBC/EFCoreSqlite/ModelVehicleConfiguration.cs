using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using volvo.DBI;
using volvo.Shared;

namespace volvo.DBC.EFCoreSqlite
{
    public class ModelVehicleSharedConfiguration : IVolvoEntityTypeConfiguration<ModelVehicleShared>
    {
        public void Configure(EntityTypeBuilder<ModelVehicleShared> modelVehicleBuilder)
        {
            modelVehicleBuilder.HasKey(modelVehicle => modelVehicle.IdModelVehicle);
            modelVehicleBuilder.HasIndex(modelVehicle => modelVehicle.IdModelVehicle);

            modelVehicleBuilder.HasMany(modelVehicle => modelVehicle.Vehicles)
                .WithOne(vehicles => vehicles.Model)
                .HasForeignKey(vehicles => vehicles.IdModelVehicle)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelVehicleBuilder.Property(modelVehicle => modelVehicle.IdModelVehicle).IsRequired().ValueGeneratedOnAdd();
            modelVehicleBuilder.Property(modelVehicle => modelVehicle.NameModelVehicle).IsRequired().HasMaxLength(2);
        }
    }
}
