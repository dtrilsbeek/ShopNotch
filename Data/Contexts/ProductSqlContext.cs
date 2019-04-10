using System.Collections.Generic;
using System.Data;
using Data.Interfaces;
using Data.Models;

namespace Data.Contexts
{
	public class ProductSqlContext : BaseDb<Product>, IRepository<Product>
	{
		public IEnumerable<Product> GetAll()
		{
			return ExecuteQuery("SELECT * FROM Product");
		}

		protected override Product CreateEntity()
		{
			return new Product();
		}

		public void Add(Product entity)
		{
			bool result = ExecuteNonQuery(
				"INSERT INTO Product" +
				$"(Name, Description, Price, Sku, Length, Width, Height, StockQty, Weight)" +
				$"WHERE Id = {entity.Id}");
		}

		public void Delete(Product entity)
		{
			throw new System.NotImplementedException();
		}

		public void Update(Product entity)
		{
			bool result = ExecuteNonQuery(
				"UPDATE Product" +
				$"SET Name = {entity.Name}, " +
				$"Description = {entity.Description}, " +
				$"Price = {entity.Price}, " +
				$"Sku = {entity.Sku}, " +
				$"Length = {entity.Length}, " +
				$"Width = {entity.Width}, " +
				$"Height = {entity.Height}, " +
				$"StockQty = {entity.StockQty}, " +
				$"Weight = {entity.Weight}, " +
				$"WHERE Id = {entity.Id}");
		}

		public Product FindById(int id)
		{
			throw new System.NotImplementedException();
		}

		protected override void Map(IDataRecord record, Product entity)
		{
			entity.Id = (int)record["Id"];
			entity.Name = ConvertFromDbVal<string>(record["Name"]);
			entity.Description = ConvertFromDbVal<string>(record["Description"]);
			entity.Price = ConvertFromDbVal<decimal>(record["Price"]);
			entity.Sku = ConvertFromDbVal<string>(record["Sku"]);
			entity.Length = ConvertFromDbVal<double>(record["Length"]);
			entity.Width = ConvertFromDbVal<double>(record["Width"]);
			entity.Height = ConvertFromDbVal<double>(record["Height"]);
			entity.StockQty = ConvertFromDbVal<int>(record["StockQty"]);
			entity.Weight = ConvertFromDbVal<double>(record["Weight"]);
		}
	}
}
