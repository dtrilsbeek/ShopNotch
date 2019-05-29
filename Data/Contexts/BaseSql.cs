using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Data.Interfaces;

namespace Data.Contexts
{
	public abstract class BaseSql<TEntity>
	{
		private string _connectionString = "Server=mssql.fhict.local;Database=dbi391176_elayed;User Id=dbi391176_elayed;Password=appelsenperen12;";

		protected IEnumerable<TEntity> ExecuteQuery(SqlCommand command)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				command.Connection = connection;
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				try
				{
					List<TEntity> items = new List<TEntity>();
					while (reader.Read())
					{
						var item = CreateEntity();
						Map(reader, item);
						items.Add(item);
					}

					return items;
				}
				finally
				{
					reader.Close();
				}
			}
		}

		protected bool ExecuteNonQuery(SqlCommand command)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				command.Connection = connection;
				connection.Open();
				try
				{
					int result = command.ExecuteNonQuery();

					if (result == 0)
					{
						return false;
					}
				}
				catch (Exception ex)
				{
					throw;
				}
				return true;
			}
		}

		protected void ExecuteNonStoredProcedure()
		{
			using (var conn = new SqlConnection(connectionString))
			using (var command = new SqlCommand("ProcedureName", conn)
			{
				CommandType = CommandType.StoredProcedure
			})
			{
				conn.Open();
				command.ExecuteNonQuery();
			}
		}

		protected IEnumerable<IEntity> ExecuteStoredProcedure()
		{
			using (SqlConnection conn = new SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI"))
			{
				conn.Open();

				// 1.  create a command object identifying the stored procedure
				SqlCommand cmd = new SqlCommand("CustOrderHist", conn);

				// 2. set the command object so it knows to execute a stored procedure
				cmd.CommandType = CommandType.StoredProcedure;

				// 3. add parameter to command, which will be passed to the stored procedure
				cmd.Parameters.Add(new SqlParameter("@CustomerID", custId));

				// execute the command
				using (SqlDataReader rdr = cmd.ExecuteReader())
				{
					// iterate through results, printing each to console
					while (rdr.Read())
					{
						Console.WriteLine("Product: {0,-35} Total: {1,2}", rdr["ProductName"], rdr["Total"]);
					}
				}
			}
		}

		protected static T ConvertFromDbVal<T>(object obj)
		{
			if (obj == null || obj == DBNull.Value)
			{
				return default(T);
			}

			return (T)obj;
		}

		protected abstract void Map(IDataRecord record, TEntity entity);
		protected abstract TEntity CreateEntity();
	}

}
