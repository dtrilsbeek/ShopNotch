using Data.Models;
using Logic.Helpers.TreeView;

namespace Logic.Interfaces
{
	public interface ICategoryLogic : IEntityLogic<Category>
	{
		TreeView GetCategoryTree();
	}
}