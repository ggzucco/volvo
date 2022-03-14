namespace volvo.Shared
{
    public class VehicleShared
    {
        public Int64 IdVehicle { get; set; }
        public Int64 IdModelVehicle { get; set; }
        public Int32 YearManufacturing { get; set; }
        public Int32 YearModel { get; set; }
        public ModelVehicleShared? Model { get; set; }
    }
}