namespace NorthwindWebNHibernate.Data
{
	public class OrdersRepository
	{
		private NorthwindWebNHibernate.Context _context;
		
		public OrdersRepository(NorthwindWebNHibernate.Context context)
		{
			_context = context;
		}
		
		public void Create(NorthwindWebNHibernate.Business.Orders v)
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

		public NorthwindWebNHibernate.Business.Orders Read(int OrderId)
		{
			return _context.NorthwindDbo.Get<NorthwindWebNHibernate.Business.Orders>(OrderId);
		}

		public void Update(NorthwindWebNHibernate.Business.Orders v)
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

		public void Delete(NorthwindWebNHibernate.Business.Orders v)
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

				public System.Collections.Generic.IEnumerable<NorthwindWebNHibernate.Business.Orders> Search(int orderId, System.DateTime? orderDate, System.DateTime? requiredDate, System.DateTime? shippedDate, decimal freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry, NorthwindWebNHibernate.Business.Customers fkOrdersCustomers, NorthwindWebNHibernate.Business.Employees fkOrdersEmployees, NorthwindWebNHibernate.Business.Shippers fkOrdersShippers)
				{
					return _context.NorthwindDbo.CreateCriteria<NorthwindWebNHibernate.Business.Orders>()
									.Add(NHibernate.Criterion.Restrictions.Eq("orderId", orderId))
												.Add(NHibernate.Criterion.Restrictions.Eq("orderDate", orderDate))
												.Add(NHibernate.Criterion.Restrictions.Eq("requiredDate", requiredDate))
												.Add(NHibernate.Criterion.Restrictions.Eq("shippedDate", shippedDate))
												.Add(NHibernate.Criterion.Restrictions.Eq("freight", freight))
												.Add(NHibernate.Criterion.Restrictions.Eq("shipName", shipName))
												.Add(NHibernate.Criterion.Restrictions.Eq("shipAddress", shipAddress))
												.Add(NHibernate.Criterion.Restrictions.Eq("shipCity", shipCity))
												.Add(NHibernate.Criterion.Restrictions.Eq("shipRegion", shipRegion))
												.Add(NHibernate.Criterion.Restrictions.Eq("shipPostalCode", shipPostalCode))
												.Add(NHibernate.Criterion.Restrictions.Eq("shipCountry", shipCountry))
												.Add(NHibernate.Criterion.Restrictions.Eq("fkOrdersCustomers", fkOrdersCustomers))
												.Add(NHibernate.Criterion.Restrictions.Eq("fkOrdersEmployees", fkOrdersEmployees))
												.Add(NHibernate.Criterion.Restrictions.Eq("fkOrdersShippers", fkOrdersShippers))
								
						.List<NorthwindWebNHibernate.Business.Orders>();
				}
				
	}
}
