namespace NorthwindWebNHibernate.Business
{
	public class CustomerCustomerDemo
	{

		public string CustomerID { get; set; }

		public string CustomerTypeID { get; set; }

		public override string ToString()
		{
			return string.Format("CustomerCustomerDemo.CustomerID={0}", this.CustomerID);
		}
	}
}
