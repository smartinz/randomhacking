using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ExtMvc.Domain;
using ExtMvc.Dtos;
using ExtMvc.Infrastructure;
using log4net;
using NHibernate;
using NHibernate.Criterion;

namespace ExtMvc.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ILog _log = LogManager.GetLogger(typeof(CustomerController));

		public ActionResult Find(string companyName, string contactName, string contactTitle, int start, int limit, string sort, string dir)
		{
			_log.DebugFormat("Find(companyName: {0}, contactName: {1}, contactTitle: {2}, start: {3}, limit: {4}, sort: {5}, dir: {6})", companyName, contactName, contactTitle, start, limit, sort, dir);
			using(ISession session = MvcApplication.SessionFactory.OpenSession())
			{
				ICriteria crit = session.CreateCriteria(typeof(Customer));
				if(!string.IsNullOrEmpty(companyName))
				{
					crit.Add(Restrictions.InsensitiveLike("CompanyName", companyName, MatchMode.Start));
				}
				if(!string.IsNullOrEmpty(contactName))
				{
					crit.Add(Restrictions.InsensitiveLike("ContactName", companyName, MatchMode.Start));
				}
				if(!string.IsNullOrEmpty(contactTitle))
				{
					crit.Add(Restrictions.InsensitiveLike("ContactTitle", companyName, MatchMode.Start));
				}
				var count = CriteriaTransformer.Clone(crit).SetProjection(Projections.RowCount()).UniqueResult<int>();
				if(!string.IsNullOrEmpty(sort))
				{
					crit.AddOrder(dir == "ASC" ? NHibernate.Criterion.Order.Asc(sort) : NHibernate.Criterion.Order.Desc(sort));
				}
				IList<Customer> list = crit.SetFirstResult(start).SetMaxResults(limit).List<Customer>();
				CustomerDto[] items = Mapper.Map<IEnumerable<Customer>, CustomerDto[]>(list);
				return Json(new{ items, count });
			}
		}

		public ActionResult Get(string id)
		{
			_log.DebugFormat("Get(id: {0}", id);
			using(ISession session = MvcApplication.SessionFactory.OpenSession())
			{
				var customer = session.Get<Customer>(id);
				CustomerDto dto = Mapper.Map<Customer, CustomerDto>(customer);
				return Json(new{ success = true, data = dto });
			}
		}

		public ActionResult Update(CustomerDto item)
		{
			_log.DebugFormat("Update(item: {0})", item);
			ValidationManager.Validate(ModelState, item, "item");
			return Json(new{
				success = false, //ModelState.IsValid,
				errors = new Dictionary<string, string>{
					{ "CompanyName", "Company name cannot be this!" },
					{ "ContactName", "Contact name is wrong!!!" }
				}
			});
		}
	}
}