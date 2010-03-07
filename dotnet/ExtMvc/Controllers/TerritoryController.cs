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
	public class TerritoryController : Controller
	{
		public ActionResult SearchNormal(string territoryId, string territoryDescription, JObject region)
		{
			JsonSerializerSettings jsonSerializerSettings = Global.Ioc.Resolve<JsonSerializerSettingsBuilder>().BuildFor<Territory>();
			var regionDeserialized = JsonConvert.DeserializeObject<Region>(region.ToString(), jsonSerializerSettings);


			var repository = Global.Ioc.Resolve<TerritoryRepository>();
			IQueryable<Territory> items = repository.SearchNormal(territoryId, territoryDescription, regionDeserialized);
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