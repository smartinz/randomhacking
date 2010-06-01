using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class TerritoryRepository : IRepository
	{
		private readonly ISessionFactory _northwind;


		public TerritoryRepository(ISessionFactory northwind)
		{
			_northwind = northwind;
		}

		public void Create(Territory v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public Territory Read(string territoryId)
		{
			return _northwind.GetCurrentSession().Load<Territory>(territoryId);
		}

		public void Update(Territory v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(Territory v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<Territory> SearchNormal(string territoryDescription)
		{
			IQueryable<Territory> queryable = _northwind.GetCurrentSession().Linq<Territory>();
			if(!string.IsNullOrEmpty(territoryDescription))
			{
				queryable = queryable.Where(x => x.TerritoryDescription.StartsWith(territoryDescription));
			}

			return new QueryablePresentableSet<Territory>(queryable);
		}
	}
}