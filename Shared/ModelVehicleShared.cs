using System;

namespace volvo.Shared
{
    public class ModelVehicleShared
    {
        public Int64 IdModelVehicle { get; set; }
        public String? NameModelVehicle { get; set; }
        public virtual ICollection<VehicleShared>? Vehicles { get; set; }
    }
}