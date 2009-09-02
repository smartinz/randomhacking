namespace NorthwindWebNHibernate.Business
{
	public class Suppliers
	{

		public int SupplierId { get; set; }

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

		public System.Collections.Generic.IList<NorthwindWebNHibernate.Business.Products> FkProductsSuppliersCollection { get; set; }

		public override string ToString()
		{
			return string.Format("Suppliers.SupplierId={0}", this.SupplierId);
		}
	}
}
