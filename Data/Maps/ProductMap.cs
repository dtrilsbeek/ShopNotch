using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Data.Models;

namespace Data.Maps
{
	class ProductMap
	{
		public void Map(IDataRecord record, Product product)
		{

			product.Id = (int) record["Id"];
			product.Name = (string) record["Name"];
			product.Description = (string) record["Description"];
			product.Price = (decimal) record["Price"];
			product.Sku = (string) record["Sku"];
			product.Length = (double) record["Length"];
			product.Width = (double) record["Width"];
			product.Height = (double) record["Height"];
			product.StockQty = (int) record["StockQty"];
			product.Weight = (double) record["Weight"];
		}
	}
}