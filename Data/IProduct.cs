using System.ComponentModel;
using System.Data.SqlTypes;

namespace Data
{
	public interface IProduct
	{
		string Name { get; set; }

		string Description { get; set; }

		decimal Price { get; set; }

		string SKU { get; set; }

		int Length { get; set; }

		int Width { get; set; }

		int Height { get; set; }
	}
}