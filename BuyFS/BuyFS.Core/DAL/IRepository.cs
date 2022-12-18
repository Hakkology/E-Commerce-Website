using BuyFS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BuyFS.Core.DAL
{
    public interface IRepository<TEntity>
        where TEntity : class, IBaseEntity, new ()
    {
        //roof interface to gather all the methods required to process information from Entity layer
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        IEnumerable<TEntity> GetEntity(Expression<Func<TEntity, bool>> expression = null, string[] navProperty = null);
    }
}
