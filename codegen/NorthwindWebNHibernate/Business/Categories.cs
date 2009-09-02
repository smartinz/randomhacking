namespace NorthwindWebNHibernate.Business
{
	public class Categories
	{

		public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		public string Description { get; set; }

		public byte[] Picture { get; set; }

		public System.Collections.Generic.IList<NorthwindWebNHibernate.Business.Products> FkProductsCategoriesCollection { get; set; }

		public override string ToString()
		{
			return string.Format("Categories.CategoryId={0}", this.CategoryId);
		}
	}
}
