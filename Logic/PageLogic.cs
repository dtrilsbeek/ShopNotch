using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Repositories;
using Data.Contexts;
using Data.Interfaces;
using Logic.Interfaces;

namespace Logic
{
	public class PageLogic : IEntityLogic<Page>
	{
		private Repository<Page> _pageRepository;

		public PageLogic(IDbConfig dbConfig)
		{
			_pageRepository = new Repository<Page>( new PageSqlContext( dbConfig ));
		}

		public IEnumerable<Page> GetAll()
		{
			return _pageRepository.GetAll();
		}

		public void Add(Page entity)
		{
			_pageRepository.Add(entity);
		}

		public void Delete(Page entity)
		{
			_pageRepository.Delete(entity);
		}

		public void Update(Page entity)
		{
			_pageRepository.Update(entity);
		}

		public Page GetById(int id)
		{
			return _pageRepository.GetById(id);
		}

		public IEnumerable<Page> GetByCategoryId(int id)
		{
			throw new NotImplementedException();
		}
	}
}