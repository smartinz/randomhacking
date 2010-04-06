using System.Collections.Generic;
using System.ServiceModel;
using AutoMapper;
using SpikeWcf.Domain.Northwind;
using SpikeWcf.Dtos.Northwind;

namespace SpikeWcf
{
	[ServiceContract]
	public class CustomerService
	{
		[OperationContract]
		public PagedItems<CustomerDto> Find()
		{
			var session = Global.SessionFactory.OpenSession();
			var customers = session.CreateQuery("from Customer").List<Customer>();
			var customerDtos = Mapper.Map<IList<Customer>, CustomerDto[]>(customers);
			return new PagedItems<CustomerDto>(customerDtos);
		}
	}
}