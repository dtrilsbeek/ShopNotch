using System;
using System.Collections.Generic;
using Data.Interfaces;

namespace Data
{
	public class ProductRepository
	{
		private readonly IProductContext _context;

		public ProductRepository(IProductContext context)
		{
			_context = context;
		}

		public void Add(IProduct product)
		{
			_context.Add(product);
		}

		public IEnumerable<IProduct> GetAll()
		{
			return _context.GetAll();
		}
	}
}
