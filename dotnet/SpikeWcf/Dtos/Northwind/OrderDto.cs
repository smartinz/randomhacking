using System;
using System.Runtime.Serialization;

namespace SpikeWcf.Dtos.Northwind
{
	[DataContract]
	public class OrderDto
	{
		[DataMember(Name = "orderId")]
		public int OrderId { get; set; }
		[DataMember(Name = "orderDate")]
		public DateTime? OrderDate { get; set; }
		[DataMember(Name = "requiredDate")]
		public DateTime? RequiredDate { get; set; }
		[DataMember(Name = "shippedDate")]
		public DateTime? ShippedDate { get; set; }
		[DataMember(Name = "freight")]
		public decimal? Freight { get; set; }
		[DataMember(Name = "shipName")]
		public string ShipName { get; set; }
		[DataMember(Name = "shipAddress")]
		public string ShipAddress { get; set; }
		[DataMember(Name = "shipCity")]
		public string ShipCity { get; set; }
		[DataMember(Name = "shipRegion")]
		public string ShipRegion { get; set; }
		[DataMember(Name = "shipPostalCode")]
		public string ShipPostalCode { get; set; }
		[DataMember(Name = "shipCountry")]
		public string ShipCountry { get; set; }
	}
}