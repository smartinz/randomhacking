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
				Settings = GetSettings()
			};
		}

		public ActionResult Update(JObject customerJson)
		{
			var customer = JsonConvert.DeserializeObject<Customer>(customerJson.ToString(), GetSettings());
			return new DirectResult();
		}

		static private JsonSerializerSettings GetSettings()
		{
			return new JsonSerializerSettings{
				Converters = GetConverters(),
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
		}

		static private JsonConverter[] GetConverters()
		{
			return new JsonConverter[]{
				new CategoryReferenceJsonConverter(new CategoryStringConverter(new CategoryRepository(MvcApplication.CurrentSession))),
				new EmployeeReferenceJsonConverter(new EmployeeStringConverter(new EmployeeRepository(MvcApplication.CurrentSession))),
				new OrderDetailReferenceJsonConverter(new OrderDetailStringConverter(new OrderDetailRepository(MvcApplication.CurrentSession))),
				new OrderReferenceJsonConverter(new OrderStringConverter(new OrderRepository(MvcApplication.CurrentSession))),
				new ProductReferenceJsonConverter(new ProductStringConverter(new ProductRepository(MvcApplication.CurrentSession))),
				new RegionReferenceJsonConverter(new RegionStringConverter(new RegionRepository(MvcApplication.CurrentSession))),
				new SupplierReferenceJsonConverter(new SupplierStringConverter(new SupplierRepository(MvcApplication.CurrentSession))),
				new SupplierReferenceJsonConverter(new SupplierStringConverter(new SupplierRepository(MvcApplication.CurrentSession))),
				new SysdiagramReferenceJsonConverter(new SysdiagramStringConverter(new SysdiagramRepository(MvcApplication.CurrentSession))),
				new TerritoryReferenceJsonConverter(new TerritoryStringConverter(new TerritoryRepository(MvcApplication.CurrentSession))),
			};
		}
	}
}