using BuyFS.Entity.POCO;
using MerchantFS.DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantFS.DataAccessLayer.Concreate.Context.EntityFramework
{
    //Actual layer for Category Pulling - Get Category by Product is added
    public class EfCategory:EfRepository<Category, MarketDbContext>, ICategoryDAL
    {
        private readonly MarketDbContext db;

        public EfCategory(MarketDbContext db): base(db)
        {
            this.db = db;
        }

        public IEnumerable<Category> GetCategory()
        {
            return db.Category.Include(x => x.ProductCategory).ThenInclude(x => x.Product)
                .Where(x => x.Active && !x.Deleted);
        }
    }
}
