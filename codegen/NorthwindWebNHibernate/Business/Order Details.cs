namespace NorthwindWebNHibernate.Business
{
	public class OrderDetails
	{

		public int OrderID { get; set; }

		public int ProductID { get; set; }

		public decimal UnitPrice { get; set; }

		public short Quantity { get; set; }

		public float Discount { get; set; }

		public override string ToString()
		{
			return string.Format("Order Details.OrderID={0}", this.OrderID);
		}
	}
}
