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

			// TODO: How to extend repository with functionality that is not generic
			// Bij gebrek aan beter.
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
		public void Add(Category entity, int[] parentCategories)
		{
			Category category = _context.AddReturn(entity);

			SetParentCategories(category, parentCategories);
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
		public void SetParentCategories(Category category, int[] parentCategories)
		{
			foreach (int parentCategory in parentCategories)
			{
				_context.SetParentCategory(category, parentCategory);
			}
		}
	}
}