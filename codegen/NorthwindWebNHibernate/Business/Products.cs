namespace NorthwindWebNHibernate.Business
{
	public class Products
	{

		public int ProductId { get; set; }

		public string ProductName { get; set; }

		public string QuantityPerUnit { get; set; }

		public decimal UnitPrice { get; set; }

		public short UnitsInStock { get; set; }

		public short UnitsOnOrder { get; set; }

		public short ReorderLevel { get; set; }

		public bool Discontinued { get; set; }

		public NorthwindWebNHibernate.Business.Categories FkProductsCategories { get; set; }

		public NorthwindWebNHibernate.Business.Suppliers FkProductsSuppliers { get; set; }

		public override string ToString()
		{
			return string.Format("Products.ProductId={0}", this.ProductId);
		}
	}
}
