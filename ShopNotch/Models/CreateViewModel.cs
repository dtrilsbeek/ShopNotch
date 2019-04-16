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
		public IEnumerable<Category> ParentCategories { get; set; }
		public List<SelectListItem> CategoryNames { get; set; }

		public CreateViewModel(IEnumerable<Category> categories)
		{
			Categories = categories;
		}
	}
}
