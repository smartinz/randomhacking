namespace NorthwindWebNHibernate.Data
{
	public class CustomersRepository
	{
		private NorthwindWebNHibernate.Context _context;
		
		public CustomersRepository(NorthwindWebNHibernate.Context context)
		{
			_context = context;
		}
		
		public void Create(NorthwindWebNHibernate.Business.Customers v)
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

		public NorthwindWebNHibernate.Business.Customers Read(string CustomerId)
		{
			return _context.NorthwindDbo.Get<NorthwindWebNHibernate.Business.Customers>(CustomerId);
		}

		public void Update(NorthwindWebNHibernate.Business.Customers v)
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

		public void Delete(NorthwindWebNHibernate.Business.Customers v)
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

				public System.Collections.Generic.IEnumerable<NorthwindWebNHibernate.Business.Customers> Search(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
				{
					return _context.NorthwindDbo.CreateCriteria<NorthwindWebNHibernate.Business.Customers>()
									.Add(NHibernate.Criterion.Restrictions.Eq("customerId", customerId))
												.Add(NHibernate.Criterion.Restrictions.Eq("companyName", companyName))
												.Add(NHibernate.Criterion.Restrictions.Eq("contactName", contactName))
												.Add(NHibernate.Criterion.Restrictions.Eq("contactTitle", contactTitle))
												.Add(NHibernate.Criterion.Restrictions.Eq("address", address))
												.Add(NHibernate.Criterion.Restrictions.Eq("city", city))
												.Add(NHibernate.Criterion.Restrictions.Eq("region", region))
												.Add(NHibernate.Criterion.Restrictions.Eq("postalCode", postalCode))
												.Add(NHibernate.Criterion.Restrictions.Eq("country", country))
												.Add(NHibernate.Criterion.Restrictions.Eq("phone", phone))
												.Add(NHibernate.Criterion.Restrictions.Eq("fax", fax))
								
						.List<NorthwindWebNHibernate.Business.Customers>();
				}
				
	}
}
