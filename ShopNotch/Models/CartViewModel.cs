using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Logic.Helpers.TreeView;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopNotch.Models
{
	public class CartViewModel
	{
		public Dictionary<int, int> Items { get; set; }
		public List<Product> Products { get; set; }
	}
}
