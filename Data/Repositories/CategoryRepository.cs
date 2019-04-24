using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;
using Data.Models;

namespace Data.Repositories
{
	class CategoryRepository : Repository<Category>
	{
		public CategoryRepository(IContext<Category> context):base(context)
		{

		}
	}
}
