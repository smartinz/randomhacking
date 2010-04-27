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
	public class ProductController : Controller
	{
		public ActionResult SearchNormal(int? productId, string productName, string quantityPerUnit, decimal? unitPrice, short? unitsInStock, short? unitsOnOrder, short? reorderLevel, bool? discontinued, JObject category, JObject supplier)
		{
			JsonSerializerSettings jsonSerializerSettings = Global.Ioc.Resolve<JsonSerializerSettingsBuilder>().BuildFor<Product>();
			var categoryDeserialized = JsonConvert.DeserializeObject<Category>(category.ToString(), jsonSerializerSettings);
			var supplierDeserialized = JsonConvert.DeserializeObject<Supplier>(supplier.ToString(), jsonSerializerSettings);


			var repository = Global.Ioc.Resolve<ProductRepository>();
			IQueryable<Product> items = repository.SearchNormal(productId, productName, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued, categoryDeserialized, supplierDeserialized);
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