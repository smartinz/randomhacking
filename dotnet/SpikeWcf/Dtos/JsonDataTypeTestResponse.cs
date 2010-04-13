using System;
using System.Runtime.Serialization;

namespace SpikeWcf.Dtos
{
	[DataContract]
	public class JsonDataTypeTestResponse
	{
		[DataMember(Name = "stringPar")]
		public string StringPar { get; set; }

		[DataMember(Name = "intPar")]
		public int IntPar { get; set; }

		[DataMember(Name = "boolPar")]
		public bool BoolPar { get; set; }

		[DataMember(Name = "arrayPar")]
		public string[] ArrayPar { get; set; }

		[DataMember(Name = "datePar")]
		public DateTime DatePar { get; set; }

		[DataMember(Name = "doublePar")]
		public double DoublePar { get; set; }

		[DataMember(Name = "decimalPar")]
		public decimal DecimalPar { get; set; }

		[DataMember(Name = "guidPar")]
		public Guid GuidPar { get; set; }
	}
}