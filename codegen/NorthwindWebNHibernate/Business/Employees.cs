using System;
using System.Collections.Generic;

namespace NorthwindWebNHibernate.Business
{
	public class Employees
	{
		public int EmployeeID { get; set; }

		public string LastName { get; set; }

		public string FirstName { get; set; }

		public string Title { get; set; }

		public string TitleOfCourtesy { get; set; }

		public DateTime? BirthDate { get; set; }

		public DateTime? HireDate { get; set; }

		public string Address { get; set; }

		public string City { get; set; }

		public string Region { get; set; }

		public string PostalCode { get; set; }

		public string Country { get; set; }

		public string HomePhone { get; set; }

		public string Extension { get; set; }

		public byte[] Photo { get; set; }

		public string Notes { get; set; }

		public string PhotoPath { get; set; }

		public Employees FK_Employees_Employees { get; set; }

		public IList<Employees> FK_Employees_Employees { get; set; }

		public IList<Orders> FK_Orders_Employees { get; set; }

		public override string ToString()
		{
			return string.Format("Employees.EmployeeID={0}", EmployeeID);
		}
	}
}