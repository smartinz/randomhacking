namespace NorthwindWebNHibernate.Business
{
	public class CustomerDemographics
	{

		public string CustomerTypeID { get; set; }

		public string CustomerDesc { get; set; }

		public override string ToString()
		{
			return string.Format("CustomerDemographics.CustomerTypeID={0}", this.CustomerTypeID);
		}
	}
}
