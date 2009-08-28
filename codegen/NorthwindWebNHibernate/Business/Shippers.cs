namespace NorthwindWebNHibernate.Business
{
	public class Shippers
	{

		public int ShipperID { get; set; }

		public string CompanyName { get; set; }

		public string Phone { get; set; }

		public System.Collections.Generic.IList<NorthwindWebNHibernate.Business.Orders> FK_Orders_Shippers { get; set; }

		public override string ToString()
		{
			return string.Format("Shippers.ShipperID={0}", this.ShipperID);
		}
	}
}
