using BuyFS.Core.Constant;
using BuyFS.Entity.DTO;
using BuyFS.Entity.POCO;
using Commerce.BusinessLogicLayer.Abstract;
using MerchantFS.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.BusinessLogicLayer.Concreate
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDAL basketDAL;

        public BasketManager(IBasketDAL basketDal)
        {
            this.basketDAL = basketDal;
        }

        public EntityResult<IEnumerable<Basket>> AddToBasket(BasketDto basketDto)
        {
            try
            {
                var basket = basketDAL.AddToBasket(basketDto).ToList();

                if (basket!=null && basket.Count>0)
                {
                    return new EntityResult<IEnumerable<Basket>>(basket, "Successfully added.");
                }
                return new EntityResult<IEnumerable<Basket>>(null, "Not Found.", EntityResultType.NotFound);
            }
            catch (Exception ex)
            {
                return new EntityResult<IEnumerable<Basket>>(null, ex.ToInner().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<Basket>> Get(int _ClientId)
        {
            try
            {
                string[] array = new string[] { "Product", "AppUser" };
                var result = basketDAL.GetEntity(x => x.AppClientId == _ClientId, array);

                if (result != null && result.Count() >0)
                {
                    return new EntityResult<IEnumerable<Basket>>(result, "Successfully added.");
                }
                return new EntityResult<IEnumerable<Basket>>(null, "Not Found.", EntityResultType.NotFound);
            }
            catch (Exception ex)
            {
                return new EntityResult<IEnumerable<Basket>>(null, ex.ToInner().Message, EntityResultType.Error);
            }
        }

        public EntityResult<int> Update(int _Count, int _ProductId, int _ClientId)
        {
            var basket = basketDAL.GetEntity(x => x.AppClientId == _ClientId && x.ProductId == _ProductId).FirstOrDefault();
            basket.Count = _Count;
            basketDAL.Update(basket);

            return new EntityResult<int>(basket.Count, "Success");
        }
    }
}
