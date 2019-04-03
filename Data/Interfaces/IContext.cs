using System.Collections.Generic;

namespace Data.Interfaces
{
	public interface IContext
	{
		IEnumerable<IEntity> GetAll();
	}
}