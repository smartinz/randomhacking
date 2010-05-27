using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class CustomerRepository
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

		public IPresentableSet<Customer> Search(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
		{
			IQueryable<Customer> queryable = _northwind.GetCurrentSession().Linq<Customer>();
			if(customerId != default(string))
			{
				queryable = queryable.Where(x => x.CustomerId.StartsWith(customerId));
			}
			if(companyName != default(string))
			{
				queryable = queryable.Where(x => x.CompanyName.StartsWith(companyName));
			}
			if(contactName != default(string))
			{
				queryable = queryable.Where(x => x.ContactName.StartsWith(contactName));
			}
			if(contactTitle != default(string))
			{
				queryable = queryable.Where(x => x.ContactTitle.StartsWith(contactTitle));
			}
			if(address != default(string))
			{
				queryable = queryable.Where(x => x.Address.StartsWith(address));
			}
			if(city != default(string))
			{
				queryable = queryable.Where(x => x.City.StartsWith(city));
			}
			if(region != default(string))
			{
				queryable = queryable.Where(x => x.Region.StartsWith(region));
			}
			if(postalCode != default(string))
			{
				queryable = queryable.Where(x => x.PostalCode.StartsWith(postalCode));
			}
			if(country != default(string))
			{
				queryable = queryable.Where(x => x.Country.StartsWith(country));
			}
			if(phone != default(string))
			{
				queryable = queryable.Where(x => x.Phone.StartsWith(phone));
			}
			if(fax != default(string))
			{
				queryable = queryable.Where(x => x.Fax.StartsWith(fax));
			}

			return new QueryablePresentableSet<Customer>(queryable);
		}
	}
}