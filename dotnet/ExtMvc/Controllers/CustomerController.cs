using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ExtMvc.Domain;
using ExtMvc.Dtos;
using log4net;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ILog _log = LogManager.GetLogger(typeof(CustomerController));

		public ActionResult Find(string companyName, string contactName, string contactTitle, int start, int limit)
		{
			_log.DebugFormat("Find(companyName: {0}, contactName: {1}, contactTitle: {2}, start: {3}, limit: {4})", companyName, contactName, contactTitle, start, limit);
			using(ISession session = MvcApplication.SessionFactory.OpenSession())
			{
				IQueryable<Customer> queryable = session.Linq<Customer>();
				if(!string.IsNullOrEmpty(companyName))
				{
					queryable = queryable.Where(c => c.CompanyName.StartsWith(companyName));
				}
				if(!string.IsNullOrEmpty(contactName))
				{
					queryable = queryable.Where(c => c.ContactName.StartsWith(contactName));
				}
				if(!string.IsNullOrEmpty(contactTitle))
				{
					queryable = queryable.Where(c => c.ContactTitle.StartsWith(contactTitle));
				}
				int count = queryable.Count();
				queryable = queryable.Skip(start).Take(limit);
				CustomerDto[] items = Mapper.Map<IEnumerable<Customer>, CustomerDto[]>(queryable);
				return Json(new{ items, count });
			}
		}
	}
}