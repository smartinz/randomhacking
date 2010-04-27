using System.Linq;
using ExtMvc.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class ShipperRepository
	{
		private readonly ISession _Northwind;


		public ShipperRepository(ISession Northwind)
		{
			_Northwind = Northwind;
		}

		public void Create(Shipper v)
		{
			_Northwind.Save(v);
		}

		public Shipper Read(int shipperId)
		{
			return _Northwind.Load<Shipper>(shipperId);
		}

		public void Update(Shipper v)
		{
			_Northwind.Update(v);
		}

		public void Delete(Shipper v)
		{
			_Northwind.Delete(v);
		}

		public IQueryable<Shipper> SearchNormal(int? shipperId, string companyName, string phone)
		{
			IQueryable<Shipper> queryable = _Northwind.Linq<Shipper>();
			if (shipperId != default(int?))
			{
				queryable = queryable.Where(x => x.ShipperId == shipperId);
			}
			if (companyName != default(string))
			{
				queryable = queryable.Where(x => x.CompanyName == companyName);
			}
			if (phone != default(string))
			{
				queryable = queryable.Where(x => x.Phone == phone);
			}

			return queryable;
		}
	}
}