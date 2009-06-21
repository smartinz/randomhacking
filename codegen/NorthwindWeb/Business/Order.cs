		namespace NorthwindWeb.Business
		{
		[System.Serializable]
		[System.Xml.Serialization.XmlType(Namespace = "http://www.northwind.com")]
		public class Order
		{
		
		public int OrderID { get; set; }
	
		public System.DateTime? OrderDate { get; set; }
	
		public System.DateTime? RequiredDate { get; set; }
	
		public System.DateTime? ShippedDate { get; set; }
	
		public decimal Freight { get; set; }
	
		public string ShipName { get; set; }
	
		public string ShipAddress { get; set; }
	
		public string ShipCity { get; set; }
	
		public string ShipRegion { get; set; }
	
		public string ShipPostalCode { get; set; }
	
		public string ShipCountry { get; set; }
	
		public NorthwindWeb.Business.OrderDetail[] OrderDetails { get; set; }
	
		public NorthwindWeb.Business.Customer Customer { get; set; }
	
		public NorthwindWeb.Business.Employee Employee { get; set; }
	
		public NorthwindWeb.Business.Shipper Shipper { get; set; }
	
		public override string ToString()
		{
		return string.Format("Order.OrderID={0}", this.OrderID);
		}
		
		}
		}
