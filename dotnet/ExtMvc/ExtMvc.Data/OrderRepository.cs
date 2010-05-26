using System;
using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class OrderRepository
	{
		private readonly ISessionFactory _northwind;


		public OrderRepository(ISessionFactory northwind)
		{
			_northwind = northwind;
		}

		public void Create(Order v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public Order Read(int orderId)
		{
			return _northwind.GetCurrentSession().Load<Order>(orderId);
		}

		public void Update(Order v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(Order v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<Order> Search(int? orderId, DateTime? orderDate, DateTime? requiredDate, DateTime? shippedDate, decimal? freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
		{
			IQueryable<Order> queryable = _northwind.GetCurrentSession().Linq<Order>();
			if(orderId != default(int?))
			{
				queryable = queryable.Where(x => x.OrderId == orderId);
			}
			if(orderDate != default(DateTime?))
			{
				queryable = queryable.Where(x => x.OrderDate == orderDate);
			}
			if(requiredDate != default(DateTime?))
			{
				queryable = queryable.Where(x => x.RequiredDate == requiredDate);
			}
			if(shippedDate != default(DateTime?))
			{
				queryable = queryable.Where(x => x.ShippedDate == shippedDate);
			}
			if(freight != default(decimal?))
			{
				queryable = queryable.Where(x => x.Freight == freight);
			}
			if(shipName != default(string))
			{
				queryable = queryable.Where(x => x.ShipName.StartsWith(shipName));
			}
			if(shipAddress != default(string))
			{
				queryable = queryable.Where(x => x.ShipAddress.StartsWith(shipAddress));
			}
			if(shipCity != default(string))
			{
				queryable = queryable.Where(x => x.ShipCity.StartsWith(shipCity));
			}
			if(shipRegion != default(string))
			{
				queryable = queryable.Where(x => x.ShipRegion.StartsWith(shipRegion));
			}
			if(shipPostalCode != default(string))
			{
				queryable = queryable.Where(x => x.ShipPostalCode.StartsWith(shipPostalCode));
			}
			if(shipCountry != default(string))
			{
				queryable = queryable.Where(x => x.ShipCountry.StartsWith(shipCountry));
			}

			return new Nexida.Infrastructure.QueryablePresentableSet<Order>(queryable);
		}
	}
}