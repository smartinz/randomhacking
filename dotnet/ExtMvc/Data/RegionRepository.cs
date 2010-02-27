using System.Linq;
using ExtMvc.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class RegionRepository
	{
		private readonly ISession _Northwind;


		public RegionRepository(ISession Northwind)
		{
			_Northwind = Northwind;
		}

		public void Create(Region v)
		{
			_Northwind.Save(v);
		}

		public Region Read(int regionId)
		{
			return _Northwind.Load<Region>(regionId);
		}

		public void Update(Region v)
		{
			_Northwind.Update(v);
		}

		public void Delete(Region v)
		{
			_Northwind.Delete(v);
		}

		public IQueryable<Region> SearchNormal(int? regionId, string regionDescription)
		{
			IQueryable<Region> queryable = _Northwind.Linq<Region>();
			if (regionId != default(int?))
			{
				queryable = queryable.Where(x => x.RegionId == regionId);
			}
			if (regionDescription != default(string))
			{
				queryable = queryable.Where(x => x.RegionDescription == regionDescription);
			}

			return queryable;
		}
	}
}