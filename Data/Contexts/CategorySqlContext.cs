using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Data.Interfaces;
using Data.Models;

namespace Data.Contexts
{
	public class CategorySqlContext : BaseSql<Category>, IContext<Category>
	{
		public CategorySqlContext(IDbConfig dbConfig) : base(dbConfig)
		{
			
		}

		/*public IEnumerable<Category> GetAll()
		{
			SqlCommand command = new SqlCommand(
				"SELECT * FROM Category"
			);

			return ExecuteQuery(command);
		}*/

		public IEnumerable<Category> GetAll()
		{
			SqlCommand command = new SqlCommand(
				"SELECT " +
						"	child.Id," +
						"	child.Name," +
						"	parent.Id AS ParentId, " +
				"parent.Name AS ParentName " +
				"FROM Category AS child " +
				"LEFT JOIN Category AS parent ON child.ParentId = parent.Id"
			);

			return ExecuteQuery(command);
		}

		public Category GetById(int id)
		{
			SqlCommand command = new SqlCommand(
				"SELECT " +
				"	child.Id," +
				"	child.Name," +
				"	parent.Id AS ParentId, " +
				"parent.Name AS ParentName " +
				"FROM Category AS child " +
				"LEFT JOIN Category AS parent ON child.ParentId = parent.Id " +
				"WHERE child.Id = @Id"
			);

			command.Parameters.AddWithValue("@Id", id);


			return ExecuteQuery(command).First();
		}

		public IEnumerable<Category> GetParentCategories(Category category)
		{
			SqlCommand command = new SqlCommand(
		 "SELECT * FROM [Category] "+
				"WHERE Id IN (" +
					"SELECT CategoryId " +
					"FROM ParentCategories " +
					"WHERE CategoryId = @Id " +
				")"
			);

			command.Parameters.AddWithValue("@Id", category.Id);

			return ExecuteQuery(command);
		}

		protected override Category CreateEntity()
		{
			return new Category();
		}

		public void Add(Category entity)
		{
			string queryString =
				"INSERT INTO Category " +
				"(Name, ParentId) " +
				"VALUES (@Name, @ParentId) ";

			SqlCommand command = new SqlCommand(queryString);
			command.Parameters.AddWithValue("@Name", entity.Name);
			command.Parameters.AddWithValue("@ParentId", entity.ParentId ?? (object)DBNull.Value);

			ExecuteNonQuery(command);
		}

		public void Delete(Category entity)
		{
			SqlCommand command = new SqlCommand(
				$"DELETE FROM Category WHERE Id=@Id"
				);

			command.Parameters.AddWithValue("@Id", entity.Id);

			ExecuteNonQuery(command);
		}

		public void Update(Category entity)
		{
			string queryString =
				"UPDATE Category " +
				"SET " +
				"Name = @Name, ParentId = @ParentId " +
				"WHERE Id = @Id";

			SqlCommand command = new SqlCommand(queryString);
			command.Parameters.AddWithValue("@Id", entity.Id);
			command.Parameters.AddWithValue("@Name", entity.Name);
			command.Parameters.AddWithValue("@ParentId", entity.ParentId ?? (object)DBNull.Value);

			ExecuteNonQuery(command);
		}

		public void SetParentCategory(Category category, int parentCategory)
		{
			string queryString =
				"INSERT INTO ParentCategory" +
				"(CategoryId, ParentId) " +
				"VALUES (@CategoryId, @ParentId)";

			SqlCommand command = new SqlCommand(queryString);
			command.Parameters.AddWithValue("@CategoryId", category.Id);
			command.Parameters.AddWithValue("@ParentId", parentCategory);

			ExecuteNonQuery(command);

		}

		public Category AddReturn(Category entity)
		{
			string queryString =
				"DECLARE @ReturnTableVar table( Id int, Name nvarchar(100) ); " +
				"INSERT Category " +
				"(Name) " +
				"OUTPUT INSERTED.Id, INSERTED.Name " +
				"INTO @ReturnTableVar " +
				"VALUES (@Name); " +
				"SELECT Id, Name FROM @ReturnTableVar;";

			SqlCommand command = new SqlCommand(queryString);
			command.Parameters.AddWithValue("@Name", entity.Name);

			return ExecuteQuery(command).First();
		}


		protected override void Map(IDataRecord record, Category entity)
		{
			entity.Id = (int)record["Id"];
			entity.Name = ConvertFromDbVal<string>(record["Name"]);

			entity.ParentId = ConvertFromDbVal<int?>(record["ParentId"]);
			string pName = ConvertFromDbVal<string>(record["ParentName"]);
			if (entity.ParentId != null)
			{
				entity.Parent = new Category
				{
					Id = (int) entity.ParentId,
					Name = pName
				};
			}

			
		}
	}
}
