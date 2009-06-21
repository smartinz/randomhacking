using NorthwindWeb.Business;

namespace NorthwindWeb.Data
{
    public class EmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public void Create(Employee v)
        {
            Employee r = _context.NorthwindWebService.CreateEmployee(v);

            v.EmployeeID = r.EmployeeID;
            v.LastName = r.LastName;
            v.FirstName = r.FirstName;
            v.Title = r.Title;
            v.TitleOfCourtesy = r.TitleOfCourtesy;
            v.BirthDate = r.BirthDate;
            v.HireDate = r.HireDate;
            v.Address = r.Address;
            v.City = r.City;
            v.Region = r.Region;
            v.PostalCode = r.PostalCode;
            v.Country = r.Country;
            v.HomePhone = r.HomePhone;
            v.Extension = r.Extension;
            v.Notes = r.Notes;
            v.PhotoPath = r.PhotoPath;
        }

        public Employee Read(int EmployeeID)
        {
            return _context.NorthwindWebService.ReadEmployee(EmployeeID);
        }

        public void Update(Employee v)
        {
            Employee r = _context.NorthwindWebService.UpdateEmployee(v);

            v.EmployeeID = r.EmployeeID;
            v.LastName = r.LastName;
            v.FirstName = r.FirstName;
            v.Title = r.Title;
            v.TitleOfCourtesy = r.TitleOfCourtesy;
            v.BirthDate = r.BirthDate;
            v.HireDate = r.HireDate;
            v.Address = r.Address;
            v.City = r.City;
            v.Region = r.Region;
            v.PostalCode = r.PostalCode;
            v.Country = r.Country;
            v.HomePhone = r.HomePhone;
            v.Extension = r.Extension;
            v.Notes = r.Notes;
            v.PhotoPath = r.PhotoPath;
        }

        public void Delete(Employee v)
        {
            _context.NorthwindWebService.DeleteEmployee(v);
        }

        public Employee[] Search(string lastName, string firstName, string title)
        {
            return _context.NorthwindWebService.SearchEmployee(lastName, firstName, title);
        }
    }
}