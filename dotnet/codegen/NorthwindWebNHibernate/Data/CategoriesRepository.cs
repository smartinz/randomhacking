namespace NorthwindWebNHibernate.Data
{
	public class CategoriesRepository
	{
		private NorthwindWebNHibernate.Context _context;
		
		public CategoriesRepository(NorthwindWebNHibernate.Context context)
		{
			_context = context;
		}
		
		public void Create(NorthwindWebNHibernate.Business.Categories v)
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

		public NorthwindWebNHibernate.Business.Categories Read(int CategoryId)
		{
			return _context.NorthwindDbo.Get<NorthwindWebNHibernate.Business.Categories>(CategoryId);
		}

		public void Update(NorthwindWebNHibernate.Business.Categories v)
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

		public void Delete(NorthwindWebNHibernate.Business.Categories v)
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

				public System.Collections.Generic.IEnumerable<NorthwindWebNHibernate.Business.Categories> Search(int categoryId, string categoryName, string description)
				{
					return _context.NorthwindDbo.CreateCriteria<NorthwindWebNHibernate.Business.Categories>()
									.Add(NHibernate.Criterion.Restrictions.Eq("categoryId", categoryId))
												.Add(NHibernate.Criterion.Restrictions.Eq("categoryName", categoryName))
												.Add(NHibernate.Criterion.Restrictions.Eq("description", description))
								
						.List<NorthwindWebNHibernate.Business.Categories>();
				}
				
	}
}
