using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ExtMvc.Data;
using ExtMvc.Domain;

namespace ExtMvc.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var customerRepository = new CustomerRepository(MvcApplication.CurrentSession);
			List<Customer> customers = customerRepository.SearchNormal(null).ToList();


			return View();
		}
	}
}