using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class SupplierRepository
	{
		private readonly ISessionFactory _northwind;


		public SupplierRepository(ISessionFactory northwind)
		{
			_northwind = northwind;
		}

		public void Create(Supplier v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public Supplier Read(int supplierId)
		{
			return _northwind.GetCurrentSession().Load<Supplier>(supplierId);
		}

		public void Update(Supplier v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(Supplier v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<Supplier> Search(int? supplierId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax, string homePage)
		{
			IQueryable<Supplier> queryable = _northwind.GetCurrentSession().Linq<Supplier>();
			if(supplierId != default(int?))
			{
				queryable = queryable.Where(x => x.SupplierId == supplierId);
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
			if(homePage != default(string))
			{
				queryable = queryable.Where(x => x.HomePage.StartsWith(homePage));
			}

			return new Nexida.Infrastructure.QueryablePresentableSet<Supplier>(queryable);
		}
	}
}