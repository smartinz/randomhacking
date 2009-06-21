		namespace NorthwindWeb.Business
		{
		[System.Serializable]
		[System.Xml.Serialization.XmlType(Namespace = "http://www.northwind.com")]
		public class OrderDetail
		{
		
		public int OrderDetailID { get; set; }
	
		public decimal UnitPrice { get; set; }
	
		public short Quantity { get; set; }
	
		public float Discount { get; set; }
	
		public NorthwindWeb.Business.Product Product { get; set; }
	
		}
		}
