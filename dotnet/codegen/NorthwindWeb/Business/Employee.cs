		namespace NorthwindWeb.Business
		{
		[System.Serializable]
		[System.Xml.Serialization.XmlType(Namespace = "http://www.northwind.com")]
		public class Employee
		{
		
		public int EmployeeID { get; set; }
	
		public string LastName { get; set; }
	
		public string FirstName { get; set; }
	
		public string Title { get; set; }
	
		public string TitleOfCourtesy { get; set; }
	
		public System.DateTime? BirthDate { get; set; }
	
		public System.DateTime? HireDate { get; set; }
	
		public string Address { get; set; }
	
		public string City { get; set; }
	
		public string Region { get; set; }
	
		public string PostalCode { get; set; }
	
		public string Country { get; set; }
	
		public string HomePhone { get; set; }
	
		public string Extension { get; set; }
	
		public string Notes { get; set; }
	
		public string PhotoPath { get; set; }
	
		public override string ToString()
		{
		return string.Format("Employee.EmployeeID={0}", this.EmployeeID);
		}
		
		}
		}
