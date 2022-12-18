using BuyFS.Entity.POCO;
using FluentValidation;
using MerchantFS.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.BusinessLogicLayer.Validation
{
    public class CategoryValidation: AbstractValidator<Category>
    {
        //Specific validation techniques using fluent library
        private readonly ICategoryDAL categoryDAL;

        public CategoryValidation(ICategoryDAL _categoryDAL)
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name field cannot be Null");
            RuleFor(x => x.Name).Must(CategoryNameValidation).WithMessage("Field Name already exists");
            categoryDAL = _categoryDAL;
        }

        public bool CategoryNameValidation(string categoryname)
        {
            Category entity = categoryDAL.Get().AsQueryable().FirstOrDefault(x => x.Name == categoryname);
            if (entity == null)
            {
                return true;
            }
            return false;
        }
    }
}
