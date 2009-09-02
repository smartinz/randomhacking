namespace NorthwindWebNHibernate.Business
{
	public class Suppliers
	{

		public virtual int SupplierId { get; set; }

		public virtual string CompanyName { get; set; }

		public virtual string ContactName { get; set; }

		public virtual string ContactTitle { get; set; }

		public virtual string Address { get; set; }

		public virtual string City { get; set; }

		public virtual string Region { get; set; }

		public virtual string PostalCode { get; set; }

		public virtual string Country { get; set; }

		public virtual string Phone { get; set; }

		public virtual string Fax { get; set; }

		public virtual string HomePage { get; set; }

		public virtual Iesi.Collections.Generic.ISet<NorthwindWebNHibernate.Business.Products> FkProductsSuppliersCollection { get; set; }

		public override string ToString()
		{
			return string.Format("Suppliers.SupplierId={0}", this.SupplierId);
		}
	}
}
