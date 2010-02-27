using System;
using System.Linq;
using ExtMvc.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class OrderRepository
	{
		private readonly ISession _Northwind;


		public OrderRepository(ISession Northwind)
		{
			_Northwind = Northwind;
		}

		public void Create(Order v)
		{
			_Northwind.Save(v);
		}

		public Order Read(int orderId)
		{
			return _Northwind.Load<Order>(orderId);
		}

		public void Update(Order v)
		{
			_Northwind.Update(v);
		}

		public void Delete(Order v)
		{
			_Northwind.Delete(v);
		}

		public IQueryable<Order> SearchNormal(int? orderId, DateTime? orderDate, DateTime? requiredDate, DateTime? shippedDate, decimal? freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry, Customer customer, Employee employee, Shipper shipper)
		{
			IQueryable<Order> queryable = _Northwind.Linq<Order>();
			if (orderId != default(int?))
			{
				queryable = queryable.Where(x => x.OrderId == orderId);
			}
			if (orderDate != default(DateTime?))
			{
				queryable = queryable.Where(x => x.OrderDate == orderDate);
			}
			if (requiredDate != default(DateTime?))
			{
				queryable = queryable.Where(x => x.RequiredDate == requiredDate);
			}
			if (shippedDate != default(DateTime?))
			{
				queryable = queryable.Where(x => x.ShippedDate == shippedDate);
			}
			if (freight != default(decimal?))
			{
				queryable = queryable.Where(x => x.Freight == freight);
			}
			if (shipName != default(string))
			{
				queryable = queryable.Where(x => x.ShipName == shipName);
			}
			if (shipAddress != default(string))
			{
				queryable = queryable.Where(x => x.ShipAddress == shipAddress);
			}
			if (shipCity != default(string))
			{
				queryable = queryable.Where(x => x.ShipCity == shipCity);
			}
			if (shipRegion != default(string))
			{
				queryable = queryable.Where(x => x.ShipRegion == shipRegion);
			}
			if (shipPostalCode != default(string))
			{
				queryable = queryable.Where(x => x.ShipPostalCode == shipPostalCode);
			}
			if (shipCountry != default(string))
			{
				queryable = queryable.Where(x => x.ShipCountry == shipCountry);
			}
			if (customer != default(Customer))
			{
				queryable = queryable.Where(x => x.Customer == customer);
			}
			if (employee != default(Employee))
			{
				queryable = queryable.Where(x => x.Employee == employee);
			}
			if (shipper != default(Shipper))
			{
				queryable = queryable.Where(x => x.Shipper == shipper);
			}

			return queryable;
		}
	}
}