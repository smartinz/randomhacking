using System.Runtime.Serialization;

namespace SpikeWcf.Dtos
{
	[DataContract]
	public class ExternalEntityRefDto
	{
		[DataMember]
		public string StringId;

		[DataMember]
		public string Description;
	}
}