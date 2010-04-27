using System;
using System.Linq;
using System.Web.Mvc;
using Ext.Direct.Mvc;
using ExtMvc.Data;
using ExtMvc.Domain;
using ExtMvc.Infrastructure;
using Newtonsoft.Json;

namespace ExtMvc.Controllers
{
	public class EmployeeController : Controller
	{
		public ActionResult SearchNormal(int? employeeId, string lastName, string firstName, string title, string titleOfCourtesy, DateTime? birthDate, DateTime? hireDate, string address, string city, string region, string postalCode, string country, string homePhone, string extension, string notes, string photoPath)
		{
			JsonSerializerSettings jsonSerializerSettings = Global.Ioc.Resolve<JsonSerializerSettingsBuilder>().BuildFor<Employee>();


			var repository = Global.Ioc.Resolve<EmployeeRepository>();
			IQueryable<Employee> items = repository.SearchNormal(employeeId, lastName, firstName, title, titleOfCourtesy, birthDate, hireDate, address, city, region, postalCode, country, homePhone, extension, notes, photoPath);
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