namespace NorthwindWebNHibernate.Business
{
	public class Categories
	{

		public virtual int CategoryId { get; set; }

		public virtual string CategoryName { get; set; }

		public virtual string Description { get; set; }

		public virtual byte[] Picture { get; set; }

		public virtual Iesi.Collections.Generic.ISet<NorthwindWebNHibernate.Business.Products> FkProductsCategoriesCollection { get; set; }

		public override string ToString()
		{
			return string.Format("Categories.CategoryId={0}", this.CategoryId);
		}
	}
}
