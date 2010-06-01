using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class SupplierRepository : IRepository
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

		public IPresentableSet<Supplier> SearchNormal(int? supplierId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax, string homePage)
		{
			IQueryable<Supplier> queryable = _northwind.GetCurrentSession().Linq<Supplier>();
			if(supplierId != default(int?))
			{
				queryable = queryable.Where(x => x.SupplierId == supplierId);
			}
			if(!string.IsNullOrEmpty(companyName))
			{
				queryable = queryable.Where(x => x.CompanyName == companyName);
			}
			if(!string.IsNullOrEmpty(contactName))
			{
				queryable = queryable.Where(x => x.ContactName == contactName);
			}
			if(!string.IsNullOrEmpty(contactTitle))
			{
				queryable = queryable.Where(x => x.ContactTitle == contactTitle);
			}
			if(!string.IsNullOrEmpty(address))
			{
				queryable = queryable.Where(x => x.Address == address);
			}
			if(!string.IsNullOrEmpty(city))
			{
				queryable = queryable.Where(x => x.City == city);
			}
			if(!string.IsNullOrEmpty(region))
			{
				queryable = queryable.Where(x => x.Region == region);
			}
			if(!string.IsNullOrEmpty(postalCode))
			{
				queryable = queryable.Where(x => x.PostalCode == postalCode);
			}
			if(!string.IsNullOrEmpty(country))
			{
				queryable = queryable.Where(x => x.Country == country);
			}
			if(!string.IsNullOrEmpty(phone))
			{
				queryable = queryable.Where(x => x.Phone == phone);
			}
			if(!string.IsNullOrEmpty(fax))
			{
				queryable = queryable.Where(x => x.Fax == fax);
			}
			if(!string.IsNullOrEmpty(homePage))
			{
				queryable = queryable.Where(x => x.HomePage == homePage);
			}

			return new QueryablePresentableSet<Supplier>(queryable);
		}
	}
}