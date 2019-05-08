using Microsoft.AspNetCore.Mvc;

namespace ShopNotch.Controllers.Notch
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}