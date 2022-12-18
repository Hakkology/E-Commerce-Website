using BuyFS.Entity.DTO;
using BuyFS.Entity.POCO;
using Commerce.BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Patrician.WebApp.Controllers
{
    [Authorize(Roles = "UserApp")]

    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly IProductService productService;
        private readonly UserManager<AppClient> userManager;

        public BasketController(IBasketService basketService, IProductService productService, UserManager<AppClient> userManager)
        {
            this.basketService = basketService;
            this.productService = productService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(int count, int productId)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var result = basketService.AddToBasket(new BasketDto
            {
                Count = count,
                ProductId = productId,
                ClientId = user.Id
            });

            switch (result.ResultType)
            {
                case BuyFS.Core.Constant.EntityResultType.Success:
                    return Ok(result.Data);
                case BuyFS.Core.Constant.EntityResultType.Error:
                    break;
                case BuyFS.Core.Constant.EntityResultType.NotFound:
                    break;
                case BuyFS.Core.Constant.EntityResultType.NonValidation:
                    break;
                case BuyFS.Core.Constant.EntityResultType.Warning:
                    break;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> RefreshBasketCount()
        {
            var u = await userManager.FindByNameAsync(User.Identity.Name);
            var result = basketService.Get(u.Id);
            switch (result.ResultType)
            {
                case BuyFS.Core.Constant.EntityResultType.Success:
                    return Ok(result.Data.Sum(x => x.Count));
                case BuyFS.Core.Constant.EntityResultType.Error:
                    break;
                case BuyFS.Core.Constant.EntityResultType.NotFound:
                    break;
                case BuyFS.Core.Constant.EntityResultType.NonValidation:
                    break;
                case BuyFS.Core.Constant.EntityResultType.Warning:
                    break;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ActualBasket()
        {
            var u = userManager.FindByNameAsync(User.Identity.Name);
            var result = productService.GetBasketByProduct(u.Id);

            switch (result.ResultType)
            {
                case BuyFS.Core.Constant.EntityResultType.Success:
                    return View(result.Data);
                case BuyFS.Core.Constant.EntityResultType.Error:
                    break;
                case BuyFS.Core.Constant.EntityResultType.NotFound:
                    break;
                case BuyFS.Core.Constant.EntityResultType.NonValidation:
                    break;
                case BuyFS.Core.Constant.EntityResultType.Warning:
                    break;
            }
            return NotFound();
        }

        public async Task<IActionResult> CountChange(int id, int count)
        {
            var u = await userManager.FindByNameAsync(User.Identity.Name);
            var result = basketService.Update(count, id, u.Id);
            switch (result.ResultType)
            {
                case BuyFS.Core.Constant.EntityResultType.Success:
                    return Ok();
                case BuyFS.Core.Constant.EntityResultType.Error:
                    break;
                case BuyFS.Core.Constant.EntityResultType.NotFound:
                    break;
                case BuyFS.Core.Constant.EntityResultType.NonValidation:
                    break;
                case BuyFS.Core.Constant.EntityResultType.Warning:
                    break;
            }
            return View();
        }
    }
}