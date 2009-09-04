namespace NorthwindWebNHibernate.Data
{
	public class ShippersRepository
	{
		private NorthwindWebNHibernate.Context _context;
		
		public ShippersRepository(NorthwindWebNHibernate.Context context)
		{
			_context = context;
		}
		
		public void Create(NorthwindWebNHibernate.Business.Shippers v)
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

		public NorthwindWebNHibernate.Business.Shippers Read(int ShipperId)
		{
			return _context.NorthwindDbo.Get<NorthwindWebNHibernate.Business.Shippers>(ShipperId);
		}

		public void Update(NorthwindWebNHibernate.Business.Shippers v)
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

		public void Delete(NorthwindWebNHibernate.Business.Shippers v)
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

				public System.Collections.Generic.IEnumerable<NorthwindWebNHibernate.Business.Shippers> Search(int shipperId, string companyName, string phone)
				{
					return _context.NorthwindDbo.CreateCriteria<NorthwindWebNHibernate.Business.Shippers>()
									.Add(NHibernate.Criterion.Restrictions.Eq("shipperId", shipperId))
												.Add(NHibernate.Criterion.Restrictions.Eq("companyName", companyName))
												.Add(NHibernate.Criterion.Restrictions.Eq("phone", phone))
								
						.List<NorthwindWebNHibernate.Business.Shippers>();
				}
				
	}
}
