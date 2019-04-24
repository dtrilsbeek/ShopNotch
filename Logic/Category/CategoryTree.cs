using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Logic
{
	class CategoryTree
	{
		public List<Node> MainNodes { get; set; }

		public CategoryTree(List<Category> categories)
		{
			MainNodes = new List<Node>();
			CreateMainNodes(categories);
		}

		private void CreateMainNodes(List<Category> categories)
		{
			foreach (Category category in categories)
			{
				
			}
		}
	}
}
