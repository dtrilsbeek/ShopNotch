namespace ShopNotch.Models.Classes
{
	public class ProductModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string Sku { get; set; }
		public double? Length { get; set; }
		public double? Width { get; set; }
		public double? Height { get; set; }
		public int? StockQty { get; set; }
		public double? Weight { get; set; }
	}
}
