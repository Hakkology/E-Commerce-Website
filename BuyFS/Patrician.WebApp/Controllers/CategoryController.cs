using Commerce.BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Patrician.WebApp.Models;

namespace Patrician.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        //using both in order to pull products by category id
        public CategoryController(IProductService _productservice, ICategoryService _categoryservice)
        {
            this.productService = _productservice;
            this.categoryService = _categoryservice;
        }
        public IActionResult Index(int id)
        {
            //In order to tell the webapp that the category Id is the category id defined for categories
            CategoryDetailsViewModel categorymodel = new CategoryDetailsViewModel();
            categorymodel.Category = categoryService.GetCategory().Data.ToList();

            //previously made GetProductbyCategoryId function used here, allowing us to list products by category id.
            var result = productService.GetProductbyCategoryId(id);
            switch (result.ResultType)
            {
                case BuyFS.Core.Constant.EntityResultType.Success:
                    categorymodel.ProductDto = result.Data.ToList();
                    return View(categorymodel);
                case BuyFS.Core.Constant.EntityResultType.Error:
                    break;
                case BuyFS.Core.Constant.EntityResultType.NotFound:
                    break;
                case BuyFS.Core.Constant.EntityResultType.NonValidation:
                    break;
                case BuyFS.Core.Constant.EntityResultType.Warning:
                    break;
                default:
                    break;
            }
            return View();

        }
    }
}
