using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Data.Interfaces;
using Data.Models;

namespace Data.Contexts.Mock
{
	public class ProductMockingContext : IProductContext
	{
		private List<Product> products;

		public ProductMockingContext()
		{
			products = new List<Product>();
			CreateProducts();
		}

		private void CreateProducts()
		{
			var ProductDictionary = new Dictionary<string, int?>
			{
				["Laptop"] = null,
				["Laptop2"] = null,
				["Phone"] = null,
				["Phone2"] = null,
				["Book"] = 0,
				["Book2"] = 1,
				["Test"] = 1,
				["Test2"] = 2,
				["iPhone"] = 2,
				["Camera"] = null,
			};

			int id = 0;
			foreach (var (name, parentId) in ProductDictionary)
			{
				products.Add(CreateProduct(id, name));
				id++;
			}
		}

		private Product CreateProduct(int id, string name)
		{
			return new Product
			{
				Id = id,
				Name = name,
			};
		}

		public IEnumerable<Product> GetAll()
		{
			return products;
		}

		public Product GetById(int id)
		{
			return products.FirstOrDefault(c => c.Id == id);
		}

		public IEnumerable<Product> GetByCategoryId(int id)
		{
			return products.Where(c => c.Id == id);
		}

		public void Add(Product entity)
		{

		}

		public void Delete(Product entity)
		{

		}

		public void Update(Product entity)
		{

		}

	}
}
