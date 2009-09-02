namespace NorthwindWebNHibernate.Business
{
	public class Orders
	{

		public int OrderId { get; set; }

		public System.DateTime? OrderDate { get; set; }

		public System.DateTime? RequiredDate { get; set; }

		public System.DateTime? ShippedDate { get; set; }

		public decimal Freight { get; set; }

		public string ShipName { get; set; }

		public string ShipAddress { get; set; }

		public string ShipCity { get; set; }

		public string ShipRegion { get; set; }

		public string ShipPostalCode { get; set; }

		public string ShipCountry { get; set; }

		public NorthwindWebNHibernate.Business.Customers FkOrdersCustomers { get; set; }

		public NorthwindWebNHibernate.Business.Employees FkOrdersEmployees { get; set; }

		public NorthwindWebNHibernate.Business.Shippers FkOrdersShippers { get; set; }

		public override string ToString()
		{
			return string.Format("Orders.OrderId={0}", this.OrderId);
		}
	}
}
