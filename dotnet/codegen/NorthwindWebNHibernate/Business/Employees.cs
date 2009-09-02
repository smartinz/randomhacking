namespace NorthwindWebNHibernate.Business
{
	public class Employees
	{

		public virtual int EmployeeId { get; set; }

		public virtual string LastName { get; set; }

		public virtual string FirstName { get; set; }

		public virtual string Title { get; set; }

		public virtual string TitleOfCourtesy { get; set; }

		public virtual System.DateTime? BirthDate { get; set; }

		public virtual System.DateTime? HireDate { get; set; }

		public virtual string Address { get; set; }

		public virtual string City { get; set; }

		public virtual string Region { get; set; }

		public virtual string PostalCode { get; set; }

		public virtual string Country { get; set; }

		public virtual string HomePhone { get; set; }

		public virtual string Extension { get; set; }

		public virtual byte[] Photo { get; set; }

		public virtual string Notes { get; set; }

		public virtual string PhotoPath { get; set; }

		public virtual NorthwindWebNHibernate.Business.Employees FkEmployeesEmployees { get; set; }

		public virtual Iesi.Collections.Generic.ISet<NorthwindWebNHibernate.Business.Employees> FkEmployeesEmployeesCollection { get; set; }

		public virtual Iesi.Collections.Generic.ISet<NorthwindWebNHibernate.Business.Territories> FkEmployeeTerritoriesEmployeesCollection { get; set; }

		public virtual Iesi.Collections.Generic.ISet<NorthwindWebNHibernate.Business.Orders> FkOrdersEmployeesCollection { get; set; }

		public override string ToString()
		{
			return string.Format("Employees.EmployeeId={0}", this.EmployeeId);
		}
	}
}
