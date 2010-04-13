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
		public PagedItems<CustomerDto> Find(string companyName, string contactName, string contactTitle, int start, int limit)
		{
			_log.DebugFormat("Find(companyName: {0}, contactName: {1}, contactTitle: {2}, start: {3}, limit: {4})", companyName, contactName, contactTitle, start, limit);
			using(ISession session = Global.SessionFactory.OpenSession())
			{
				IQueryable<Customer> queryable = session.Linq<Customer>();
				if(!string.IsNullOrEmpty(companyName))
				{
					queryable = queryable.Where(c => c.CompanyName.StartsWith(companyName));
				}
				if(!string.IsNullOrEmpty(contactName))
				{
					queryable = queryable.Where(c => c.ContactName.StartsWith(contactName));
				}
				if(!string.IsNullOrEmpty(contactTitle))
				{
					queryable = queryable.Where(c => c.ContactTitle.StartsWith(contactTitle));
				}
				int count = queryable.Count();
				queryable = queryable.Skip(start).Take(limit);
				CustomerDto[] customerDtos = Mapper.Map<IEnumerable<Customer>, CustomerDto[]>(queryable);
				return new PagedItems<CustomerDto>(customerDtos, count);
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