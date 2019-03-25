using System.Collections.Generic;

namespace Data.Interfaces
{
	public interface IProductContext
	{
		void Add(IProduct product);

		IEnumerable<IProduct> GetAll();

		IProduct GetById(int id);
	}
}