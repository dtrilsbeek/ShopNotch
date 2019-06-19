using System.Collections.Generic;
using Data.Models;
using Logic.Interfaces;

namespace Logic
{
	public class CartLogic : ICartLogic
	{
		private Dictionary<int, int> items;
		private IProductLogic _productLogic;

		public CartLogic(IProductLogic productLogic)
		{
			_productLogic = productLogic;
			items = new Dictionary<int, int>();
		}

		public Dictionary<int, int> GetAll()
		{
			return items;
		}

		public Dictionary<Product, int> GetAllProduct()
		{
			var products = new Dictionary<Product, int>();

			foreach (var cartItem in items)
			{
				var product = _productLogic.GetById(cartItem.Key);

				if (product != null)
				{
					products[product] = cartItem.Value;
				}
			}

			return products;
		}

		public void Add(int productId, int amount)
		{
			
		}

		public void Delete(int productId, int amount)
		{

		}
	}
}