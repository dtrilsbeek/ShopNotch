using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Repositories;
using Data.Contexts;
using Logic.Interfaces;

namespace Logic
{
	public class CategoryLogic : ILogic<Category>
	{
		private Repository<Category> _categoryRepository;
		private CategorySqlContext _context;

		public CategoryLogic()
		{
			// Bij gebrek aan beter.
			// TODO: How to extend repository functionality that is not generic
			_context = new CategorySqlContext();
			_categoryRepository = new Repository<Category>( _context );
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

		public IEnumerable<Category> GetParentCategories(Category category)
		{
			return _context.GetParentCategories(category);
		}
	}
}