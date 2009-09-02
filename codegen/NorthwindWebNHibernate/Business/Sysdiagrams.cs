namespace NorthwindWebNHibernate.Business
{
	public class Sysdiagrams
	{

		public virtual string Name { get; set; }

		public virtual int PrincipalId { get; set; }

		public virtual int DiagramId { get; set; }

		public virtual int? Version { get; set; }

		public virtual byte[] Definition { get; set; }

		public override string ToString()
		{
			return string.Format("Sysdiagrams.DiagramId={0}", this.DiagramId);
		}
	}
}
