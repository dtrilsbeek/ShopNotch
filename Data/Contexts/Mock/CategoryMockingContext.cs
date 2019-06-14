using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Data.Interfaces;
using Data.Models;

namespace Data.Contexts.Mock
{
	public class CategoryMockingContext : ICategoryContext
	{
		private List<Category> categories;

		public CategoryMockingContext()
		{
			categories = new List<Category>();
			CreateCategories();
		}

		private void CreateCategories()
		{
			var categoryDictionary = new Dictionary<string, int?>
			{
				["Laptops"] = null,
				["Televisies"] = null,
				["Beamers"] = null,
				["Telefoons"] = null,
				["Gaming"] = 0,
				["SmartTv"] = 1,
				["Beamers"] = 1,
				["VasteTelefoons"] = 2,
				["Smartphones"] = 2,
				["Foto"] = null,
			};

			int id = 0;
			foreach (var (name, parentId) in categoryDictionary)
			{
				categories.Add(CreateCategory(id, name, parentId));
				id++;
			}
		}

		private Category CreateCategory(int id, string name, int? parentId)
		{
			return new Category
			{
				Id = id,
				Name = name,
				ParentId = parentId
			};
		}

		public IEnumerable<Category> GetAll()
		{
			return categories;
		}

		public Category GetById(int id)
		{
			return categories.FirstOrDefault(c => c.Id == id);
		}

		public IEnumerable<Category> GetParentCategories(Category category)
		{
			throw new NotImplementedException();
		}

		public void SetParentCategory(Category category, int parentCategory)
		{
			throw new NotImplementedException();
		}

		public void Add(Category entity)
		{

		}

		public void Delete(Category entity)
		{

		}

		public void Update(Category entity)
		{

		}

		public Category AddReturn(Category entity)
		{
			return entity;
		}
	}
}
