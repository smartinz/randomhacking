using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using AutoMapper;
using log4net;
using NHibernate;
using NHibernate.Linq;
using SpikeWcf.Domain.Northwind;
using SpikeWcf.Dtos.Northwind;

namespace SpikeWcf
{
	[ServiceContract]
	public class CustomerService
	{
		private readonly ILog _log = LogManager.GetLogger(typeof(CustomerService));

		[OperationContract]
		[WebInvoke(UriTemplate = "/Find", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public PagedItems<CustomerDto> Find(int start, int limit)
		{
			_log.DebugFormat("Find(start: {0}, limit: {1})", start, limit);
			using(ISession session = Global.SessionFactory.OpenSession())
			{
				IQueryable<Customer> customers = session.Linq<Customer>().Skip(start).Take(limit);
				CustomerDto[] customerDtos = Mapper.Map<IEnumerable<Customer>, CustomerDto[]>(customers);
				return new PagedItems<CustomerDto>(customerDtos, session.Linq<Customer>().Count());
			}
		}

		[OperationContract]
		[WebInvoke(UriTemplate = "/Get", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public CustomerDto Get(string customerId)
		{
			_log.DebugFormat("Get(customerId: {0})", customerId);
			using(ISession session = Global.SessionFactory.OpenSession())
			{
				var customer = session.Get<Customer>(customerId);
				CustomerDto customerDto = Mapper.Map<Customer, CustomerDto>(customer);
				return customerDto;
			}
		}

		[OperationContract]
		[WebInvoke(UriTemplate = "/Save", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool Save(CustomerDto customer)
		{
			_log.DebugFormat("Save(customer.customerId: {0})", customer.CustomerId);
			return true;
		}
	}
}