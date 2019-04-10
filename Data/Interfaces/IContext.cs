using System.Collections.Generic;

namespace Data.Interfaces
{
	public interface IContext<T> where T : IEntity
	{
		IEnumerable<T> GetAll();

		void Add(T entity);

		void Delete(T entity);

		void Update(T entity);

		T GetById(int id);
	}
}