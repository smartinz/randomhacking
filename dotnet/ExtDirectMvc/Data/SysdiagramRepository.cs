using System.Linq;
using ExtMvc.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class SysdiagramRepository
	{
		private readonly ISession _Northwind;


		public SysdiagramRepository(ISession Northwind)
		{
			_Northwind = Northwind;
		}

		public void Create(Sysdiagram v)
		{
			_Northwind.Save(v);
		}

		public Sysdiagram Read(int diagramId)
		{
			return _Northwind.Load<Sysdiagram>(diagramId);
		}

		public void Update(Sysdiagram v)
		{
			_Northwind.Update(v);
		}

		public void Delete(Sysdiagram v)
		{
			_Northwind.Delete(v);
		}

		public IQueryable<Sysdiagram> SearchNormal(string name, int? principalId, int? diagramId, int? version)
		{
			IQueryable<Sysdiagram> queryable = _Northwind.Linq<Sysdiagram>();
			if (name != default(string))
			{
				queryable = queryable.Where(x => x.Name == name);
			}
			if (principalId != default(int?))
			{
				queryable = queryable.Where(x => x.PrincipalId == principalId);
			}
			if (diagramId != default(int?))
			{
				queryable = queryable.Where(x => x.DiagramId == diagramId);
			}
			if (version != default(int?))
			{
				queryable = queryable.Where(x => x.Version == version);
			}

			return queryable;
		}
	}
}