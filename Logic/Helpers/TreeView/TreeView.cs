using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;

namespace Logic.Helpers.TreeView
{
	public class TreeView
	{
		public List<Node> Nodes { get; set; }

		private Dictionary<int, Node> ParentDictionary;

		public TreeView(List<IParentEntity> entities)
		{
			Nodes = new List<Node>();
			CreateTree(entities);
			ParentDictionary = Nodes.ToDictionary(x => x.Entity.Id, x => x);
			SortTree();
		}

		private void CreateTree(List<IParentEntity> entities)
		{
			foreach (IParentEntity entity in entities)
			{
				Nodes.Add(new Node(entity));					
			}
		}

		private void SortTree()
		{
			foreach (Node node in Nodes)
			{
				if (node.Entity.ParentId != null)
				{
					if (ParentDictionary.ContainsKey((int)node.Entity.ParentId))
					{
						ParentDictionary[(int)node.Entity.ParentId].AddToNode(node);
					}
				}
			}
		}
	}
}
