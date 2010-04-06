using System.Runtime.Serialization;

namespace SpikeWcf.Dtos.Northwind
{
	[DataContract]
	public class CustomerDto
	{
		[DataMember]
		public string CustomerId { get; set; }
		[DataMember]
		public string CompanyName { get; set; }
		[DataMember]
		public string ContactName { get; set; }
		[DataMember]
		public string ContactTitle { get; set; }
		[DataMember]
		public string Address { get; set; }
		[DataMember]
		public string City { get; set; }
		[DataMember]
		public string Region { get; set; }
		[DataMember]
		public string PostalCode { get; set; }
		[DataMember]
		public string Country { get; set; }
		[DataMember]
		public string Phone { get; set; }
		[DataMember]
		public string Fax { get; set; }
		[DataMember]
		public OrderDto[] Orders { get; set; }
	}
}