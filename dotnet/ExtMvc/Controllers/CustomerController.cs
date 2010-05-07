using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Castle.Core.Logging;
using ExtMvc.Domain;
using ExtMvc.Dtos;
using ExtMvc.Infrastructure;
using NHibernate;
using NHibernate.Criterion;

namespace ExtMvc.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ISession _session;
		private readonly IMappingEngine _mapper;
		private ILogger _logger = NullLogger.Instance;

		public CustomerController(ISession session, IMappingEngine mapper)
		{
			_session = session;
			_mapper = mapper;
		}

		public ILogger Logger
		{
			get { return _logger; }
			set { _logger = value; }
		}

		public ActionResult Find(string companyName, string contactName, string contactTitle, int start, int limit, string sort, string dir)
		{
			_logger.DebugFormat("Find(companyName: {0}, contactName: {1}, contactTitle: {2}, start: {3}, limit: {4}, sort: {5}, dir: {6})", companyName, contactName, contactTitle, start, limit, sort, dir);
			ICriteria crit = _session.CreateCriteria(typeof(Customer));
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
			CustomerDto[] items = _mapper.Map<IEnumerable<Customer>, CustomerDto[]>(list);
			return Json(new{ items, count });
		}

		public ActionResult Get(string id)
		{
			_logger.DebugFormat("Get(id: {0}", id);
			var customer = _session.Get<Customer>(id);
			CustomerDto data = _mapper.Map<Customer, CustomerDto>(customer);
			return Json(new{ success = true, data });
		}

		public ActionResult Update(CustomerDto item)
		{
			_logger.DebugFormat("Update(item: {0})", item);
			ValidationManager.Validate(ModelState, item, "item");
			return Json(ValidationManager.BuildResponse(ModelState));
		}
	}
}