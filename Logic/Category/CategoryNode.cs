using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Logic
{
	public class Node
	{
		public Node SubNode { get; set; }
		public List<Category> Categories { get; set; }
		public Category Category { get; set; }

		public void AddToSubNode(Category category)
		{
			if (SubNode != null)
			{
				SubNode.AddCategory(category);
			}
			else
			{
				SubNode = new Node()
				{
					Category = category,
				};
			}
		}

		public void AddCategory(Category newCategory)
		{
			bool isAdded = false;
			foreach (Category category in Categories)
			{
				if (category.ParentId == newCategory.Id)
				{
					AddToSubNode(newCategory);
					isAdded = true;
				}
			}

			if (!isAdded)
			{
				Categories.Add(newCategory);
			}
		}
	}
}
