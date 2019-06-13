using System.Collections.Generic;
using Data.Models;

namespace Data.Interfaces
{
	public interface ICategoryContext : IContext<Category>
	{
		IEnumerable<Category> GetParentCategories(Category category);
		void SetParentCategory(Category category, int parentCategory);
	}
}