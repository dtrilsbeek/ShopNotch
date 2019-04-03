using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Data.Interfaces;
using Data.Models;

namespace Data.Contexts
{
	public class ProductContext : BaseDb<Product>, IContext
	{
		public IEnumerable<IEntity> GetAll()
		{
			return GetAll(new SqlCommand("SELECT * FROM Products"));
		}

		protected override void Map(IDataRecord record, Product entity)
		{
			entity.Id = (int)record["Id"];
			entity.Name = (string)record["Name"];
			entity.Description = (string)record["Description"];
			entity.Price = (decimal)record["Price"];
			entity.Sku = (string)record["Sku"];
			entity.Length = (double)record["Length"];
			entity.Width = (double)record["Width"];
			entity.Height = (double)record["Height"];
			entity.StockQty = (int)record["StockQty"];
			entity.Weight = (double)record["Weight"];
		}

		protected override Product CreateEntity()
		{
			return new Product();
		}
	}
}
