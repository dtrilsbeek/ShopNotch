using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

namespace Logic
{
	public class Node
	{
		public List<Node> SubNodes { get; set; }
		public List<Category> Categories { get; set; }
		public Category Category { get; set; }

		public Node()
		{
			SubNodes = new List<Node>();
			Categories = new List<Category>();
		}

		public void AddToSubNode(Category category)
		{
			foreach (Node subNode in SubNodes)
			{
				if (subNode != null)
				{
					subNode.AddCategory(category);
				}
				else
				{
					SubNodes.Add(new Node
					{
						Category = category,
					});
				}
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
