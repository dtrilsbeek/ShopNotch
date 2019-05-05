using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Logic;
using Logic.Helpers.TreeView;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopNotch.Models
{
	public class CategoryViewModel
	{
		public Category Category { get; set; }
		public IEnumerable<Category> Categories { get; set; }
		public List<SelectListItem> CategoryNames { get; set; }
		public TreeView Tree { get; set; }
		public int? SelectedParent { get; set; }
		public string Name { get; set; }

		public CategoryViewModel()
		{
			
		}
	}
}
