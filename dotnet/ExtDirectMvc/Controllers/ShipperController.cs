using System.Linq;
using System.Web.Mvc;
using Ext.Direct.Mvc;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Infrastructure;
using Newtonsoft.Json;

namespace ExtMvc.Controllers
{
	public class ShipperController : Controller
	{
		public ActionResult SearchNormal(int? shipperId, string companyName, string phone)
		{
			JsonSerializerSettings jsonSerializerSettings = Global.Ioc.Resolve<JsonSerializerSettingsBuilder>().BuildFor<Shipper>();


			var repository = Global.Ioc.Resolve<ShipperRepository>();
			IQueryable<Shipper> items = repository.SearchNormal(shipperId, companyName, phone);
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