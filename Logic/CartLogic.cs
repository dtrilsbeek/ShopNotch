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

//		public IEnumerable<CartItem> GetAll()
//		{
//			return items;
//		}
//
//		public void Add(CartItem entity)
//		{
//			items.Add(entity);
//		}
//
//		public void Delete(CartItem entity)
//		{
//			items.RemoveAll(i => i.Id)
//		}
//
//		public void Update(CartItem entity)
//		{
//			throw new System.NotImplementedException();
//		}
//
//		public CartItem GetById(int id)
//		{
//			throw new System.NotImplementedException();
//		}
	}
}