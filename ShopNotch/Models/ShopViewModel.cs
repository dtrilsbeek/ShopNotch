using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Logic.Helpers.TreeView;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopNotch.Models
{
	public class ShopViewModel
	{
		public IEnumerable<Category> Categories { get; set; }
		public List<SelectListItem> CategoryNames { get; set; }
		public TreeView Tree { get; set; }
		public IEnumerable<Product> Products { get; set; }
	}
}
