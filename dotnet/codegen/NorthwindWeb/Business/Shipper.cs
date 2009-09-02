		namespace NorthwindWeb.Business
		{
		[System.Serializable]
		[System.Xml.Serialization.XmlType(Namespace = "http://www.northwind.com")]
		public class Shipper
		{
		
		public int ShipperID { get; set; }
	
		public string CompanyName { get; set; }
	
		public string Phone { get; set; }
	
		public override string ToString()
		{
		return string.Format("Shipper.ShipperID={0}", this.ShipperID);
		}
		
		}
		}
