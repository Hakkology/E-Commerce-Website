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
    //Actual layer for Entity FrameWork Product Pulling
    public class EfProduct : EfRepository<Product, MarketDbContext>, IProductDAL
    {
        private readonly MarketDbContext db;

        public EfProduct(MarketDbContext db) : base(db)
        {
            this.db = db;
        }

        public IEnumerable<ProductDto> GetBasketByProductId(int userid)
        {
            var result = from product in db.Product
                         join basket in db.Basket on product.Id equals basket.ProductId
                         join user in db.Users on basket.AppClientId equals user.Id
                         select new ProductDto
                         {
                             Id = product.Id,
                             Name = product.Name,
                             Price = product.Price,
                             Stock = product.Stock,
                             ImageURL = product.ProductImage.FirstOrDefault(x => x.ProductId == product.Id).ImageURL,
                             BasketCount = basket.Count
                         };
            return result;
        }

        //Joining procedure for ProductDto in order to get products by categoryId
        public IEnumerable<ProductDto> GetProductbyCategoryId(int categoryid)
        {
            var result = from product in db.Product
                         join productcategory in db.ProductCategory
                         on product.Id equals productcategory.ProductId
                         join category in db.Category
                         on productcategory.CategoryId equals category.Id
                         where productcategory.CategoryId == categoryid
                         select new ProductDto
                         {
                             CategoryName = category.Name,
                             Id = product.Id,
                             Name = product.Name,
                             Price = product.Price,
                             Stock = product.Stock,
                             ImageURL = db.ProductImage.FirstOrDefault(x => x.ProductId == product.Id).ImageURL, //Might have problems later on
                             CategoryId = category.Id
                         };
            return result;
        }
    }
}
