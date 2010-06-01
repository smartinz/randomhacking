using System;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;

namespace ExtMvc.Domain
{
	public class Employee
	{
		private string _lastName;

		private string _firstName;

		private ICollection<Employee> _employees = new HashSet<Employee>();

		private ICollection<Territory> _territories = new HashSet<Territory>();

		private ICollection<Order> _orders = new HashSet<Order>();


		public virtual int EmployeeId { get; set; }

		[NotNullNotEmpty]
		public virtual string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}

		[NotNullNotEmpty]
		public virtual string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}

		public virtual string Title { get; set; }

		public virtual string TitleOfCourtesy { get; set; }

		public virtual DateTime? BirthDate { get; set; }

		public virtual DateTime? HireDate { get; set; }

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

		public virtual Employee RelatedEmployee { get; set; }

		[NotNull]
		public virtual ICollection<Employee> Employees
		{
			get { return _employees; }
			private set { _employees = value; }
		}

		[NotNull]
		public virtual ICollection<Territory> Territories
		{
			get { return _territories; }
			private set { _territories = value; }
		}

		[NotNull]
		public virtual ICollection<Order> Orders
		{
			get { return _orders; }
			private set { _orders = value; }
		}

		public override string ToString()
		{
			return (_firstName == null ? "" : _firstName) + " " + (_lastName == null ? "" : _lastName);
		}


		public virtual bool Equals(Employee other)
		{
			if(ReferenceEquals(null, other))
			{
				return false;
			}
			if(ReferenceEquals(this, other))
			{
				return true;
			}
			if(EmployeeId != default(int))
			{
				return other.EmployeeId == EmployeeId;
			}
			return other.EmployeeId == EmployeeId && other.LastName == LastName && other.FirstName == FirstName && other.Title == Title && other.TitleOfCourtesy == TitleOfCourtesy && other.BirthDate == BirthDate && other.HireDate == HireDate && other.Address == Address && other.City == City && other.Region == Region && other.PostalCode == PostalCode && other.Country == Country && other.HomePhone == HomePhone && other.Extension == Extension && other.Photo == Photo && other.Notes == Notes && other.PhotoPath == PhotoPath && other.RelatedEmployee == RelatedEmployee && 1 == 1 && 1 == 1 && 1 == 1;
		}

		public override bool Equals(object obj)
		{
			if(ReferenceEquals(null, obj))
			{
				return false;
			}
			if(ReferenceEquals(this, obj))
			{
				return true;
			}
			if(obj.GetType() != typeof(Employee))
			{
				return false;
			}
			return Equals((Employee)obj);
		}

		public static bool operator ==(Employee left, Employee right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Employee left, Employee right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if(EmployeeId != default(int))
				{
					result = (result*397) ^ EmployeeId.GetHashCode();
				}
				else
				{
					result = (result*397) ^ ((EmployeeId != default(int)) ? EmployeeId.GetHashCode() : 0);
					result = (result*397) ^ ((LastName != default(string)) ? LastName.GetHashCode() : 0);
					result = (result*397) ^ ((FirstName != default(string)) ? FirstName.GetHashCode() : 0);
					result = (result*397) ^ ((Title != default(string)) ? Title.GetHashCode() : 0);
					result = (result*397) ^ ((TitleOfCourtesy != default(string)) ? TitleOfCourtesy.GetHashCode() : 0);
					result = (result*397) ^ ((BirthDate != default(DateTime?)) ? BirthDate.GetHashCode() : 0);
					result = (result*397) ^ ((HireDate != default(DateTime?)) ? HireDate.GetHashCode() : 0);
					result = (result*397) ^ ((Address != default(string)) ? Address.GetHashCode() : 0);
					result = (result*397) ^ ((City != default(string)) ? City.GetHashCode() : 0);
					result = (result*397) ^ ((Region != default(string)) ? Region.GetHashCode() : 0);
					result = (result*397) ^ ((PostalCode != default(string)) ? PostalCode.GetHashCode() : 0);
					result = (result*397) ^ ((Country != default(string)) ? Country.GetHashCode() : 0);
					result = (result*397) ^ ((HomePhone != default(string)) ? HomePhone.GetHashCode() : 0);
					result = (result*397) ^ ((Extension != default(string)) ? Extension.GetHashCode() : 0);
					result = (result*397) ^ ((Photo != default(byte[])) ? Photo.GetHashCode() : 0);
					result = (result*397) ^ ((Notes != default(string)) ? Notes.GetHashCode() : 0);
					result = (result*397) ^ ((PhotoPath != default(string)) ? PhotoPath.GetHashCode() : 0);
					result = (result*397) ^ ((RelatedEmployee != default(Employee)) ? RelatedEmployee.GetHashCode() : 0);
				}
				return result;
			}
		}
	}
}