using System;
using System.Collections.Generic;
using System.Text;
using Data.Contexts;
using Data.Interfaces;
using Data.Models;

namespace Data.Repositories
{
	public class CategoryRepository : Repository<Category>
	{
		private CategorySqlContext _context;

		public CategoryRepository(IContext<Category> context):base(context)
		{
			_context = (CategorySqlContext) context;
		}

		public Category AddReturn(Category entity)
		{
			return _context.GetById(entity.Id);
		}

		public IEnumerable<Category> GetParentCategories(Category category)
		{
			return _context.GetParentCategories(category);
		}

		public void SetParentCategory(Category category, int parentCategory)
		{
			_context.SetParentCategory(category, parentCategory);
		}
	}
}
