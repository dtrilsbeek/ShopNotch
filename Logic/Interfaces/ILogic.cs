using System.Collections.Generic;
using Data.Models;

namespace Logic.Interfaces
{
	public interface ILogic
	{
		IEnumerable<Product> GetAll();
	}
}