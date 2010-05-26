using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class RegionRepository
	{
		private readonly ISessionFactory _northwind;


		public RegionRepository(ISessionFactory northwind)
		{
			_northwind = northwind;
		}

		public void Create(Region v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public Region Read(int regionId)
		{
			return _northwind.GetCurrentSession().Load<Region>(regionId);
		}

		public void Update(Region v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(Region v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<Region> Search(int? regionId, string regionDescription)
		{
			IQueryable<Region> queryable = _northwind.GetCurrentSession().Linq<Region>();
			if(regionId != default(int?))
			{
				queryable = queryable.Where(x => x.RegionId == regionId);
			}
			if(regionDescription != default(string))
			{
				queryable = queryable.Where(x => x.RegionDescription.StartsWith(regionDescription));
			}

			return new Nexida.Infrastructure.QueryablePresentableSet<Region>(queryable);
		}
	}
}