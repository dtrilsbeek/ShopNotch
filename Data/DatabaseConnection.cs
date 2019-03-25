using System.Data.SqlClient;

namespace Data
{
	public class DatabaseConnection
	{
		public DatabaseConnection(string connectionString)
		{
			SqlConnection = new SqlConnection(connectionString);
		}

		internal SqlConnection SqlConnection { get; }
	}
}
