using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Data.Interfaces;
using Data.Models;

namespace Data.Contexts
{
	public class DbContext : IRepository<T> where T : IEntity
	{
		public IEnumerable<IEntity> List => throw new System.NotImplementedException();

		public void Add(IEntity entity)
		{


			throw new System.NotImplementedException();
		}

		public void Delete(IEntity entity)
		{
			throw new System.NotImplementedException();
		}

		public IEntity FindById(int id)
		{
			throw new System.NotImplementedException();
		}

		public void Update(IEntity entity)
		{
			throw new System.NotImplementedException();
		}

		private IEnumerable<IEntity> GetAll()
		{
			// Set up your connection
			SqlConnection conn = new SqlConnection();
			conn.Open();

			SqlCommand cmd = new SqlCommand("SELECT * FROM Person", conn);
			SqlDataReader reader = cmd.ExecuteReader();

			IEnumerable<IEntity> entities

			while (reader.Read())
			{
				Person p = new Person(reader, conn);
				personRecords.Add(p);
			}

			return personRecords;
		}
	}
}