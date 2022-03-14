using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using volvo.Shared;

namespace volvo.DBI
{
    public interface IVehicleDBI : IRepositoryDBI<VehicleShared>
    {
        new VehicleShared? Get(Int64 id);
        new IEnumerable<VehicleShared>? GetAll();      
        new void Save(VehicleShared Vehicle);     
        new void Remove(Int64 id);       
    }
}
