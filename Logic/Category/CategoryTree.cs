using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Logic
{
	public class CategoryTree
	{
		public List<Node> MainNode { get; set; }

		public CategoryTree(List<Category> categories)
		{
			MainNode = new List<Node>();
			CreateTree(categories);
		}

		private void CreateTree(List<Category> categories)
		{
			foreach (Category category in categories)
			{
				bool isAdded = false;
				foreach (Node node in MainNode)
				{
					node.AddCategory(category);
				}
				
			}
		}
	}
}
