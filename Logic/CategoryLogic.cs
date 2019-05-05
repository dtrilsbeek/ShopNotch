﻿using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Repositories;
using Data.Contexts;
using Data.Interfaces;
using Logic.Helpers.TreeView;
using Logic.Interfaces;

namespace Logic
{
	public class CategoryLogic : ILogic<Category>
	{
		private CategoryRepository _categoryRepository;

		public CategoryLogic()
		{
			_categoryRepository = new CategoryRepository(new CategorySqlContext());
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
			Category category = _categoryRepository.AddReturn(entity);

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

		public TreeView GetCategoryTree()
		{
			List<IParentEntity> categories = new List<IParentEntity>(_categoryRepository.GetAll().ToList());

			return new TreeView(categories); ;
		}

		public IEnumerable<Category> GetParentCategories(Category category)
		{
			return _categoryRepository.GetParentCategories(category);
		}

		public void SetParentCategories(Category category, int[] parentCategories)
		{
			foreach (int parentCategory in parentCategories)
			{
				_categoryRepository.SetParentCategory(category, parentCategory);
			}
		}
	}
}