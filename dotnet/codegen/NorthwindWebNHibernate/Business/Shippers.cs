namespace NorthwindWebNHibernate.Business
{
	public class Shippers
	{

		public virtual int ShipperId { get; set; }

		public virtual string CompanyName { get; set; }

		public virtual string Phone { get; set; }

		public virtual Iesi.Collections.Generic.ISet<NorthwindWebNHibernate.Business.Orders> FkOrdersShippersCollection { get; set; }

		public override string ToString()
		{
			return string.Format("Shippers.ShipperId={0}", this.ShipperId);
		}
	}
}
