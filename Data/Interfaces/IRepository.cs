using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data.Interfaces;

namespace Data
{
	public interface IRepository<T> where T : IEntity
	{
		IEnumerable<T> List { get; }
		void Add(T entity);
		void Delete(T entity);
		void Update(T entity);
		T FindById(int Id);
	}
}