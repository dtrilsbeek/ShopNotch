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
		private DbConfig _dbConfig;
		protected BaseSql(DbConfig dbConfig)
		{
			_dbConfig = dbConfig;
		}

		
		protected IEnumerable<TEntity> ExecuteQuery(SqlCommand command)
		{
			using (SqlConnection connection = new SqlConnection(_dbConfig))
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
			using (SqlConnection connection = new SqlConnection(_dbConfig))
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

		protected void ExecuteNonQueryStoredProcedure(string procedureName)
		{
			using (var conn = new SqlConnection(_dbConfig))
			using (var command = new SqlCommand(procedureName, conn)
			{
				CommandType = CommandType.StoredProcedure
			})
			{
				conn.Open();
				command.ExecuteNonQuery();
			}
		}

		protected IEnumerable<TEntity> ExecuteStoredProcedure(string procedureName, List<SqlParameter> sqlParameters)
		{
			using (SqlConnection conn = new SqlConnection(_dbConfig))
			{
				conn.Open();

				SqlCommand cmd = new SqlCommand(procedureName, conn);

				cmd.CommandType = CommandType.StoredProcedure;

				foreach (var sqlParameter in sqlParameters)
				{
					cmd.Parameters.Add(sqlParameter);
				}

				using (SqlDataReader reader = cmd.ExecuteReader())
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
