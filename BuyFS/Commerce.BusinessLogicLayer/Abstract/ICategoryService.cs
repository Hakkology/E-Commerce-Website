using BuyFS.Core.BAL;
using BuyFS.Core.Constant;
using BuyFS.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.BusinessLogicLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        EntityResult<IEnumerable<Category>> GetCategory();
    }
}
