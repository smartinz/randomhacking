namespace NorthwindWebNHibernate.Data
{
	public class RegionRepository
	{
		private NorthwindWebNHibernate.Context _context;
		
		public RegionRepository(NorthwindWebNHibernate.Context context)
		{
			_context = context;
		}
		
		public void Create(NorthwindWebNHibernate.Business.Region v)
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

		public NorthwindWebNHibernate.Business.Region Read(int RegionId)
		{
			return _context.NorthwindDbo.Get<NorthwindWebNHibernate.Business.Region>(RegionId);
		}

		public void Update(NorthwindWebNHibernate.Business.Region v)
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

		public void Delete(NorthwindWebNHibernate.Business.Region v)
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

				public System.Collections.Generic.IEnumerable<NorthwindWebNHibernate.Business.Region> Search(int regionId, string regionDescription)
				{
					return _context.NorthwindDbo.CreateCriteria<NorthwindWebNHibernate.Business.Region>()
									.Add(NHibernate.Criterion.Restrictions.Eq("regionId", regionId))
												.Add(NHibernate.Criterion.Restrictions.Eq("regionDescription", regionDescription))
								
						.List<NorthwindWebNHibernate.Business.Region>();
				}
				
	}
}
