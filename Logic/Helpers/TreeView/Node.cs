using System.Collections.Generic;
using Data.Interfaces;

namespace Logic.Helpers.TreeView
{
	public class Node
	{
		public List<Node> SubNodes { get; set; }
		public IParentEntity Entity { get; set; }

		public Node(IParentEntity entity)
		{
			Entity = entity;
			SubNodes = new List<Node>();
		}

		public void AddToNode(Node node)
		{
			SubNodes.Add(node);
		}

//		public void AddEntity(IParentEntity newEntity)
//		{
//			bool isAdded = false;
//			foreach (Node subNode in SubNodes)
//			{
//				if (newEntity.ParentId != null)
//				{
//					if (newEntity.ParentId == subNode.Entity.Id)
//					{
//						subNode.AddEntity(newEntity);
//						isAdded = true;
//					}
//				}
//			}
//
//			if (!isAdded)
//			{
//				AddToNode(newEntity);
//			}
//		}
	}
}
