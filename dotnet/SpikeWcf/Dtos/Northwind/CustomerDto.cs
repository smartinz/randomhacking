using System.Runtime.Serialization;

namespace SpikeWcf.Dtos.Northwind
{
	[DataContract]
	public class CustomerDto
	{
		[DataMember(Name = "customerId")]
		public string CustomerId { get; set; }
		[DataMember(Name = "companyName")]
		public string CompanyName { get; set; }
		[DataMember(Name = "contactName")]
		public string ContactName { get; set; }
		[DataMember(Name = "contactTitle")]
		public string ContactTitle { get; set; }
		[DataMember(Name = "address")]
		public string Address { get; set; }
		[DataMember(Name = "city")]
		public string City { get; set; }
		[DataMember(Name = "region")]
		public string Region { get; set; }
		[DataMember(Name = "postalCode")]
		public string PostalCode { get; set; }
		[DataMember(Name = "country")]
		public string Country { get; set; }
		[DataMember(Name = "phone")]
		public string Phone { get; set; }
		[DataMember(Name = "fax")]
		public string Fax { get; set; }
		[DataMember(Name = "orders")]
		public OrderDto[] Orders { get; set; }
	}
}