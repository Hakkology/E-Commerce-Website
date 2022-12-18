using BuyFS.Core.DAL;
using BuyFS.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantFS.DataAccessLayer.Abstract
{
    public interface ICategoryDAL:IRepository<Category>
    {
        //To abstraction of final point for Category
        IEnumerable<Category> GetCategory();
    }
}
