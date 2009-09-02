namespace NorthwindWebNHibernate.Business
{
	public class Region
	{

		public int RegionId { get; set; }

		public string RegionDescription { get; set; }

		public System.Collections.Generic.IList<NorthwindWebNHibernate.Business.Territories> FkTerritoriesRegionCollection { get; set; }

		public override string ToString()
		{
			return string.Format("Region.RegionId={0}", this.RegionId);
		}
	}
}
