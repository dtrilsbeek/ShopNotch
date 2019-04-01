using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;

namespace Data.Repositories
{
	public class Repository<T> : IRepository<T> where T : class, IEntity
	{
		public IEnumerable<T> List { get; }
		public void Add(T entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(T entity)
		{
			throw new NotImplementedException();
		}

		public void Update(T entity)
		{
			throw new NotImplementedException();
		}

		public T FindById(int Id)
		{
			throw new NotImplementedException();
		}
	}
}
