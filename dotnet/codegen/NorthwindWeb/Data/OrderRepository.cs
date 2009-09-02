		namespace NorthwindWeb.Data
		{
		public class OrderRepository
		{
		private NorthwindWeb.Context _context;
		public OrderRepository(NorthwindWeb.Context context)
		{
		_context = context;
		}
		
		public void Create(NorthwindWeb.Business.Order v)
		{
		var r = _context.NorthwindWebService.CreateOrder(v);
		
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
	
		public NorthwindWeb.Business.Order Read(int OrderID)
		{
		return _context.NorthwindWebService.ReadOrder(OrderID);
		}
	
		public void Update(NorthwindWeb.Business.Order v)
		{
		var r = _context.NorthwindWebService.UpdateOrder(v);
		
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
	
		public void Delete(NorthwindWeb.Business.Order v)
		{
		_context.NorthwindWebService.DeleteOrder(v);
		}
	
		public NorthwindWeb.Business.Order[] Search(NorthwindWeb.Business.Employee employee, System.DateTime dateFrom, System.DateTime dateTo)
		{
		return _context.NorthwindWebService.SearchOrder(employee, dateFrom, dateTo);
		}
	
		}
		}
