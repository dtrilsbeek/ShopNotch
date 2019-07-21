﻿using System.Collections.Generic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Logic.Helpers
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

		public Dictionary<int, int> Add(int productId, int amount)
		{
			if (_items.ContainsKey(productId))
			{
				_items[productId] += amount;
			}
			else
			{
				_items[productId] = amount;
			}

			return _items;
		}

		public void Delete(int productId, int amount)
		{

		}

	}
}