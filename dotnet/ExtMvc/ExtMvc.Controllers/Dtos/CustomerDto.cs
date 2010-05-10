using NHibernate.Validator.Constraints;

namespace ExtMvc.Dtos
{
	public class CustomerDto
	{
		public string CustomerId { get; set; }
		public string CompanyName { get; set; }
		public string ContactName { get; set; }
		public string ContactTitle { get; set; }
		public string Address { get; set; }
		[Length(5,10)]
		public string City { get; set; }
		public string Region { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }
		public string Fax { get; set; }
		[Valid]
		public OrderDto[] Orders { get; set; }
	}
}