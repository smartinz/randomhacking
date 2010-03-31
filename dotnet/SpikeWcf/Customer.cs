using System.Runtime.Serialization;

namespace SpikeWcf
{
	[DataContract]
	public class Customer
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Name { get; set; }
	}
}