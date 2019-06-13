using System.Collections.Generic;
using Data.Models;

namespace Logic.Interfaces
{
	public interface IProductLogic : IEntityLogic<Product>
	{
		IEnumerable<Product> GetByCategoryId(int id);
	}
}