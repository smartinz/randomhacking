namespace NorthwindWebNHibernate.Business
{
	public class CustomerDemographics
	{

		public string CustomerTypeId { get; set; }

		public string CustomerDesc { get; set; }

		public System.Collections.Generic.IList<NorthwindWebNHibernate.Business.Customers> FkCustomerCustomerDemoCollection { get; set; }

		public override string ToString()
		{
			return string.Format("CustomerDemographics.CustomerTypeId={0}", this.CustomerTypeId);
		}
	}
}
