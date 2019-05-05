using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;

namespace Logic.Helpers.TreeView
{
	public class TreeView
	{
		public Node MainNode { get; set; }
		public Dictionary<int, int?> ParentDictionary;


		public TreeView(List<IParentEntity> entities)
		{
			MainNode = new Node();
			ParentDictionary = entities.ToDictionary(x => x.Id, x => x.ParentId);

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
