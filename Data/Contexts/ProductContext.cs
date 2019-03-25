using System.Collections.Generic;
using Data.Interfaces;

namespace Data.Contexts
{
	public class ProductContext : IProductContext
	{
		public void Add(IProduct product)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<IProduct> GetAll()
		{
			throw new System.NotImplementedException();
		}

		public IProduct GetById(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}