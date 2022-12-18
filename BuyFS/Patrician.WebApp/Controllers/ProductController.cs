using Commerce.BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Patrician.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            string[] Images = new string[] { "ProductImage" };
            var result = productService.GetEntity(x => x.Id == id, Images);
            switch (result.ResultType)
            {
                case BuyFS.Core.Constant.EntityResultType.Success:
                    var entity = result.Data.ToList()[0];
                    return View(entity);
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
