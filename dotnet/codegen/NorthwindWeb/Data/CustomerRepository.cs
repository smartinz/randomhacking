		namespace NorthwindWeb.Data
		{
		public class CustomerRepository
		{
		private NorthwindWeb.Context _context;
		public CustomerRepository(NorthwindWeb.Context context)
		{
		_context = context;
		}
		
		public void Create(NorthwindWeb.Business.Customer v)
		{
		var r = _context.NorthwindWebService.CreateCustomer(v);
		
			v.CustomerID = r.CustomerID;
			v.CompanyName = r.CompanyName;
			v.ContactName = r.ContactName;
			v.ContactTitle = r.ContactTitle;
			v.Address = r.Address;
			v.City = r.City;
			v.Region = r.Region;
			v.PostalCode = r.PostalCode;
			v.Country = r.Country;
			v.Phone = r.Phone;
			v.Fax = r.Fax;
		}
	
		public NorthwindWeb.Business.Customer Read(string CustomerID)
		{
		return _context.NorthwindWebService.ReadCustomer(CustomerID);
		}
	
		public void Update(NorthwindWeb.Business.Customer v)
		{
		var r = _context.NorthwindWebService.UpdateCustomer(v);
		
			v.CustomerID = r.CustomerID;
			v.CompanyName = r.CompanyName;
			v.ContactName = r.ContactName;
			v.ContactTitle = r.ContactTitle;
			v.Address = r.Address;
			v.City = r.City;
			v.Region = r.Region;
			v.PostalCode = r.PostalCode;
			v.Country = r.Country;
			v.Phone = r.Phone;
			v.Fax = r.Fax;
		}
	
		public void Delete(NorthwindWeb.Business.Customer v)
		{
		_context.NorthwindWebService.DeleteCustomer(v);
		}
	
		public NorthwindWeb.Business.Customer[] Search(string companyName, string contactName, string contactTitle)
		{
		return _context.NorthwindWebService.SearchCustomer(companyName, contactName, contactTitle);
		}
	
		}
		}
