using System;
using System.Diagnostics;
using System.Web.Mvc;
using JQueryMvc.Models;

namespace JQueryMvc.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tests()
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
            return Json(new { dateValue = dateValue.ToUniversalTime() });
        }
    }
}