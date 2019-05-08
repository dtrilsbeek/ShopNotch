using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShopNotch.Controllers.Notch
{
    public class HomeController : NotchController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}