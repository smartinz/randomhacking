using System;
using System.Web.Mvc;
using NorthwindWeb;
using NorthwindWeb.Business;
using NorthwindWeb.Data;

namespace NorthwindMvc.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            return RedirectToAction("Search");
        }

        //
        // GET: /Employee/Search

        public ActionResult Search()
        {
            var employees = new Employee[0];
            if (Request.IsAjaxRequest())
            {
                return PartialView("SearchPartial", employees);
            }
            return View(employees);
        }

        //
        // POST: /Employee/Search
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Search(string lastName, string firstName, string title)
        {
            var employees = new Employee[0];
            try
            {
                employees = new EmployeeRepository(new Context()).Search(lastName, firstName, title);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return PartialView("SearchPartial", employees);
        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employee/Create

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
        // GET: /Employee/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Employee/Edit/5

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