using System.Collections.Generic;

namespace Logic.Interfaces
{
	public interface ICartLogic
	{
		Dictionary<int, int> GetAll();
		Dictionary<int, CartItem> GetAllProducts();
		void Add(int productId, int amount);
		void Delete(int productId, int amount);
		void AddToCart(int? productId, int? amount);
	}
}