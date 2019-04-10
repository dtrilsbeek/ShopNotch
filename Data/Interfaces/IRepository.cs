using System;
using System.Collections.Generic;
using Data.Interfaces;

namespace Data
{
	public interface IRepository<T> where T : IEntity
	{
		IEnumerable<T> GetAll();
		void Add(T entity);
		void Delete(T entity);
		void Update(T entity);
		T GetById(int id);
	}
}