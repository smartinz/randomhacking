namespace NorthwindWebNHibernate.Business
{
	public class Products
	{

		public virtual int ProductId { get; set; }

		public virtual string ProductName { get; set; }

		public virtual string QuantityPerUnit { get; set; }

		public virtual decimal UnitPrice { get; set; }

		public virtual short UnitsInStock { get; set; }

		public virtual short UnitsOnOrder { get; set; }

		public virtual short ReorderLevel { get; set; }

		public virtual bool Discontinued { get; set; }

		public virtual NorthwindWebNHibernate.Business.Categories FkProductsCategories { get; set; }

		public virtual NorthwindWebNHibernate.Business.Suppliers FkProductsSuppliers { get; set; }

		public override string ToString()
		{
			return string.Format("Products.ProductId={0}", this.ProductId);
		}
	}
}
