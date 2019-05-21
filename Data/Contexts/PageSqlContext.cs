using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Data.Interfaces;
using Data.Models;

namespace Data.Contexts
{
	public class PageSqlContext : BaseSql<Page>, IContext<Page>
	{
		public IEnumerable<Page> GetAll()
		{
			SqlCommand command = new SqlCommand(
				"SELECT * FROM Product"
			);

			return ExecuteQuery(command);
		}

		protected override Page CreateEntity()
		{
			return new Page();
		}

		public void Add(Page entity)
		{
			string queryString =
				"INSERT INTO Product " +
				"(Name, Description, Price, Sku, Length, Width, Height, StockQty, Weight) " +
				"VALUES (@Name, @Description, @Price, @Sku, @Length, @Width, @Height, @StockQty, @Weight)";

			SqlCommand command = new SqlCommand(queryString);
/*
			command.Parameters.AddWithValue("@Name", entity.Name);
			command.Parameters.AddWithValue("@Description", entity.Description);
			command.Parameters.AddWithValue("@Price", entity.Price);
			command.Parameters.AddWithValue("@Sku", entity.Sku);
			command.Parameters.AddWithValue("@Length", entity.Length);
			command.Parameters.AddWithValue("@Width", entity.Width);
			command.Parameters.AddWithValue("@Height", entity.Height);
			command.Parameters.AddWithValue("@StockQty", entity.StockQty);
			command.Parameters.AddWithValue("@Weight", entity.Weight);
*/

			ExecuteNonQuery(command);
		}

		public void Delete(Page entity)
		{
			SqlCommand command = new SqlCommand(
				$"DELETE FROM Product WHERE Id=@Id"
				);

			command.Parameters.AddWithValue("@Id", entity.Id);

			ExecuteNonQuery(command);
		}

		public void Update(Page entity)
		{
			string queryString =
				"UPDATE Product " +
				"SET " +
				"Name = @Name, " +
				"Description = @Description, " +
				"Price = @Price, " +
				"Sku = @Sku, " +
				"Length = @Length, " +
				"Width = @Width, " +
				"Height = @Height, " +
				"StockQty = @StockQty, " +
				"Weight = @Weight " +
				"WHERE Id = @Id";

			SqlCommand command = new SqlCommand(queryString);
/*
			command.Parameters.AddWithValue("@Id", entity.Id);
			command.Parameters.AddWithValue("@Name", entity.Name);
			command.Parameters.AddWithValue("@Description", entity.Description);
			command.Parameters.AddWithValue("@Price", entity.Price);
			command.Parameters.AddWithValue("@Sku", entity.Sku);
			command.Parameters.AddWithValue("@Length", entity.Length);
			command.Parameters.AddWithValue("@Width", entity.Width);
			command.Parameters.AddWithValue("@Height", entity.Height);
			command.Parameters.AddWithValue("@StockQty", entity.StockQty);
			command.Parameters.AddWithValue("@Weight", entity.Weight);
*/

			ExecuteNonQuery(command);
		}

		public Page GetById(int id)
		{
			SqlCommand command = new SqlCommand(
				$"SELECT * FROM Product WHERE Id = @Id"
			);

			command.Parameters.AddWithValue("@Id", id);


			return ExecuteQuery(command).First();
		}

		protected override void Map(IDataRecord record, Page entity)
		{
			entity.Id = (int)record["Id"];
/*			entity.Name = ConvertFromDbVal<string>(record["Name"]);
			entity.Description = ConvertFromDbVal<string>(record["Description"]);
			entity.Price = ConvertFromDbVal<decimal>(record["Price"]);
			entity.Sku = ConvertFromDbVal<string>(record["Sku"]);
			entity.Length = ConvertFromDbVal<double>(record["Length"]);
			entity.Width = ConvertFromDbVal<double>(record["Width"]);
			entity.Height = ConvertFromDbVal<double>(record["Height"]);
			entity.StockQty = ConvertFromDbVal<int>(record["StockQty"]);
			entity.Weight = ConvertFromDbVal<double>(record["Weight"]);*/
		}
	}
}
