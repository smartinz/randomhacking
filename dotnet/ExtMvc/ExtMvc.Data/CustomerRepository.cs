using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class CustomerRepository : IRepository
	{
		private readonly ISessionFactory _northwind;


		public CustomerRepository(ISessionFactory northwind)
		{
			_northwind = northwind;
		}

		public void Create(Customer v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public Customer Read(string customerId)
		{
			return _northwind.GetCurrentSession().Load<Customer>(customerId);
		}

		public void Update(Customer v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(Customer v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<Customer> SearchNormal(string contactName)
		{
			IQueryable<Customer> queryable = _northwind.GetCurrentSession().Linq<Customer>();
			if(!string.IsNullOrEmpty(contactName))
			{
				queryable = queryable.Where(x => x.ContactName.Contains(contactName));
			}

			return new QueryablePresentableSet<Customer>(queryable);
		}
	}
}