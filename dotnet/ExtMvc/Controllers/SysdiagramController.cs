using System.Linq;
using System.Web.Mvc;
using Ext.Direct.Mvc;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Infrastructure;
using Newtonsoft.Json;

namespace ExtMvc.Controllers
{
	public class SysdiagramController : Controller
	{
		public ActionResult SearchNormal(string name, int? principalId, int? diagramId, int? version)
		{
			JsonSerializerSettings jsonSerializerSettings = Global.Ioc.Resolve<JsonSerializerSettingsBuilder>().BuildFor<Sysdiagram>();


			var repository = Global.Ioc.Resolve<SysdiagramRepository>();
			IQueryable<Sysdiagram> items = repository.SearchNormal(name, principalId, diagramId, version);
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