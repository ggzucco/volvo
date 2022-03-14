using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace volvo.DBI
{
    public interface IRepositoryDBI<TEntity> where TEntity : class
    {
        TEntity? Get(Int64 id);      
        IEnumerable<TEntity>? GetAll();
        
        void Save(TEntity entity);
      
        void Remove(Int64 id);       
    }
}
