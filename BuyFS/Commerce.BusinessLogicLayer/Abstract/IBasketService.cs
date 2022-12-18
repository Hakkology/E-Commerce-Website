using BuyFS.Core.Constant;
using BuyFS.Entity.DTO;
using BuyFS.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.BusinessLogicLayer.Abstract
{
    public interface IBasketService
    {
        EntityResult<IEnumerable<Basket>> AddToBasket(BasketDto basketDto);
        EntityResult<IEnumerable<Basket>> Get(int ClientId);
        EntityResult<int> Update(int Count, int ProductId, int ClientId);
    }
}
