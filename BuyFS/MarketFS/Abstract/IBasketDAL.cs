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
    public interface IBasketDAL:IRepository<Basket>
    {
        IEnumerable<Basket> AddToBasket(BasketDto basketDto);
    }
}
