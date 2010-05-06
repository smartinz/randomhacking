using System;
using NHibernate.Validator.Constraints;

namespace ExtMvc.Dtos
{
	public class OrderDto
	{
		public int OrderId { get; set; }
		public DateTime? OrderDate { get; set; }
		public DateTime? RequiredDate { get; set; }
		public DateTime? ShippedDate { get; set; }
		public decimal? Freight { get; set; }
		[Length(5, 10)]
		public string ShipName { get; set; }
		public string ShipAddress { get; set; }
		public string ShipCity { get; set; }
		public string ShipRegion { get; set; }
		public string ShipPostalCode { get; set; }
		public string ShipCountry { get; set; }
		[AssertTrue]
		public bool AssertTrue
		{
			get { return false; }
		}
	}
}