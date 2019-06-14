using System.Collections.Generic;
using Data.Models;

namespace Data.Interfaces
{
	public interface IProductContext : IContext<Product>
	{
		IEnumerable<Product> GetByCategoryId(int id);
	}
}