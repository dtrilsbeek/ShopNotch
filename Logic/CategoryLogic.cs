using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Repositories;
using Data.Contexts;
using Data.Contexts.Mock;
using Data.Interfaces;
using Logic.Helpers.TreeView;
using Logic.Interfaces;

namespace Logic
{
	public class CategoryLogic : ICategoryLogic
	{
		private CategoryRepository _categoryRepository;

		public CategoryLogic(IDbConfig dbConfig)
		{
			_categoryRepository = new CategoryRepository(new CategorySqlContext(dbConfig));
		}

		public CategoryLogic()
		{
			_categoryRepository = new CategoryRepository(new CategoryMockingContext());
		}

		public IEnumerable<Category> GetAll()
		{
			return _categoryRepository.GetAll();
		}

		public void Add(Category entity)
		{
			_categoryRepository.Add(entity);
		}

		public void Delete(Category entity)
		{
			_categoryRepository.Delete(entity);
		}

		public void Update(Category entity)
		{
			_categoryRepository.Update(entity);
		}

		public Category GetById(int id)
		{
			return _categoryRepository.GetById(id);
		}

		public TreeView GetCategoryTree()
		{
			List<IParentEntity> categories = new List<IParentEntity>(_categoryRepository.GetAll().ToList());

			return new TreeView(categories); ;
		}
	}
}