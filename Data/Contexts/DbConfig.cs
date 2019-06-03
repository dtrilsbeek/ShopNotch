using System.IO;
using Data.Interfaces;

namespace Data.Contexts
{
	public class DbConfig : IDbConfig
	{
		private string _connectionString;
		public DbConfig(string connectionString)
		{
			_connectionString = connectionString;
		}

		public string GetConnectionString()
		{
			return _connectionString;
		}
	}
}
