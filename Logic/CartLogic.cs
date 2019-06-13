using System.Collections.Generic;
//using Logic.Cart;
using Logic.Interfaces;

namespace Logic
{
	public class CartLogic : ICartLogic
	{
		private Dictionary<int, int> items;

		public CartLogic()
		{
			items = new Dictionary<int, int>();
		}

		public Dictionary<int, int> GetAll()
		{
			return items;
		}

		public void Add(int productId, int amount)
		{
			
		}

		public void Delete(int productId, int amount)
		{

		}
	}
}