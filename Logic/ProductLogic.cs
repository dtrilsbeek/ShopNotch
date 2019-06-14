using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Repositories;
using Data.Contexts;
using Data.Contexts.Mock;
using Data.Interfaces;
using Logic.Interfaces;

namespace Logic
{
	public class ProductLogic : IProductLogic
	{
		private ProductRepository _productRepository;

		public ProductLogic(IDbConfig dbConfig)
		{
			_productRepository = new ProductRepository( new ProductSqlContext(dbConfig));
		}
		public ProductLogic()
		{
			_productRepository = new ProductRepository(new ProductMockingContext());
		}

		public IEnumerable<Product> GetAll()
		{
			return _productRepository.GetAll();
		}

		public void Add(Product entity)
		{
			_productRepository.Add(entity);
		}

		public void Delete(Product entity)
		{
			_productRepository.Delete(entity);
		}

		public void Update(Product entity)
		{
			_productRepository.Update(entity);
		}

		public Product GetById(int id)
		{
			return _productRepository.GetById(id);
		}

		public IEnumerable<Product> GetByCategoryId(int id)
		{
			return _productRepository.GetByCategoryId(id);
		}
	}
}