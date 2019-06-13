using Data.Interfaces;

namespace Logic.Cart
{
	public class CartItem : IEntity
	{
		public int Id { get; }
		public int ProductId { get; set; }
		public int Amount { get; set; }
	}
}
