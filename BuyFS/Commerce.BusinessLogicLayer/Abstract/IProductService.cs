using BuyFS.Core.BAL;
using BuyFS.Core.Constant;
using BuyFS.Entity.DTO;
using BuyFS.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.BusinessLogicLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        EntityResult<IEnumerable<ProductDto>> GetProductbyCategoryId(int categoryid);
        EntityResult<IEnumerable<Product>> GetEntity(Expression<Func<Product, bool>>? expression = null, string[]? navProperty = null);
        EntityResult<IEnumerable<ProductDto>> GetBasketByProduct(int userid);
    }
}
