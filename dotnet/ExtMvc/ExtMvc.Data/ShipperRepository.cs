using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class ShipperRepository
	{
		private readonly ISessionFactory _northwind;


		public ShipperRepository(ISessionFactory northwind)
		{
			_northwind = northwind;
		}

		public void Create(Shipper v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public Shipper Read(int shipperId)
		{
			return _northwind.GetCurrentSession().Load<Shipper>(shipperId);
		}

		public void Update(Shipper v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(Shipper v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<Shipper> Search(int? shipperId, string companyName, string phone)
		{
			IQueryable<Shipper> queryable = _northwind.GetCurrentSession().Linq<Shipper>();
			if(shipperId != default(int?))
			{
				queryable = queryable.Where(x => x.ShipperId == shipperId);
			}
			if(companyName != default(string))
			{
				queryable = queryable.Where(x => x.CompanyName.StartsWith(companyName));
			}
			if(phone != default(string))
			{
				queryable = queryable.Where(x => x.Phone.StartsWith(phone));
			}

			return new Nexida.Infrastructure.QueryablePresentableSet<Shipper>(queryable);
		}
	}
}