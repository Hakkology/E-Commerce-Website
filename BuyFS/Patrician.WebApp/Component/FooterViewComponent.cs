using Microsoft.AspNetCore.Mvc;

namespace Patrician.WebApp.Component
{
    //footer view component calls to footer component in view folder and invokes that view.
    public class FooterViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
