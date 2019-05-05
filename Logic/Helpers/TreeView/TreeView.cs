using System.Collections.Generic;
using Data.Interfaces;

namespace Logic.Helpers.TreeView
{
	public class TreeView
	{
		public Node MainNode { get; set; }

		public TreeView(List<IParentEntity> entities)
		{
			MainNode = new Node();
			CreateTree(entities);
		}

		private void CreateTree(List<IParentEntity> entities)
		{
			foreach (IParentEntity entity in entities)
			{
				MainNode.AddEntity(entity);					
			}
		}
	}
}
