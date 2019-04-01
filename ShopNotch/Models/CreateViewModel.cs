using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopNotch.Models
{
	public class CreateViewModel
	{
		public IEnumerable<Category> Categories { get; private set; }
		public IEnumerable<Product> Products { get; private set; }

		public string Name { get; set; }
		public int? ParentId { get; set; }
		public string ParentName { get; set; }
		public List<SelectListItem> CategoryNames { get; set; }

		public CreateViewModel(List<Category> categories, List<Product> products)
		{
			Categories = categories;
			Products = products;
		}
	}
}
