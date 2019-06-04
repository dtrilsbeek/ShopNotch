using System.Collections.Generic;
using Data.Models;
using Logic.Helpers.TreeView;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopNotch.Models.Classes;

namespace ShopNotch.Models
{
	public class CategoryViewModel
	{
		public CategoryModel Category { get; set; }
		public List<CategoryModel> Categories { get; set; }
		public List<SelectListItem> CategoryNames { get; set; }
		public TreeView Tree { get; set; }
		public int? SelectedParent { get; set; }
		public string Name { get; set; }
	}
}
