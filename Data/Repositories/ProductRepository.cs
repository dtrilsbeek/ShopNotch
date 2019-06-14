using System;
using System.Collections.Generic;
using System.Text;
using Data.Contexts;
using Data.Interfaces;
using Data.Models;

namespace Data.Repositories
{
	public class ProductRepository : Repository<Product>
	{
		private IProductContext _context;

		public ProductRepository(IProductContext context):base(context)
		{
			_context = context;
		}


		public IEnumerable<Product> GetByCategoryId(int id)
		{
			return _context.GetByCategoryId(id);
		}
	}
}
