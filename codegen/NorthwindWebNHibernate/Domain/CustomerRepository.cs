using NHibernate;

namespace NorthwindWebNHibernate.Domain
{
	public class CustomerRepository
	{
		private readonly ISession _session;

		public CustomerRepository(ISession session)
		{
			_session = session;
		}

		public Customer Read(int CustomerID)
		{
			return _session.Get<Customer>(CustomerID);
		}
	}
}