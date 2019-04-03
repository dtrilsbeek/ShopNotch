using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Repositories;
using Data.Contexts;
using Logic.Interfaces;

namespace Logic
{
	public class ProductLogic : ILogic
	{
		private Repository<Product> _productRepository;

		public ProductLogic()
		{
			_productRepository = new Repository<Product>( new ProductSqlContext() );
		}

		public IEnumerable<Product> GetAll()
		{
			return _productRepository.GetAll() as IEnumerable<Product>;
		}

	}
}