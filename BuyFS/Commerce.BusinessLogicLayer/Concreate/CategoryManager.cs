using BuyFS.Core.Constant;
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
    //Error messages are provided from ICategoryService, which inherits from IGenericService
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL CategoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            this.CategoryDAL = categoryDAL;
        }

        public EntityResult Add(Category entity)
        {
            try
            {
                if (CategoryDAL.Add(entity))
                {
                    return new EntityResult(EntityResultMessage.Add());
                }
                return new EntityResult(EntityResultMessage.Warning());
            }
            catch (Exception ex)
            {
                return new EntityResult(EntityResultMessage.Error(ex), EntityResultType.Error);
            }
        }

        public EntityResult Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public EntityResult<IEnumerable<Category>> Get()
        {
            throw new NotImplementedException();
        }

        public EntityResult<Category> Get(int id)
        {
            throw new NotImplementedException();
        }

        public EntityResult<IEnumerable<Category>> GetCategory()
        {
            try
            {
                var result = CategoryDAL.GetCategory();
                if (result!=null && result.Count()>0)
                {
                    return new EntityResult<IEnumerable<Category>>(result, "Success");
                }
                return new EntityResult<IEnumerable<Category>>(null, "Not Found", EntityResultType.NotFound);
            }
            catch (Exception ex)
            {
                return new EntityResult<IEnumerable<Category>>(null, "Error: " + ex.ToInner().Message, EntityResultType.Error);
            }
        }

        public EntityResult Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
