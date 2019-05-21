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
		private ProductSqlContext _context;

		public ProductRepository(IContext<Product> context):base(context)
		{
			_context = (ProductSqlContext) context;
		}


		public IEnumerable<Product> getByCategoryId(int id)
		{
			_context.GetByCategoryId(id);
		}
	}
}
