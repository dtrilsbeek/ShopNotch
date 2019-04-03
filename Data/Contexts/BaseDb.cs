using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data.Contexts
{
	public abstract class BaseDb<TEntity>
	{
		protected IEnumerable<TEntity> GetAll(IDbCommand command)
		{
			using (var reader = command.ExecuteReader())
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

		protected abstract void Map(IDataRecord record, TEntity entity);
		protected abstract TEntity CreateEntity();
	}

}
