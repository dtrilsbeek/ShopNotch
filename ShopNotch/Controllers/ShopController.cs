using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ShopNotch.Models;

namespace ShopNotch.Controllers
{
    public class ShopController : Controller
    {
	    private CategoryLogic _categoryLogic;
	    private ProductLogic _productLogic;

	    public ShopController(ILogic<Category> categoryLogic, ILogic<Product> productLogic)
	    {
		    _categoryLogic = categoryLogic as CategoryLogic;
			_productLogic = productLogic as ProductLogic;
	    }

        public IActionResult Index()
        {
	        var categories = _categoryLogic.GetAll();
	        var products = _productLogic.GetAll();

			var model = new ShopViewModel
			{
				Categories = categories,
				Products = products
			};

            return View(model);
        }

        public IActionResult Details(int? id)
        {
			if (id == null)
			{
				return NotFound();
			}

			var product = _productLogic.GetById((int)id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

        public IActionResult Categories(int? id)
        {
	        var products = id == null ? _productLogic.GetAll() : _productLogic.GetByCategoryId((int)id);

			if (products == null)
			{
				return NotFound();
			}

			var model = new ShopViewModel
			{
				Categories = _categoryLogic.GetAll(),
				Products = products
			};

			return View(model);
		}
    }
}