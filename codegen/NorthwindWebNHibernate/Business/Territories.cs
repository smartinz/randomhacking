namespace NorthwindWebNHibernate.Business
{
	public class Territories
	{

		public string TerritoryID { get; set; }

		public string TerritoryDescription { get; set; }

		public NorthwindWebNHibernate.Business.Region FK_Territories_Region { get; set; }

		public override string ToString()
		{
			return string.Format("Territories.TerritoryID={0}", this.TerritoryID);
		}
	}
}
