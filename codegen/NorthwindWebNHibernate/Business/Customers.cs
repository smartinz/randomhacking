namespace NorthwindWebNHibernate.Business
{
	public class Customers
	{

		public string CustomerId { get; set; }

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

		public System.Collections.Generic.IList<NorthwindWebNHibernate.Business.CustomerDemographics> FkCustomerCustomerDemoCustomersCollection { get; set; }

		public System.Collections.Generic.IList<NorthwindWebNHibernate.Business.Orders> FkOrdersCustomersCollection { get; set; }

		public override string ToString()
		{
			return string.Format("Customers.CustomerId={0}", this.CustomerId);
		}
	}
}
