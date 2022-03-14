using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using volvo.Shared;

namespace volvo.DBI
{
    public interface IModelVehicleDBI : IRepositoryDBI<ModelVehicleShared>
    {
        new ModelVehicleShared? Get(Int64 id);
        new IEnumerable<ModelVehicleShared>? GetAll();
        

        new void Save(ModelVehicleShared ModelVehicle);     

        new void Remove(Int64 id);      
    }
}
