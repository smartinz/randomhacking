using System.Linq;
using System.Web.Mvc;
using Ext.Direct.Mvc;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Infrastructure;
using Newtonsoft.Json;

namespace ExtMvc.Controllers
{
	public class CustomerDemographicController : Controller
	{
		public ActionResult SearchNormal(string customerTypeId, string customerDesc)
		{
			JsonSerializerSettings jsonSerializerSettings = Global.Ioc.Resolve<JsonSerializerSettingsBuilder>().BuildFor<CustomerDemographic>();


			var repository = Global.Ioc.Resolve<CustomerDemographicRepository>();
			IQueryable<CustomerDemographic> items = repository.SearchNormal(customerTypeId, customerDesc);
			return new DirectResult{
				Data = new{
					Count = items.Count(),
					Items = items.AsEnumerable()
				},
				Settings = jsonSerializerSettings
			};
		}
	}
}