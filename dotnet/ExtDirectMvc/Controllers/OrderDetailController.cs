using System.Linq;
using System.Web.Mvc;
using Ext.Direct.Mvc;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Infrastructure;
using Newtonsoft.Json;

namespace ExtMvc.Controllers
{
	public class OrderDetailController : Controller
	{
		public ActionResult Search(int? orderId, int? productId, decimal? unitPrice, short? quantity, float? discount)
		{
			JsonSerializerSettings jsonSerializerSettings = Global.Ioc.Resolve<JsonSerializerSettingsBuilder>().BuildFor<OrderDetail>();


			var repository = Global.Ioc.Resolve<OrderDetailRepository>();
			IQueryable<OrderDetail> items = repository.Search(orderId, productId, unitPrice, quantity, discount);
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