namespace NorthwindWebNHibernate.Business
{
	public class Products
	{

		public int ProductID { get; set; }

		public string ProductName { get; set; }

		public string QuantityPerUnit { get; set; }

		public decimal UnitPrice { get; set; }

		public short UnitsInStock { get; set; }

		public short UnitsOnOrder { get; set; }

		public short ReorderLevel { get; set; }

		public bool Discontinued { get; set; }

		public NorthwindWebNHibernate.Business.Categories FK_Products_Categories { get; set; }

		public NorthwindWebNHibernate.Business.Suppliers FK_Products_Suppliers { get; set; }

		public override string ToString()
		{
			return string.Format("Products.ProductID={0}", this.ProductID);
		}
	}
}
