using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using volvo.BLL;
using volvo.Shared;
using System.Diagnostics;
using System.Management;

namespace UnitTest
{
    public class UnitTest1
    {
        private void runServer()
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("UnitTest.dll","volvo.Server.exe") ;
            string command = exePath;
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C " + command,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            Process.Start(startInfo);
        }

        [Fact]
        public void GetAll()
        {
            runServer();
            VehicleBLL vehicleBLL = new VehicleBLL();
            var vehicles = vehicleBLL.GetAll();
            Assert.True(vehicles.Any());
        }

        [Fact]
        public void GetOne()
        {
            runServer();
            VehicleBLL vehicleBLL = new VehicleBLL();
            var vehicle = vehicleBLL.Get(1);
            Assert.True(vehicle.IdVehicle == 1 && 
                        vehicle.IdModelVehicle > 0 &&
                        vehicle.YearManufacturing == long.Parse(DateTime.Now.Year.ToString()) &&
                        (vehicle.YearModel == long.Parse(DateTime.Now.Year.ToString()) 
                        || vehicle.YearModel == long.Parse(DateTime.Now.Year.ToString()))
                        );
        }

        [Fact]
        public void Insert()
        {
            runServer();
            VehicleBLL vehicleBLL = new VehicleBLL();
            var vehiclesOld = vehicleBLL.GetAll();
            var countOld = vehiclesOld.Count();

            VehicleShared vehicleShared = new VehicleShared(); 
            vehicleShared.IdModelVehicle = 1;
            vehicleShared.YearManufacturing = 2022;
            vehicleShared.YearModel = 2022;
               
            vehicleBLL.Save(vehicleShared);

            var vehiclesNew = vehicleBLL.GetAll();
            var countNew = vehiclesNew.Count();

            Assert.True(countNew > countOld);
        }

        [Fact]
        public void Delete()
        {
            runServer();
            VehicleBLL vehicleBLL = new VehicleBLL();
            var vehiclesOld = vehicleBLL.GetAll();
            var countOld = vehiclesOld.Count();
            var id = vehiclesOld.LastOrDefault().IdVehicle;

            vehicleBLL.Remove(id);

            var vehiclesNew = vehicleBLL.GetAll();
            var countNew = vehiclesNew.Count();

            Assert.True(countNew < countOld);
        }

        [Fact]
        public void Models()
        {
            runServer();
            ModelVehicleBLL model = new ModelVehicleBLL();
            var models = model.GetAll();
            var result = models.Any(w => w.NameModelVehicle != "FM" && w.NameModelVehicle != "FH");
            Assert.False(result);
        }
    }
}