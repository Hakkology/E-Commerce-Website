using BuyFS.Core.Constant;
using BuyFS.Entity.DTO;
using BuyFS.Entity.POCO;
using Commerce.BusinessLogicLayer.Abstract;
using MerchantFS.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.BusinessLogicLayer.Concreate
{
    public class ProductManager : IProductService
    {
        private readonly IProductDAL productDAL;

        public ProductManager(IProductDAL _productDAL)
        {
            this.productDAL = _productDAL;
        }

        public EntityResult Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public EntityResult Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public EntityResult<IEnumerable<Product>> Get()
        {
            throw new NotImplementedException();
        }

        public EntityResult<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        public EntityResult<IEnumerable<ProductDto>> GetBasketByProduct(int userid)
        {
            try
            {
                var result = productDAL.GetBasketByProductId(userid);
                if (result != null && result.Count() >0)
                {
                    return new EntityResult<IEnumerable<ProductDto>>(result, "Successfully added");
                }
                return new EntityResult<IEnumerable<ProductDto>>(null, "Not Found", EntityResultType.NotFound);
            }
            catch (Exception ex)
            {
                return new EntityResult<IEnumerable<ProductDto>>(null, ex.ToInner().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<Product>> GetEntity(Expression<Func<Product, bool>> expression = null, string[] navProperty = null)
        {
            try
            {
                var result = productDAL.GetEntity(expression, navProperty);
                if (result != null && result.Count() > 0)
                {
                    return new EntityResult<IEnumerable<Product>>(result, "Success");
                }
                return new EntityResult<IEnumerable<Product>>(null, "Not Found", EntityResultType.NotFound);
            }
            catch (Exception ex)
            {
                return new EntityResult<IEnumerable<Product>>(null, ex.ToInner().Message, EntityResultType.Error);
            }
        }

        public EntityResult<IEnumerable<ProductDto>> GetProductbyCategoryId(int categoryid)
        {
            try
            {
                var result = productDAL.GetProductbyCategoryId(categoryid);
                if (result != null && result.Count() > 0)
                {
                    return new EntityResult<IEnumerable<ProductDto>>(result, "Success");
                }
                return new EntityResult<IEnumerable<ProductDto>>(null, "Not Found", EntityResultType.NotFound);
            }
            catch (Exception ex)
            {
                return new EntityResult<IEnumerable<ProductDto>>(null, ex.ToInner().Message, EntityResultType.Error);
            }
        }

        public EntityResult Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
