using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;

namespace ShopNotch.Models
{
	public class CartItem
	{
		public int ProductId { get; set; }
		public int Amount { get; set; }
	}
}
