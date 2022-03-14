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
    public class ModelVehicleBLL : IModelVehicleDBI
    {
        public void Save(ModelVehicleShared ModelVehicle)
        {
            throw new NotImplementedException();
        }
    
        public ModelVehicleShared? Get(long id)
        {
            ModelVehicleShared model = new ModelVehicleShared();

            if (id > 0)
            {
                ModelVehicleDAL ModelDAL = new ModelVehicleDAL();
                var result = ModelDAL.Get(id);

                if (result != null || id > 0)
                    model = result;
            }

            return model;
        }

        public IEnumerable<ModelVehicleShared>? GetAll()
        {
            ModelVehicleDAL ModelVehicleDAL = new ModelVehicleDAL();
            var modelvehicle = ModelVehicleDAL.GetAll();

            return modelvehicle;
        }

        public void Remove(Int64 id)
        {
            throw new NotImplementedException();
        }
    }

}
