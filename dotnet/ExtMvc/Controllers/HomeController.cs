using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ext.Direct.Mvc;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

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
			var customerRepository = new CustomerRepository(MvcApplication.CurrentSession);
			List<Customer> customers = customerRepository.SearchNormal(contactName).ToList();
			return new DirectResult{
				Data = customers,
				Settings = GetSettings<Customer>()
			};
		}

		public ActionResult Update(JObject customerJson)
		{
			var customer = JsonConvert.DeserializeObject<Customer>(customerJson.ToString(), GetSettings());
			return new DirectResult();
		}

		static private JsonSerializerSettings GetSettings<T>()
		{
			return new JsonSerializerSettings{
				Converters = GetConverters(typeof(T)),
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
		}

		static private JsonConverter[] GetConverters(Type type)
		{
			return new JsonConverter[]{
				new CategoryJsonConverter(new CategoryStringConverter(new CategoryRepository(MvcApplication.CurrentSession)),
				                          typeof(Category).IsAssignableFrom(type) ? false : CategoryJsonConverter.DefaultSerializeAsReference),
				new CustomerDemographicJsonConverter(new CustomerDemographicStringConverter(new CustomerDemographicRepository(MvcApplication.CurrentSession)),
				                                     typeof(CustomerDemographic).IsAssignableFrom(type) ? false : CustomerDemographicJsonConverter.DefaultSerializeAsReference),
				new CustomerJsonConverter(new CustomerStringConverter(new CustomerRepository(MvcApplication.CurrentSession)),
				                          typeof(Customer).IsAssignableFrom(type) ? false : CustomerJsonConverter.DefaultSerializeAsReference),
				new EmployeeJsonConverter(new EmployeeStringConverter(new EmployeeRepository(MvcApplication.CurrentSession)),
				                          typeof(Employee).IsAssignableFrom(type) ? false : EmployeeJsonConverter.DefaultSerializeAsReference),
				new OrderDetailJsonConverter(new OrderDetailStringConverter(new OrderDetailRepository(MvcApplication.CurrentSession)),
				                             typeof(Order).IsAssignableFrom(type) ? false : OrderJsonConverter.DefaultSerializeAsReference),
				new OrderJsonConverter(new OrderStringConverter(new OrderRepository(MvcApplication.CurrentSession)),
				                       typeof(Order).IsAssignableFrom(type) ? false : OrderJsonConverter.DefaultSerializeAsReference),
				new ProductJsonConverter(new ProductStringConverter(new ProductRepository(MvcApplication.CurrentSession)),
				                         typeof(Product).IsAssignableFrom(type) ? false : ProductJsonConverter.DefaultSerializeAsReference),
				new RegionJsonConverter(new RegionStringConverter(new RegionRepository(MvcApplication.CurrentSession)),
				                        typeof(Region).IsAssignableFrom(type) ? false : RegionJsonConverter.DefaultSerializeAsReference),
				new ShipperJsonConverter(new ShipperStringConverter(new ShipperRepository(MvcApplication.CurrentSession)),
				                         typeof(Shipper).IsAssignableFrom(type) ? false : ShipperJsonConverter.DefaultSerializeAsReference),
				new SupplierJsonConverter(new SupplierStringConverter(new SupplierRepository(MvcApplication.CurrentSession)),
				                          typeof(Supplier).IsAssignableFrom(type) ? false : SupplierJsonConverter.DefaultSerializeAsReference),
				new SysdiagramJsonConverter(new SysdiagramStringConverter(new SysdiagramRepository(MvcApplication.CurrentSession)),
				                            typeof(Sysdiagram).IsAssignableFrom(type) ? false : SysdiagramJsonConverter.DefaultSerializeAsReference),
				new TerritoryJsonConverter(new TerritoryStringConverter(new TerritoryRepository(MvcApplication.CurrentSession)),
				                           typeof(Territory).IsAssignableFrom(type) ? false : TerritoryJsonConverter.DefaultSerializeAsReference),
			};
		}
	}
}