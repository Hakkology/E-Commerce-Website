using BuyFS.Core.DAL;
using BuyFS.Entity.DTO;
using BuyFS.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantFS.DataAccessLayer.Abstract
{
    public interface IProductDAL:IRepository<Product>
    {
        //Implementation of GetProductbyCategoryId function
        IEnumerable<ProductDto> GetProductbyCategoryId(int categoryid);
        //To abstraction of final point for Product

        IEnumerable<ProductDto> GetBasketByProductId(int userid);
    }
}
