using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class ShipperRepository : IRepository
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

		public IPresentableSet<Shipper> SearchNormal(int? shipperId, string companyName, string phone)
		{
			IQueryable<Shipper> queryable = _northwind.GetCurrentSession().Linq<Shipper>();
			if(shipperId != default(int?))
			{
				queryable = queryable.Where(x => x.ShipperId == shipperId);
			}
			if(!string.IsNullOrEmpty(companyName))
			{
				queryable = queryable.Where(x => x.CompanyName == companyName);
			}
			if(!string.IsNullOrEmpty(phone))
			{
				queryable = queryable.Where(x => x.Phone == phone);
			}

			return new QueryablePresentableSet<Shipper>(queryable);
		}
	}
}