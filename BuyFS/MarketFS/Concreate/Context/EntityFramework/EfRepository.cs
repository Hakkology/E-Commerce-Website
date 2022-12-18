using BuyFS.Core.DAL;
using BuyFS.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MerchantFS.DataAccessLayer.Concreate.Context.EntityFramework
{
    //Needs a class, which inherits from IBaseEntity and can be newed.
    //dbContext is marketdb, which is the actual database
    public class EfRepository<TEntity, TDbContext>:IRepository<TEntity>
        where TEntity : class, IBaseEntity, new()
        where TDbContext:DbContext
    {
        //Actual methods as specified below in order to withdraw data from db.
        private readonly TDbContext db;

        public EfRepository(TDbContext db)
        {
            this.db = db;
        }

        //Modifying Functions (Post)
        public bool Add(TEntity entity)
        {
            db.Add(entity);
            return db.SaveChanges() > 0 ? true: false;
        }

        public bool Update(TEntity entity)
        {
            db.Update(entity);
            return db.SaveChanges() > 0 ? true : false;
        }

        //Every Delete procedure is an update procedure
        public bool Delete(TEntity entity)
        {
            db.Update(entity);
            return db.SaveChanges() > 0 ? true : false;
        }

        //Access Functions (Get)
        public IEnumerable<TEntity> Get()
        {
            return db.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetEntity(Expression<Func<TEntity, bool>> expression = null, string[] navProperty = null)
        {
            IQueryable<TEntity> entities = null;
            if (expression == null)
            {
                entities=db.Set<TEntity>();
            }
            else
            {
                entities = db.Set<TEntity>().Where(expression);
            }

            if (navProperty == null)
            {
                return entities;
            }
            else
            {
                foreach (var item in navProperty)
                {
                    entities = entities.Include(item);
                }
                return entities;
            }
        }
    }
}
