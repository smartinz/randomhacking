using System;
using System.Runtime.Serialization;

namespace SpikeWcf
{
	[DataContract]
	public class JsonDataTypeTestResponse
	{
		[DataMember]
		public string StringPar { get; set; }

		[DataMember]
		public int IntPar { get; set; }

		[DataMember]
		public bool BoolPar { get; set; }

		[DataMember]
		public string[] ArrayPar { get; set; }

		[DataMember]
		public DateTime DatePar { get; set; }
	}
}