using System.Runtime.Serialization;

namespace SpikeWcf.Dtos
{
	[DataContract]
	public class RootEntityDto
	{
		[DataMember]
		public DetailEntityDto[] DetailEntities;

		[DataMember]
		public ExternalEntityRefDto ExternalEntity;

		[DataMember]
		public string Name;

		[DataMember]
		public string StringId;
	}
}