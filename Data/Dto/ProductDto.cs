using Data.Interfaces;

namespace Data.Dto
{
	public class ProductDto : IProduct
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string SKU { get; set; }
		public int Length { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
	}
}
