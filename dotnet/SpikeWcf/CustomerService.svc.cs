using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using AutoMapper;
using log4net;
using SpikeWcf.Domain.Northwind;
using SpikeWcf.Dtos.Northwind;
using NHibernate.Linq;
using System.Linq;

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
			_log.DebugFormat("start: {0}, limit: {1}", start, limit);
			using(var session = Global.SessionFactory.OpenSession())
			{
				var customers = session.Linq<Customer>().Skip(start).Take(limit);
				var customerDtos = Mapper.Map<IEnumerable<Customer>, CustomerDto[]>(customers);
				return new PagedItems<CustomerDto>(customerDtos, session.Linq<Customer>().Count());
			}
		}
	}
}