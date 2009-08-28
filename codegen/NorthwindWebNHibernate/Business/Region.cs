namespace NorthwindWebNHibernate.Business
{
	public class Region
	{

		public int RegionID { get; set; }

		public string RegionDescription { get; set; }

		public System.Collections.Generic.IList<NorthwindWebNHibernate.Business.Territories> FK_Territories_Region { get; set; }

		public override string ToString()
		{
			return string.Format("Region.RegionID={0}", this.RegionID);
		}
	}
}
