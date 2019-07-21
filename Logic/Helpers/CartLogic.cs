using System.Collections.Generic;
using Data.Models;
using Logic.Interfaces;

namespace Logic
{
	public class CartLogic : ICartLogic
	{
		private Dictionary<int, int> _items;
		private IProductLogic _productLogic;

		public CartLogic(IProductLogic productLogic)
		{
			_productLogic = productLogic;
			_items = new Dictionary<int, int>();
		}

		public Dictionary<int, int> GetAll()
		{
			return _items;
		}

		public Dictionary<int, CartItem> GetAllProducts()
		{
			var products = new Dictionary<int, CartItem>();

			foreach (var (productId, amount) in _items)
			{
				var product = _productLogic.GetById(productId);
				
				if (product != null)
				{
					var cartItem = new CartItem
					{
						Amount = amount,
						Product = product
					};

					if (products[productId] != null)
					{
						products[productId].Amount += amount;
					}
					else
					{
						products[productId] = cartItem;
					}
					
				}
			}

			return products;
		}

		public void Add(int productId, int amount)
		{
			if (_items.ContainsKey(productId))
			{
				_items[productId] += amount;
			}
			else
			{
				_items[productId] = amount;
			}
		}

		public void Delete(int productId, int amount)
		{

		}
		
		
		public void AddToCart(int? productId, int? amount)
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
	}
}