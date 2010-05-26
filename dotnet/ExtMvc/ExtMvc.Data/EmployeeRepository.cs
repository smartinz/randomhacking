using System;
using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class EmployeeRepository
	{
		private readonly ISessionFactory _northwind;


		public EmployeeRepository(ISessionFactory northwind)
		{
			_northwind = northwind;
		}

		public void Create(Employee v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public Employee Read(int employeeId)
		{
			return _northwind.GetCurrentSession().Load<Employee>(employeeId);
		}

		public void Update(Employee v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(Employee v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<Employee> Search(int? employeeId, string lastName, string firstName, string title, string titleOfCourtesy, DateTime? birthDate, DateTime? hireDate, string address, string city, string region, string postalCode, string country, string homePhone, string extension, string notes, string photoPath)
		{
			IQueryable<Employee> queryable = _northwind.GetCurrentSession().Linq<Employee>();
			if(employeeId != default(int?))
			{
				queryable = queryable.Where(x => x.EmployeeId == employeeId);
			}
			if(lastName != default(string))
			{
				queryable = queryable.Where(x => x.LastName.StartsWith(lastName));
			}
			if(firstName != default(string))
			{
				queryable = queryable.Where(x => x.FirstName.StartsWith(firstName));
			}
			if(title != default(string))
			{
				queryable = queryable.Where(x => x.Title.StartsWith(title));
			}
			if(titleOfCourtesy != default(string))
			{
				queryable = queryable.Where(x => x.TitleOfCourtesy.StartsWith(titleOfCourtesy));
			}
			if(birthDate != default(DateTime?))
			{
				queryable = queryable.Where(x => x.BirthDate == birthDate);
			}
			if(hireDate != default(DateTime?))
			{
				queryable = queryable.Where(x => x.HireDate == hireDate);
			}
			if(address != default(string))
			{
				queryable = queryable.Where(x => x.Address.StartsWith(address));
			}
			if(city != default(string))
			{
				queryable = queryable.Where(x => x.City.StartsWith(city));
			}
			if(region != default(string))
			{
				queryable = queryable.Where(x => x.Region.StartsWith(region));
			}
			if(postalCode != default(string))
			{
				queryable = queryable.Where(x => x.PostalCode.StartsWith(postalCode));
			}
			if(country != default(string))
			{
				queryable = queryable.Where(x => x.Country.StartsWith(country));
			}
			if(homePhone != default(string))
			{
				queryable = queryable.Where(x => x.HomePhone.StartsWith(homePhone));
			}
			if(extension != default(string))
			{
				queryable = queryable.Where(x => x.Extension.StartsWith(extension));
			}
			if(notes != default(string))
			{
				queryable = queryable.Where(x => x.Notes.StartsWith(notes));
			}
			if(photoPath != default(string))
			{
				queryable = queryable.Where(x => x.PhotoPath.StartsWith(photoPath));
			}

			return new Nexida.Infrastructure.QueryablePresentableSet<Employee>(queryable);
		}
	}
}