using System;
using System.Runtime.Serialization;

namespace SpikeWcf.Dtos.Northwind
{
	[DataContract]
	public class OrderDto
	{
		[DataMember]
		public int OrderId { get; set; }
		[DataMember]
		public DateTime? OrderDate { get; set; }
		[DataMember]
		public DateTime? RequiredDate { get; set; }
		[DataMember]
		public DateTime? ShippedDate { get; set; }
		[DataMember]
		public decimal? Freight { get; set; }
		[DataMember]
		public string ShipName { get; set; }
		[DataMember]
		public string ShipAddress { get; set; }
		[DataMember]
		public string ShipCity { get; set; }
		[DataMember]
		public string ShipRegion { get; set; }
		[DataMember]
		public string ShipPostalCode { get; set; }
		[DataMember]
		public string ShipCountry { get; set; }
	}
}