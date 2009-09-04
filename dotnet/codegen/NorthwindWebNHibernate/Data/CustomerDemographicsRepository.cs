namespace NorthwindWebNHibernate.Data
{
	public class CustomerDemographicsRepository
	{
		private NorthwindWebNHibernate.Context _context;
		
		public CustomerDemographicsRepository(NorthwindWebNHibernate.Context context)
		{
			_context = context;
		}
		
		public void Create(NorthwindWebNHibernate.Business.CustomerDemographics v)
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

		public NorthwindWebNHibernate.Business.CustomerDemographics Read(string CustomerTypeId)
		{
			return _context.NorthwindDbo.Get<NorthwindWebNHibernate.Business.CustomerDemographics>(CustomerTypeId);
		}

		public void Update(NorthwindWebNHibernate.Business.CustomerDemographics v)
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

		public void Delete(NorthwindWebNHibernate.Business.CustomerDemographics v)
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

				public System.Collections.Generic.IEnumerable<NorthwindWebNHibernate.Business.CustomerDemographics> Search(string customerTypeId, string customerDesc)
				{
					return _context.NorthwindDbo.CreateCriteria<NorthwindWebNHibernate.Business.CustomerDemographics>()
									.Add(NHibernate.Criterion.Restrictions.Eq("customerTypeId", customerTypeId))
												.Add(NHibernate.Criterion.Restrictions.Eq("customerDesc", customerDesc))
								
						.List<NorthwindWebNHibernate.Business.CustomerDemographics>();
				}
				
	}
}
