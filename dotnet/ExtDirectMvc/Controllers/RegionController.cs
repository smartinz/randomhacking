using System.Linq;
using System.Web.Mvc;
using Ext.Direct.Mvc;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Infrastructure;
using Newtonsoft.Json;

namespace ExtMvc.Controllers
{
	public class RegionController : Controller
	{
		public ActionResult SearchNormal(int? regionId, string regionDescription)
		{
			JsonSerializerSettings jsonSerializerSettings = Global.Ioc.Resolve<JsonSerializerSettingsBuilder>().BuildFor<Region>();


			var repository = Global.Ioc.Resolve<RegionRepository>();
			IQueryable<Region> items = repository.SearchNormal(regionId, regionDescription);
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