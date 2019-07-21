using System.Collections.Generic;

namespace Logic.Interfaces
{
	public interface ICartLogic
	{
		Dictionary<int, int> GetAll();
		Dictionary<int, CartItem> GetAllProducts();
		Dictionary<int, int> Add(int productId, int amount);
		void Delete(int productId, int amount);
	}
}