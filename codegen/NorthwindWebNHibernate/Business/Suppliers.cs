namespace NorthwindWebNHibernate.Business
{
	public class Suppliers
	{

		public int SupplierID { get; set; }

		public string CompanyName { get; set; }

		public string ContactName { get; set; }

		public string ContactTitle { get; set; }

		public string Address { get; set; }

		public string City { get; set; }

		public string Region { get; set; }

		public string PostalCode { get; set; }

		public string Country { get; set; }

		public string Phone { get; set; }

		public string Fax { get; set; }

		public string HomePage { get; set; }

		public System.Collections.Generic.IList<NorthwindWebNHibernate.Business.Products> FK_Products_Suppliers { get; set; }

		public override string ToString()
		{
			return string.Format("Suppliers.SupplierID={0}", this.SupplierID);
		}
	}
}
