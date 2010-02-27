using System.Linq;
using ExtMvc.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class SupplierRepository
	{
		private readonly ISession _Northwind;


		public SupplierRepository(ISession Northwind)
		{
			_Northwind = Northwind;
		}

		public void Create(Supplier v)
		{
			_Northwind.Save(v);
		}

		public Supplier Read(int supplierId)
		{
			return _Northwind.Load<Supplier>(supplierId);
		}

		public void Update(Supplier v)
		{
			_Northwind.Update(v);
		}

		public void Delete(Supplier v)
		{
			_Northwind.Delete(v);
		}

		public IQueryable<Supplier> SearchNormal(int? supplierId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax, string homePage)
		{
			IQueryable<Supplier> queryable = _Northwind.Linq<Supplier>();
			if (supplierId != default(int?))
			{
				queryable = queryable.Where(x => x.SupplierId == supplierId);
			}
			if (companyName != default(string))
			{
				queryable = queryable.Where(x => x.CompanyName == companyName);
			}
			if (contactName != default(string))
			{
				queryable = queryable.Where(x => x.ContactName == contactName);
			}
			if (contactTitle != default(string))
			{
				queryable = queryable.Where(x => x.ContactTitle == contactTitle);
			}
			if (address != default(string))
			{
				queryable = queryable.Where(x => x.Address == address);
			}
			if (city != default(string))
			{
				queryable = queryable.Where(x => x.City == city);
			}
			if (region != default(string))
			{
				queryable = queryable.Where(x => x.Region == region);
			}
			if (postalCode != default(string))
			{
				queryable = queryable.Where(x => x.PostalCode == postalCode);
			}
			if (country != default(string))
			{
				queryable = queryable.Where(x => x.Country == country);
			}
			if (phone != default(string))
			{
				queryable = queryable.Where(x => x.Phone == phone);
			}
			if (fax != default(string))
			{
				queryable = queryable.Where(x => x.Fax == fax);
			}
			if (homePage != default(string))
			{
				queryable = queryable.Where(x => x.HomePage == homePage);
			}

			return queryable;
		}
	}
}