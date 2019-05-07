using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;

namespace Logic.Helpers.TreeView
{
	public class TreeView
	{
		public List<Node> Nodes { get; set; }

		private Dictionary<int, Node> _parentDictionary;

		public TreeView(List<IParentEntity> entities)
		{
			Nodes = new List<Node>();
			CreateTree(entities);
			_parentDictionary = Nodes.ToDictionary(x => x.Entity.Id, x => x);
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
			for (int i = Nodes.Count-1; i >= 0; i--)
			{
				Node node = Nodes[i];
				if (node.Entity.ParentId != null)
				{
					if (_parentDictionary.ContainsKey((int)node.Entity.ParentId))
					{
						_parentDictionary[(int)node.Entity.ParentId].AddToNode(node);
						Nodes.RemoveAt(i);
					}
				}
			}
		}
	}
}
