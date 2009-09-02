namespace NorthwindWebNHibernate.Business
{
	public class Orders
	{

		public virtual int OrderId { get; set; }

		public virtual System.DateTime? OrderDate { get; set; }

		public virtual System.DateTime? RequiredDate { get; set; }

		public virtual System.DateTime? ShippedDate { get; set; }

		public virtual decimal Freight { get; set; }

		public virtual string ShipName { get; set; }

		public virtual string ShipAddress { get; set; }

		public virtual string ShipCity { get; set; }

		public virtual string ShipRegion { get; set; }

		public virtual string ShipPostalCode { get; set; }

		public virtual string ShipCountry { get; set; }

		public virtual NorthwindWebNHibernate.Business.Customers FkOrdersCustomers { get; set; }

		public virtual NorthwindWebNHibernate.Business.Employees FkOrdersEmployees { get; set; }

		public virtual NorthwindWebNHibernate.Business.Shippers FkOrdersShippers { get; set; }

		public override string ToString()
		{
			return string.Format("Orders.OrderId={0}", this.OrderId);
		}
	}
}
