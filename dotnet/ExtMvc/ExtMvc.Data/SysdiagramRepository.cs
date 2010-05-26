using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class SysdiagramRepository
	{
		private readonly ISessionFactory _northwind;


		public SysdiagramRepository(ISessionFactory northwind)
		{
			_northwind = northwind;
		}

		public void Create(Sysdiagram v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public Sysdiagram Read(int diagramId)
		{
			return _northwind.GetCurrentSession().Load<Sysdiagram>(diagramId);
		}

		public void Update(Sysdiagram v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(Sysdiagram v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<Sysdiagram> Search(string name, int? principalId, int? diagramId, int? version)
		{
			IQueryable<Sysdiagram> queryable = _northwind.GetCurrentSession().Linq<Sysdiagram>();
			if(name != default(string))
			{
				queryable = queryable.Where(x => x.Name.StartsWith(name));
			}
			if(principalId != default(int?))
			{
				queryable = queryable.Where(x => x.PrincipalId == principalId);
			}
			if(diagramId != default(int?))
			{
				queryable = queryable.Where(x => x.DiagramId == diagramId);
			}
			if(version != default(int?))
			{
				queryable = queryable.Where(x => x.Version == version);
			}

			return new Nexida.Infrastructure.QueryablePresentableSet<Sysdiagram>(queryable);
		}
	}
}