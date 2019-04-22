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
		public string Name { get; set; }
		public IEnumerable<Category> Categories { get; set; }
		public List<SelectListItem> CategoryNames { get; set; }

		public int[] ParentCategories { get; set; }

		public CreateViewModel()
		{
			
		}
	}
}
