namespace NorthwindWebNHibernate.Business
{
	public class OrderDetails
	{

		public int OrderId { get; set; }

		public int ProductId { get; set; }

		public decimal UnitPrice { get; set; }

		public short Quantity { get; set; }

		public float Discount { get; set; }

		public override string ToString()
		{
			return string.Format("OrderDetails.OrderId={0}", this.OrderId);
		}
	}
}
