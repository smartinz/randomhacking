using System.Collections.Generic;

namespace NorthwindWebNHibernate.Business
{
	public class Categories
	{
		public int CategoryID { get; set; }

		public string CategoryName { get; set; }

		public string Description { get; set; }

		public byte[] Picture { get; set; }

		public IList<Products> FK_Products_Categories { get; set; }

		public override string ToString()
		{
			return string.Format("Categories.CategoryID={0}", CategoryID);
		}
	}
}