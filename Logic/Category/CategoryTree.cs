using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Logic
{
	public class CategoryTree
	{
		public Node MainNode { get; set; }

		public CategoryTree(List<Category> categories)
		{
			MainNode = new Node();
			CreateTree(categories);
		}

		private void CreateTree(List<Category> categories)
		{
			foreach (Category category in categories)
			{
				MainNode.AddCategory(category);
			}
		}
	}
}
