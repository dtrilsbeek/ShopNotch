using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopNotch.Models;

namespace ShopNotch.Controllers
{
	public class ShopController : Controller
	{
		private ICategoryLogic _categoryLogic;
		private IProductLogic _productLogic;
		private ICartLogic _cartLogic;
		public ShopController(ICategoryLogic categoryLogic, IProductLogic productLogic, ICartLogic cartLogic)
		{
			_categoryLogic = categoryLogic;
			_productLogic = productLogic;
			_cartLogic = cartLogic;
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

			var product = _productLogic.GetById((int) id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		public IActionResult Categories(int? id)
		{
			var products = id == null ? _productLogic.GetAll() : _productLogic.GetByCategoryId((int) id);

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

		public IActionResult Cart()
		{
			var model = new CartViewModel();

			model.Products = _cartLogic.GetAllProducts();

			return View(model);
		}

		[HttpPost]
		public IActionResult AddToCart(int? productId, int? amount)
		{
			if (productId == null || amount == null) return NotFound();

			var product = _productLogic.GetById((int) productId);

			if (product == null) return NotFound();

			_cartLogic.Add((int) productId, (int) amount);

			return new OkResult();
		}
		
		
		private void AddToSession(Dictionary<int, int> items)
		{
			HttpContext.Session.SetString("CartItems", JsonConvert.SerializeObject(items));
		}

		private Dictionary<int, int> GetFromSession()
		{
			var items = HttpContext.Session.GetString("CartItems");

			if (!string.IsNullOrEmpty(items))
			{
				return JsonConvert.DeserializeObject<Dictionary<int, int>>(items);
			}

			return default(Dictionary<int, int>);
		}
		
	}
}