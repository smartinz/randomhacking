using System.Runtime.Serialization;

namespace SpikeWcf.Dtos
{
	[DataContract]
	public class DetailEntityDto
	{
		[DataMember]
		public string StringId { get; set; }

		[DataMember]
		public string Description { get; set; }
	}
}