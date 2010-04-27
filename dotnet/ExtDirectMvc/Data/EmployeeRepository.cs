using System;
using System.Linq;
using ExtMvc.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class EmployeeRepository
	{
		private readonly ISession _Northwind;


		public EmployeeRepository(ISession Northwind)
		{
			_Northwind = Northwind;
		}

		public void Create(Employee v)
		{
			_Northwind.Save(v);
		}

		public Employee Read(int employeeId)
		{
			return _Northwind.Load<Employee>(employeeId);
		}

		public void Update(Employee v)
		{
			_Northwind.Update(v);
		}

		public void Delete(Employee v)
		{
			_Northwind.Delete(v);
		}

		public IQueryable<Employee> SearchNormal(int? employeeId, string lastName, string firstName, string title, string titleOfCourtesy, DateTime? birthDate, DateTime? hireDate, string address, string city, string region, string postalCode, string country, string homePhone, string extension, string notes, string photoPath)
		{
			IQueryable<Employee> queryable = _Northwind.Linq<Employee>();
			if (employeeId != default(int?))
			{
				queryable = queryable.Where(x => x.EmployeeId == employeeId);
			}
			if (lastName != default(string))
			{
				queryable = queryable.Where(x => x.LastName == lastName);
			}
			if (firstName != default(string))
			{
				queryable = queryable.Where(x => x.FirstName == firstName);
			}
			if (title != default(string))
			{
				queryable = queryable.Where(x => x.Title == title);
			}
			if (titleOfCourtesy != default(string))
			{
				queryable = queryable.Where(x => x.TitleOfCourtesy == titleOfCourtesy);
			}
			if (birthDate != default(DateTime?))
			{
				queryable = queryable.Where(x => x.BirthDate == birthDate);
			}
			if (hireDate != default(DateTime?))
			{
				queryable = queryable.Where(x => x.HireDate == hireDate);
			}
			if (address != default(string))
			{
				queryable = queryable.Where(x => x.Address == address);
			}
			if (city != default(string))
			{
				queryable = queryable.Where(x => x.City == city);
			}
			if (region != default(string))
			{
				queryable = queryable.Where(x => x.Region == region);
			}
			if (postalCode != default(string))
			{
				queryable = queryable.Where(x => x.PostalCode == postalCode);
			}
			if (country != default(string))
			{
				queryable = queryable.Where(x => x.Country == country);
			}
			if (homePhone != default(string))
			{
				queryable = queryable.Where(x => x.HomePhone == homePhone);
			}
			if (extension != default(string))
			{
				queryable = queryable.Where(x => x.Extension == extension);
			}
			if (notes != default(string))
			{
				queryable = queryable.Where(x => x.Notes == notes);
			}
			if (photoPath != default(string))
			{
				queryable = queryable.Where(x => x.PhotoPath == photoPath);
			}

			return queryable;
		}
	}
}