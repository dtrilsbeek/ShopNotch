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
	}
}
