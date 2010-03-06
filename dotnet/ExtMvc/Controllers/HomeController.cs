using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ext.Direct.Mvc;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Infrastructure;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using NHibernate;

namespace ExtMvc.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Find(string contactName)
		{
			var customerRepository = new CustomerRepository(Global.Ioc.Resolve<ISession>());
			List<Customer> customers = customerRepository.SearchNormal(contactName).ToList();
			return new DirectResult{
				Data = customers,
				Settings = GetSettings<Customer>()
			};
		}

		public ActionResult Update(JObject customerJson)
		{
			var customer = JsonConvert.DeserializeObject<Customer>(customerJson.ToString(), GetSettings<Customer>());
			return new DirectResult();
		}

		private static JsonSerializerSettings GetSettings<T>()
		{
			return new JsonSerializerSettings{
				Converters = GetConverters(typeof (T)),
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
		}

		private static JsonConverter[] GetConverters(Type type)
		{
			var session = Global.Ioc.Resolve<ISession>();
			return new JsonConverter[]{
				new CategoryJsonConverter(new CategoryStringConverter(new CategoryRepository(session)),
				                          typeof (Category).IsAssignableFrom(type) ? false : CategoryJsonConverter.DefaultSerializeAsReference),
				new CustomerDemographicJsonConverter(new CustomerDemographicStringConverter(new CustomerDemographicRepository(session)),
				                                     typeof (CustomerDemographic).IsAssignableFrom(type) ? false : CustomerDemographicJsonConverter.DefaultSerializeAsReference),
				new CustomerJsonConverter(new CustomerStringConverter(new CustomerRepository(session)),
				                          typeof (Customer).IsAssignableFrom(type) ? false : CustomerJsonConverter.DefaultSerializeAsReference),
				new EmployeeJsonConverter(new EmployeeStringConverter(new EmployeeRepository(session)),
				                          typeof (Employee).IsAssignableFrom(type) ? false : EmployeeJsonConverter.DefaultSerializeAsReference),
				new OrderDetailJsonConverter(new OrderDetailStringConverter(new OrderDetailRepository(session)),
				                             typeof (Order).IsAssignableFrom(type) ? false : OrderJsonConverter.DefaultSerializeAsReference),
				new OrderJsonConverter(new OrderStringConverter(new OrderRepository(session)),
				                       typeof (Order).IsAssignableFrom(type) ? false : OrderJsonConverter.DefaultSerializeAsReference),
				new ProductJsonConverter(new ProductStringConverter(new ProductRepository(session)),
				                         typeof (Product).IsAssignableFrom(type) ? false : ProductJsonConverter.DefaultSerializeAsReference),
				new RegionJsonConverter(new RegionStringConverter(new RegionRepository(session)),
				                        typeof (Region).IsAssignableFrom(type) ? false : RegionJsonConverter.DefaultSerializeAsReference),
				new ShipperJsonConverter(new ShipperStringConverter(new ShipperRepository(session)),
				                         typeof (Shipper).IsAssignableFrom(type) ? false : ShipperJsonConverter.DefaultSerializeAsReference),
				new SupplierJsonConverter(new SupplierStringConverter(new SupplierRepository(session)),
				                          typeof (Supplier).IsAssignableFrom(type) ? false : SupplierJsonConverter.DefaultSerializeAsReference),
				new SysdiagramJsonConverter(new SysdiagramStringConverter(new SysdiagramRepository(session)),
				                            typeof (Sysdiagram).IsAssignableFrom(type) ? false : SysdiagramJsonConverter.DefaultSerializeAsReference),
				new TerritoryJsonConverter(new TerritoryStringConverter(new TerritoryRepository(session)),
				                           typeof (Territory).IsAssignableFrom(type) ? false : TerritoryJsonConverter.DefaultSerializeAsReference),
			};
		}
	}
}