using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using volvo.DBC.EFCoreSqlite;
using volvo.DBI;
using volvo.Shared;

namespace volvo.DAL
{
    public class VehicleDAL : IVehicleDBI
    {
        private static SqliteContext context;

        public VehicleDAL()
        {
            context = new SqliteContext(new DbContextOptions<SqliteContext>());
        }

        public void Save(VehicleShared Vehicle)
        {
            if (Vehicle.IdVehicle > 0)
                context.Update(Vehicle);
            else
                context.Add(Vehicle);

            context.SaveChanges();
        }      
        
        public VehicleShared? Get(long id)
        {         
            return context.Vehicle.FirstOrDefault(v => v.IdVehicle == id);
        }

        public IEnumerable<VehicleShared>? GetAll()
        {            
            return context.Vehicle.ToList();
        }

        public void Remove(Int64 id)
        { 
            if(id > 0)
            {
                var vehicle = context.Vehicle.FirstOrDefault(v => v.IdVehicle == id);
                context.Remove(vehicle);
                context.SaveChanges();
            }
        }
    }
}