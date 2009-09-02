using NorthwindWeb.Business;

namespace NorthwindWeb.Data
{
    public class CustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public void Create(Customer v)
        {
            Customer r = _context.NorthwindWebService.CreateCustomer(v);

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

        public Customer Read(string CustomerID)
        {
            return _context.NorthwindWebService.ReadCustomer(CustomerID);
        }

        public void Update(Customer v)
        {
            Customer r = _context.NorthwindWebService.UpdateCustomer(v);

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

        public void Delete(Customer v)
        {
            _context.NorthwindWebService.DeleteCustomer(v);
        }

        public Customer[] Search(string companyName, string contactName, string contactTitle)
        {
            return _context.NorthwindWebService.SearchCustomer(companyName, contactName, contactTitle);
        }
    }
}