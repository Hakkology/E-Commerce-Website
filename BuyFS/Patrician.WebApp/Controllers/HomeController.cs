using Commerce.BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Patrician.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService Categoryservice;

        public HomeController(ICategoryService _categoryservice)
        {
            this.Categoryservice = _categoryservice;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
