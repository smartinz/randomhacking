using System;
using System.Web.Mvc;
using NorthwindWeb;
using NorthwindWeb.Business;
using NorthwindWeb.Data;

namespace NorthwindMvc.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return RedirectToAction("Search");
        }

        //
        // GET: /Customer/Search

        public ActionResult Search()
        {
            ViewData["contactName"] = "Maria Anders";
            return View(new Customer[0]);
        }

        //
        // POST: /Customer/Search
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Search(string companyName, string contactName, string contactTitle)
        {
            var customers = new Customer[0];
            try
            {
                customers = new CustomerRepository(new Context()).Search(companyName, contactName, contactTitle);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return PartialView("SearchPartial", customers);
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(string id)
        {
            Customer customer = new CustomerRepository(new Context()).Read(id);
            return View(customer);
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customer/Create

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
        // GET: /Customer/Edit/5

        public ActionResult Edit(string id)
        {
            Customer customer = new CustomerRepository(new Context()).Read(id);
            return View(customer);
        }

        //
        // POST: /Customer/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var customerRepository = new CustomerRepository(new Context());
            Customer customer = customerRepository.Read(id);
            UpdateModel(customer);
            try
            {
                customerRepository.Update(customer);
                return RedirectToAction("Details", new {id = id});
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(customer);
        }
    }
}