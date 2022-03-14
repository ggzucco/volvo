using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using volvo.DAL;
using volvo.DBI;
using volvo.Shared;

namespace volvo.BLL
{
    public class VehicleBLL : IVehicleDBI
    {
        public void Save(VehicleShared Vehicle)
        {
            VehicleDAL VehicleDAL = new VehicleDAL();
            VehicleDAL.Save(Vehicle);
        }
        public VehicleShared Get(long id)
        {
            VehicleShared vehicle = new VehicleShared();

            if (id > 0)
            {
                VehicleDAL VehicleDAL = new VehicleDAL();
                var result = VehicleDAL.Get(id);

                if (result != null || id > 0)
                    vehicle = result;
            }

            return vehicle;
        }

        public IEnumerable<VehicleShared> GetAll()
        {
            VehicleDAL VehicleDAL = new VehicleDAL();
            var vehicle = VehicleDAL.GetAll();

            foreach (var item in vehicle)
            {
                ModelVehicleBLL modelbll = new ModelVehicleBLL();
                var model = modelbll.Get(item.IdModelVehicle);

                item.Model = model != null ? model : new ModelVehicleShared();
            }

            return vehicle;
        }

        public void Remove(Int64 id)
        {
            VehicleDAL VehicleDAL = new VehicleDAL();
            VehicleDAL.Remove(id);
        }
    }
}