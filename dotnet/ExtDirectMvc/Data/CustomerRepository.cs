using System.Linq;
using ExtMvc.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class CustomerRepository
	{
		private readonly ISession _Northwind;


		public CustomerRepository(ISession Northwind)
		{
			_Northwind = Northwind;
		}

		public void Create(Customer v)
		{
			_Northwind.Save(v);
		}

		public Customer Read(string customerId)
		{
			return _Northwind.Load<Customer>(customerId);
		}

		public void Update(Customer v)
		{
			_Northwind.Update(v);
		}

		public void Delete(Customer v)
		{
			_Northwind.Delete(v);
		}

		public IQueryable<Customer> SearchNormal(string contactName)
		{
			IQueryable<Customer> queryable = _Northwind.Linq<Customer>();
			if (contactName != default(string))
			{
				queryable = queryable.Where(x => x.ContactName.Contains(contactName));
			}

			return queryable;
		}
	}
}