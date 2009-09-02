namespace NorthwindWebNHibernate.Business
{
	public class Region
	{

		public virtual int RegionId { get; set; }

		public virtual string RegionDescription { get; set; }

		public virtual Iesi.Collections.Generic.ISet<NorthwindWebNHibernate.Business.Territories> FkTerritoriesRegionCollection { get; set; }

		public override string ToString()
		{
			return string.Format("Region.RegionId={0}", this.RegionId);
		}
	}
}
