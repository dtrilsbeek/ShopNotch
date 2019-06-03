using System.IO;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

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
