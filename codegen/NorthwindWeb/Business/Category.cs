		namespace NorthwindWeb.Business
		{
		[System.Serializable]
		[System.Xml.Serialization.XmlType(Namespace = "http://www.northwind.com")]
		public class Category
		{
		
		public int CategoryID { get; set; }
	
		public string CategoryName { get; set; }
	
		public string Description { get; set; }
	
		public override string ToString()
		{
		return string.Format("Category.CategoryID={0}", this.CategoryID);
		}
		
		}
		}
