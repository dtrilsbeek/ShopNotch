using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Data.Contexts;
using Data.Interfaces;
using Data.Models;

namespace Data.Repositories
{
	public class Repository<T> : IRepository<IEntity> where T : class, IEntity
	{
		private IContext _context;

		public Repository(IContext context)
		{
			_context = context;
		}

		public IEnumerable<IEntity> GetAll()
		{
			return _context.GetAll();
		}

		public void Add(IEntity entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(IEntity entity)
		{
			throw new NotImplementedException();
		}

		public void Update(IEntity entity)
		{
			throw new NotImplementedException();
		}

		IEntity IRepository<IEntity>.FindById(int id)
		{
			throw new NotImplementedException();
		}
	}
}
