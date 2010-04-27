using System;
using System.Diagnostics;
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

		public ActionResult RpcWithDate(DateTime dateValue)
		{
			Debug.Assert(dateValue == new DateTime(2010, 5, 26, 11, 49, 33, 44));
			return Json(new { dateValue });
		}

		public ActionResult ThrowException()
		{
			throw new ApplicationException("Expected Exception");
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