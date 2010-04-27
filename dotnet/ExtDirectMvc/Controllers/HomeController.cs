using System.Linq;
using System.Web.Mvc;
using Ext.Direct.Mvc;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
			var customerRepository = Global.Ioc.Resolve<CustomerRepository>();
			IQueryable<Customer> customers = customerRepository.SearchNormal(contactName);

			var jsonSerializerSettingsBuilder = Global.Ioc.Resolve<JsonSerializerSettingsBuilder>();
			return new DirectResult{
				Data = customers,
				Settings = jsonSerializerSettingsBuilder.BuildFor<Customer>()
			};
		}

		public ActionResult Update(JObject customerJson)
		{
			var jsonSerializerSettingsBuilder = Global.Ioc.Resolve<JsonSerializerSettingsBuilder>();
			var customer = JsonConvert.DeserializeObject<Customer>(customerJson.ToString(), jsonSerializerSettingsBuilder.BuildFor<Customer>());
			return new DirectResult();
		}
	}
}