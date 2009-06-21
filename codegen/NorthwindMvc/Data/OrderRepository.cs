using System;
using NorthwindWeb.Business;

namespace NorthwindWeb.Data
{
    public class OrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public void Create(Order v)
        {
            Order r = _context.NorthwindWebService.CreateOrder(v);

            v.OrderID = r.OrderID;
            v.OrderDate = r.OrderDate;
            v.RequiredDate = r.RequiredDate;
            v.ShippedDate = r.ShippedDate;
            v.Freight = r.Freight;
            v.ShipName = r.ShipName;
            v.ShipAddress = r.ShipAddress;
            v.ShipCity = r.ShipCity;
            v.ShipRegion = r.ShipRegion;
            v.ShipPostalCode = r.ShipPostalCode;
            v.ShipCountry = r.ShipCountry;
            v.OrderDetails = r.OrderDetails;
            v.Customer = r.Customer;
            v.Employee = r.Employee;
            v.Shipper = r.Shipper;
        }

        public Order Read(int OrderID)
        {
            return _context.NorthwindWebService.ReadOrder(OrderID);
        }

        public void Update(Order v)
        {
            Order r = _context.NorthwindWebService.UpdateOrder(v);

            v.OrderID = r.OrderID;
            v.OrderDate = r.OrderDate;
            v.RequiredDate = r.RequiredDate;
            v.ShippedDate = r.ShippedDate;
            v.Freight = r.Freight;
            v.ShipName = r.ShipName;
            v.ShipAddress = r.ShipAddress;
            v.ShipCity = r.ShipCity;
            v.ShipRegion = r.ShipRegion;
            v.ShipPostalCode = r.ShipPostalCode;
            v.ShipCountry = r.ShipCountry;
            v.OrderDetails = r.OrderDetails;
            v.Customer = r.Customer;
            v.Employee = r.Employee;
            v.Shipper = r.Shipper;
        }

        public void Delete(Order v)
        {
            _context.NorthwindWebService.DeleteOrder(v);
        }

        public Order[] Search(Employee employee, DateTime dateFrom, DateTime dateTo)
        {
            return _context.NorthwindWebService.SearchOrder(employee, dateFrom, dateTo);
        }
    }
}