namespace NorthwindWebNHibernate.Data
{
	public class SysdiagramsRepository
	{
		private NorthwindWebNHibernate.Context _context;
		
		public SysdiagramsRepository(NorthwindWebNHibernate.Context context)
		{
			_context = context;
		}
		
		public void Create(NorthwindWebNHibernate.Business.Sysdiagrams v)
		{
			using(NHibernate.ITransaction tx = _context.NorthwindDbo.BeginTransaction())
			{
				try
				{
					_context.NorthwindDbo.Save(v);
					tx.Commit();
				}
				catch
				{
					tx.Rollback();
					throw;
				}
			}
		}

		public NorthwindWebNHibernate.Business.Sysdiagrams Read(int DiagramId)
		{
			return _context.NorthwindDbo.Get<NorthwindWebNHibernate.Business.Sysdiagrams>(DiagramId);
		}

		public void Update(NorthwindWebNHibernate.Business.Sysdiagrams v)
		{
			using(NHibernate.ITransaction tx = _context.NorthwindDbo.BeginTransaction())
			{
				try
				{
					_context.NorthwindDbo.Update(v);
					tx.Commit();
				}
				catch
				{
					tx.Rollback();
					throw;
				}
			}
		}

		public void Delete(NorthwindWebNHibernate.Business.Sysdiagrams v)
		{
			using (NHibernate.ITransaction tx = _context.NorthwindDbo.BeginTransaction())
			{
				try
				{
					_context.NorthwindDbo.Delete(v);
					tx.Commit();
				}
				catch
				{
					tx.Rollback();
					throw;
				}
			}
		}

				public System.Collections.Generic.IEnumerable<NorthwindWebNHibernate.Business.Sysdiagrams> Search(string name, int principalId, int diagramId, int? version)
				{
					return _context.NorthwindDbo.CreateCriteria<NorthwindWebNHibernate.Business.Sysdiagrams>()
									.Add(NHibernate.Criterion.Restrictions.Eq("name", name))
												.Add(NHibernate.Criterion.Restrictions.Eq("principalId", principalId))
												.Add(NHibernate.Criterion.Restrictions.Eq("diagramId", diagramId))
												.Add(NHibernate.Criterion.Restrictions.Eq("version", version))
								
						.List<NorthwindWebNHibernate.Business.Sysdiagrams>();
				}
				
	}
}
