using Commerce.BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Patrician.WebApp.Models;
using System.Linq;

namespace Patrician.WebApp.Component
{
    //header view component calls to header component in view folder and sources that view.
    public class HeaderViewComponent:ViewComponent
    {
        private readonly ICategoryService categoryService;

        public HeaderViewComponent(ICategoryService _categoryservice)
        {
            categoryService = _categoryservice;
        }

        public IViewComponentResult Invoke()
        {
            HeaderViewModel headermodel = new HeaderViewModel();
            var categories = categoryService.GetCategory();

            switch (categories.ResultType)
            {
                case BuyFS.Core.Constant.EntityResultType.Success:
                    headermodel.Categorylist = categories.Data.ToList();
                    break;
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
            return View(headermodel);
        }
    }
}
