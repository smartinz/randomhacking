namespace NorthwindWebNHibernate.Business
{
	public class CustomerDemographics
	{

		public virtual string CustomerTypeId { get; set; }

		public virtual string CustomerDesc { get; set; }

		public virtual Iesi.Collections.Generic.ISet<NorthwindWebNHibernate.Business.Customers> FkCustomerCustomerDemoCollection { get; set; }

		public override string ToString()
		{
			return string.Format("CustomerDemographics.CustomerTypeId={0}", this.CustomerTypeId);
		}
	}
}
