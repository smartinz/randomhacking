using System;
using System.Web.Mvc;
using NorthwindWeb;
using NorthwindWeb.Business;
using NorthwindWeb.Data;

namespace NorthwindMvc.Controllers
{
	public class OrderController : Controller
	{
		//
		// GET: /Order/

		public ActionResult Index()
		{
			return RedirectToAction("Search");
		}

		//
		// GET: /Order/Search

		public ActionResult Search()
		{
			return View(new Order[0]);
		}

		//
		// POST: /Customer/Search
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Search(string employeeId, string dateFrom, string dateTo)
		{
			var context = new Context();
			ViewData["employee"] = default(Employee);
			if (!string.IsNullOrEmpty(employeeId))
			{
				ViewData["employee"] = new EmployeeRepository(context).Read(Convert.ToInt32(employeeId));
			}

			DateTime dateFromParsed = default(DateTime);
			if (!string.IsNullOrEmpty(dateFrom) && !DateTime.TryParse(dateFrom, out dateFromParsed))
			{
				ModelState.AddModelError("dateFrom", "error parsing dateFrom");
			}
			ViewData["dateFrom"] = dateFromParsed;

			DateTime dateToParsed = default(DateTime);
			if (!string.IsNullOrEmpty(dateTo) && !DateTime.TryParse(dateTo, out dateToParsed))
			{
				ModelState.AddModelError("dateTo", "error parsing dateTo");
			}
			ViewData["dateTo"] = dateToParsed;

			var orders = new Order[0];
			if (ModelState.IsValid)
			{
				orders = new OrderRepository(context).Search((Employee)ViewData["employee"], (DateTime)ViewData["dateFrom"], (DateTime) ViewData["dateFrom"]);
			}
			return View(orders);
		}

		//
		// GET: /Order/Details/5

		public ActionResult Details(int id)
		{
			return View();
		}

		//
		// GET: /Order/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Order/Create

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /Order/Edit/5

		public ActionResult Edit(int id)
		{
			Order order = new OrderRepository(new Context()).Read(id);
			return View(order);
		}

		//
		// POST: /Order/Edit/5

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}