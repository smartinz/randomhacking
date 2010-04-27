using System.Web.Mvc;
using log4net;

namespace JQueryMvc.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ILog _log = LogManager.GetLogger(typeof(CustomerController));

		public ActionResult GetAll()
		{
			return Json(null);
		}
	}
}