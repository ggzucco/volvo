using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using volvo.DBC.EFCoreSqlite;
using volvo.DBI;
using volvo.Shared;

namespace volvo.DAL
{
    public class ModelVehicleDAL : IModelVehicleDBI
    {
        private static SqliteContext context;
        public ModelVehicleDAL()
        {
            context = new SqliteContext(new DbContextOptions<SqliteContext>());
        }

        public void Save(ModelVehicleShared ModelVehicle)
        {
            throw new NotImplementedException();
        }

        public ModelVehicleShared? Get(long id)
        {
            return context.ModelVehicle.Where(mv => mv.IdModelVehicle == id)
                                            .Select(mv => new ModelVehicleShared
                                            {
                                                IdModelVehicle = mv.IdModelVehicle,
                                                NameModelVehicle = mv.NameModelVehicle
                                            }).FirstOrDefault();

        }

        public IEnumerable<ModelVehicleShared>? GetAll()
        {
            return context.ModelVehicle.ToList();
        }

        public void Remove(Int64 id)
        {
            throw new NotImplementedException();
        }
    }
}