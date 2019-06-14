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

		public ShopController(ICategoryLogic categoryLogic, IProductLogic productLogic)
		{
			_categoryLogic = categoryLogic;
			_productLogic = productLogic;
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
			CartViewModel model;
			var cart = HttpContext.Session.GetString("CartItems");

			if (!string.IsNullOrEmpty(cart))
			{
				model = JsonConvert.DeserializeObject<CartViewModel>(cart);
			}
			else
			{
				model = new CartViewModel
				{
					Items = new Dictionary<int, int>()
				};
			}

			var products = new Dictionary<Product, int>();
			foreach (var cartItem in model.Items)
			{
				var product = _productLogic.GetById(cartItem.Key);
				if (product == null) return NotFound();

				products[product] = cartItem.Value;
			}

			model.Products = products;

			return View(model);
		}

		[HttpPost]
		public IActionResult AddToCart(int? productId, int? amount)
		{
			if (productId == null || amount == null) return NotFound();

			var product = _productLogic.GetById((int) productId);

			if (product == null) return NotFound();

			CartViewModel model;
			var cart = HttpContext.Session.GetString("CartItems");

			if (!string.IsNullOrEmpty(cart))
			{
				model = JsonConvert.DeserializeObject<CartViewModel>(cart);
			}
			else
			{
				model = new CartViewModel
				{
					Items = new Dictionary<int, int>()
				};
			}

			AddToDictionary(model.Items, (int) productId, (int) amount);

			HttpContext.Session.SetString("CartItems", JsonConvert.SerializeObject(model));

			return new OkResult();
		}

		private void AddToDictionary(Dictionary<int, int> dictionary, int productId, int amount)
		{
			if (dictionary.ContainsKey(productId))
			{
				dictionary[productId] += amount;
			}
			else
			{
				dictionary[productId] = amount;
			}
		}
	}
}