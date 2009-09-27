namespace SpikeNHibernateBurrow
{
	public class ChildEntity
	{
		public virtual int Id { get; set; }
		public virtual string Value1 { get; set; }
		public virtual string Value2 { get; set; }
		public virtual Entity Entity { get; set; }
	}
}