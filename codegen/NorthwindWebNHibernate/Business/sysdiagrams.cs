namespace NorthwindWebNHibernate.Business
{
	public class sysdiagrams
	{

		public string name { get; set; }

		public int principal_id { get; set; }

		public int diagram_id { get; set; }

		public int? version { get; set; }

		public byte[] definition { get; set; }

		public override string ToString()
		{
			return string.Format("sysdiagrams.diagram_id={0}", this.diagram_id);
		}
	}
}
