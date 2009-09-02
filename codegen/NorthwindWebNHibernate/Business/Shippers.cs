namespace NorthwindWebNHibernate.Business
{
	public class Shippers
	{

		public int ShipperId { get; set; }

		public string CompanyName { get; set; }

		public string Phone { get; set; }

		public System.Collections.Generic.IList<NorthwindWebNHibernate.Business.Orders> FkOrdersShippersCollection { get; set; }

		public override string ToString()
		{
			return string.Format("Shippers.ShipperId={0}", this.ShipperId);
		}
	}
}
