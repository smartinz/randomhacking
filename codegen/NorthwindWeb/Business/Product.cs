		namespace NorthwindWeb.Business
		{
		[System.Serializable]
		[System.Xml.Serialization.XmlType(Namespace = "http://www.northwind.com")]
		public class Product
		{
		
		public int ProductID { get; set; }
	
		public string ProductName { get; set; }
	
		public string QuantityPerUnit { get; set; }
	
		public decimal UnitPrice { get; set; }
	
		public short UnitsInStock { get; set; }
	
		public short UnitsOnOrder { get; set; }
	
		public short ReorderLevel { get; set; }
	
		public bool Discontinued { get; set; }
	
		public NorthwindWeb.Business.Supplier Supplier { get; set; }
	
		public NorthwindWeb.Business.Category Category { get; set; }
	
		public override string ToString()
		{
		return string.Format("Product.ProductID={0}", this.ProductID);
		}
		
		}
		}
