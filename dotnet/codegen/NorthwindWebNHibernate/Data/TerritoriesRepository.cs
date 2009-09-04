namespace NorthwindWebNHibernate.Data
{
	public class TerritoriesRepository
	{
		private NorthwindWebNHibernate.Context _context;
		
		public TerritoriesRepository(NorthwindWebNHibernate.Context context)
		{
			_context = context;
		}
		
		public void Create(NorthwindWebNHibernate.Business.Territories v)
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

		public NorthwindWebNHibernate.Business.Territories Read(string TerritoryId)
		{
			return _context.NorthwindDbo.Get<NorthwindWebNHibernate.Business.Territories>(TerritoryId);
		}

		public void Update(NorthwindWebNHibernate.Business.Territories v)
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

		public void Delete(NorthwindWebNHibernate.Business.Territories v)
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

				public System.Collections.Generic.IEnumerable<NorthwindWebNHibernate.Business.Territories> Search(string territoryId, string territoryDescription, NorthwindWebNHibernate.Business.Region fkTerritoriesRegion)
				{
					return _context.NorthwindDbo.CreateCriteria<NorthwindWebNHibernate.Business.Territories>()
									.Add(NHibernate.Criterion.Restrictions.Eq("territoryId", territoryId))
												.Add(NHibernate.Criterion.Restrictions.Eq("territoryDescription", territoryDescription))
												.Add(NHibernate.Criterion.Restrictions.Eq("fkTerritoriesRegion", fkTerritoriesRegion))
								
						.List<NorthwindWebNHibernate.Business.Territories>();
				}
				
	}
}
