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
	public class Repository<T> : IRepository<T> where T : IEntity
	{
		private IContext<T> _context;

		public Repository(IContext<T> context)
		{
			_context = context;
		}

		public IEnumerable<T> GetAll()
		{
			return _context.GetAll();
		}

		public void Add(T entity)
		{
			_context.Add(entity);
		}

		public void Delete(T entity)
		{
			_context.Delete(entity);
		}

		public void Update(T entity)
		{
			_context.Update(entity);
		}

		public T GetById(int id)
		{
			return _context.GetById(id);
		}
	}
}
