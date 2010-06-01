using System;
using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class OrderRepository : IRepository
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

		public IPresentableSet<Order> SearchNormal(int? orderId, DateTime? orderDate, DateTime? requiredDate, DateTime? shippedDate, decimal? freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry, Customer customer, Employee employee, Shipper shipper)
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
			if(!string.IsNullOrEmpty(shipName))
			{
				queryable = queryable.Where(x => x.ShipName == shipName);
			}
			if(!string.IsNullOrEmpty(shipAddress))
			{
				queryable = queryable.Where(x => x.ShipAddress == shipAddress);
			}
			if(!string.IsNullOrEmpty(shipCity))
			{
				queryable = queryable.Where(x => x.ShipCity == shipCity);
			}
			if(!string.IsNullOrEmpty(shipRegion))
			{
				queryable = queryable.Where(x => x.ShipRegion == shipRegion);
			}
			if(!string.IsNullOrEmpty(shipPostalCode))
			{
				queryable = queryable.Where(x => x.ShipPostalCode == shipPostalCode);
			}
			if(!string.IsNullOrEmpty(shipCountry))
			{
				queryable = queryable.Where(x => x.ShipCountry == shipCountry);
			}
			if(customer != default(Customer))
			{
				queryable = queryable.Where(x => x.Customer == customer);
			}
			if(employee != default(Employee))
			{
				queryable = queryable.Where(x => x.Employee == employee);
			}
			if(shipper != default(Shipper))
			{
				queryable = queryable.Where(x => x.Shipper == shipper);
			}

			return new QueryablePresentableSet<Order>(queryable);
		}
	}
}