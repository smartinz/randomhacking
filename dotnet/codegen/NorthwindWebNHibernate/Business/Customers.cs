namespace NorthwindWebNHibernate.Business
{
	public class Customers
	{

		public virtual string CustomerId { get; set; }

		public virtual string CompanyName { get; set; }

		public virtual string ContactName { get; set; }

		public virtual string ContactTitle { get; set; }

		public virtual string Address { get; set; }

		public virtual string City { get; set; }

		public virtual string Region { get; set; }

		public virtual string PostalCode { get; set; }

		public virtual string Country { get; set; }

		public virtual string Phone { get; set; }

		public virtual string Fax { get; set; }

		public virtual Iesi.Collections.Generic.ISet<NorthwindWebNHibernate.Business.CustomerDemographics> FkCustomerCustomerDemoCustomersCollection { get; set; }

		public virtual Iesi.Collections.Generic.ISet<NorthwindWebNHibernate.Business.Orders> FkOrdersCustomersCollection { get; set; }

		public override string ToString()
		{
			return string.Format("Customers.CustomerId={0}", this.CustomerId);
		}
	}
}
