using BuyFS.Entity.DTO;
using BuyFS.Entity.POCO;
using MerchantFS.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantFS.DataAccessLayer.Concreate.Context.EntityFramework
{
    public class EfBasket : EfRepository<Basket, MarketDbContext>, IBasketDAL
    {
        private readonly MarketDbContext db;

        public EfBasket(MarketDbContext db):base(db)
        {
            this.db = db;
        }

        public IEnumerable<Basket> AddToBasket(BasketDto basketDto)
        {
            var basket = db.Basket.FirstOrDefault(x=>x.AppClientId == basketDto.ClientId && x.ProductId == basketDto.ProductId);
            if (basket == null)
            {
                db.Basket.Add(new Basket
                {
                    AppClientId = basketDto.ClientId,
                    ProductId = basketDto.ProductId,
                    Count = basketDto.Count
                }); 
                db.SaveChanges();
            }
            else
            {
                basket.Count = basket.Count + basketDto.Count;
                db.SaveChanges();
            }
            return db.Basket.Where(x => x.AppClientId == basketDto.ClientId);
        }
    }
}
