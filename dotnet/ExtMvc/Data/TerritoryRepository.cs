using System.Linq;
using ExtMvc.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class TerritoryRepository
	{
		private readonly ISession _Northwind;


		public TerritoryRepository(ISession Northwind)
		{
			_Northwind = Northwind;
		}

		public void Create(Territory v)
		{
			_Northwind.Save(v);
		}

		public Territory Read(string territoryId)
		{
			return _Northwind.Load<Territory>(territoryId);
		}

		public void Update(Territory v)
		{
			_Northwind.Update(v);
		}

		public void Delete(Territory v)
		{
			_Northwind.Delete(v);
		}

		public IQueryable<Territory> SearchNormal(string territoryId, string territoryDescription, Region region)
		{
			IQueryable<Territory> queryable = _Northwind.Linq<Territory>();
			if (territoryId != default(string))
			{
				queryable = queryable.Where(x => x.TerritoryId == territoryId);
			}
			if (territoryDescription != default(string))
			{
				queryable = queryable.Where(x => x.TerritoryDescription == territoryDescription);
			}
			if (region != default(Region))
			{
				queryable = queryable.Where(x => x.Region == region);
			}

			return queryable;
		}
	}
}