using System;
using System.Web.Mvc;

namespace NorthwindMvc.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public string GetStatus()
        {
            return "Status OK at " + DateTime.Now.ToLongTimeString();
        }

        public string UpdateForm(string textBox1)
        {
            if (textBox1 != "Enter text")
            {
                return "You entered: \"" + textBox1 + "\" at " +
                       DateTime.Now.ToLongTimeString();
            }

            return string.Empty;
        }

        public ActionResult About()
        {
            return View();
        }
    }
}