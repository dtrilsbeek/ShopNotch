using System;
using System.Collections.Generic;
using System.Text;
using Data.Contexts;
using Data.Contexts.Mock;
using Data.Interfaces;
using Data.Models;

namespace Data.Repositories
{
	public class CategoryRepository : Repository<Category>
	{
		private static ICategoryContext _context;

		public CategoryRepository(ICategoryContext context):base(context)
		{
			_context = context;
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
