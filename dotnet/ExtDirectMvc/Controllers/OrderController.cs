using System;
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
	public class OrderController : Controller
	{
		public ActionResult SearchNormal(int? orderId, DateTime? orderDate, DateTime? requiredDate, DateTime? shippedDate, decimal? freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry, JObject customer, JObject employee, JObject shipper)
		{
			JsonSerializerSettings jsonSerializerSettings = Global.Ioc.Resolve<JsonSerializerSettingsBuilder>().BuildFor<Order>();
			var customerDeserialized = JsonConvert.DeserializeObject<Customer>(customer.ToString(), jsonSerializerSettings);
			var employeeDeserialized = JsonConvert.DeserializeObject<Employee>(employee.ToString(), jsonSerializerSettings);
			var shipperDeserialized = JsonConvert.DeserializeObject<Shipper>(shipper.ToString(), jsonSerializerSettings);


			var repository = Global.Ioc.Resolve<OrderRepository>();
			IQueryable<Order> items = repository.SearchNormal(orderId, orderDate, requiredDate, shippedDate, freight, shipName, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry, customerDeserialized, employeeDeserialized, shipperDeserialized);
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