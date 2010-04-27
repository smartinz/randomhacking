using System.Web.Mvc;

namespace ExtMvc.Controllers
{
	public class TestController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Rpc(ComplexTypeDto objectValue, string[] arrayValue, string stringValue, int numberValue, bool trueValue, bool falseValue, object nullValue)
		{
			return Json(new{
				objectValue,
				arrayValue,
				stringValue,
				numberValue,
				trueValue,
				falseValue,
				nullValue
			});
		}

		#region Nested type: ComplexTypeDto

		public class ComplexTypeDto
		{
			public string StringValue { get; set; }
			public ComplexTypeDto[] ObjectValue { get; set; }
		}

		#endregion
	}
}