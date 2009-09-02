namespace NorthwindWebNHibernate.Business
{
	public class OrderDetails
	{

		public virtual int OrderId { get; set; }

		public virtual int ProductId { get; set; }

		public virtual decimal UnitPrice { get; set; }

		public virtual short Quantity { get; set; }

		public virtual float Discount { get; set; }

		public override string ToString()
		{
			return string.Format("OrderDetails.OrderId={0}", this.OrderId);
		}
	}
}
