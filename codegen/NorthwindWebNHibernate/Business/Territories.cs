namespace NorthwindWebNHibernate.Business
{
	public class Territories
	{

		public virtual string TerritoryId { get; set; }

		public virtual string TerritoryDescription { get; set; }

		public virtual Iesi.Collections.Generic.ISet<NorthwindWebNHibernate.Business.Employees> FkEmployeeTerritoriesTerritoriesCollection { get; set; }

		public virtual NorthwindWebNHibernate.Business.Region FkTerritoriesRegion { get; set; }

		public override string ToString()
		{
			return string.Format("Territories.TerritoryId={0}", this.TerritoryId);
		}
	}
}
