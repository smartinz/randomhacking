using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using AutoMapper;
using SpikeWcf.Domain.Northwind;
using SpikeWcf.Dtos.Northwind;

namespace SpikeWcf
{
	[ServiceContract]
	public class CustomerService
	{
		[OperationContract]
		[WebInvoke(UriTemplate = "/Find", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public PagedItems<CustomerDto> Find()
		{
			var session = Global.SessionFactory.OpenSession();
			var customers = session.CreateQuery("from Customer").List<Customer>();
			var customerDtos = Mapper.Map<IList<Customer>, CustomerDto[]>(customers);
			return new PagedItems<CustomerDto>(customerDtos, customerDtos.Length);
		}
	}
}