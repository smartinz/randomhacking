namespace NorthwindWebNHibernate.Business
{
	public class Territories
	{

		public string TerritoryId { get; set; }

		public string TerritoryDescription { get; set; }

		public System.Collections.Generic.IList<NorthwindWebNHibernate.Business.Employees> FkEmployeeTerritoriesTerritoriesCollection { get; set; }

		public NorthwindWebNHibernate.Business.Region FkTerritoriesRegion { get; set; }

		public override string ToString()
		{
			return string.Format("Territories.TerritoryId={0}", this.TerritoryId);
		}
	}
}
