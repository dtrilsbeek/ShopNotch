using System.Collections.Generic;
using Data.Interfaces;
using Data.Models;

namespace Logic.Interfaces
{
	public interface IEntityLogic<T> where T : IEntity
	{
		IEnumerable<T> GetAll();

		void Add(T entity);

		void Delete(T entity);

		void Update(T entity);

		T GetById(int id);
	}
}