using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ExtMvc.Domain;
using ExtMvc.Dtos;
using log4net;
using NHibernate;
using NHibernate.Criterion;

namespace ExtMvc.Controllers
{
	public class OrderController : Controller
	{
		private readonly ILog _log = LogManager.GetLogger(typeof(OrderController));

		public ActionResult Find(int start, int limit, string sort, string dir)
		{
			_log.DebugFormat("Find(start: {0}, limit: {1}, sort: {2}, dir: {3})", start, limit, sort, dir);
			using (ISession session = MvcApplication.SessionFactory.OpenSession())
			{
				var crit = session.CreateCriteria(typeof(Domain.Order));
				var count = CriteriaTransformer.Clone(crit).SetProjection(Projections.RowCount()).UniqueResult<int>();
				if (!string.IsNullOrEmpty(sort))
				{
					crit.AddOrder(dir == "ASC" ? NHibernate.Criterion.Order.Asc(sort) : NHibernate.Criterion.Order.Desc(sort));
				}
				var list = crit.SetFirstResult(start).SetMaxResults(limit).List<Domain.Order>();
				OrderDto[] items = Mapper.Map<IEnumerable<Domain.Order>, OrderDto[]>(list);
				return Json(new { items, count });
			}
		}
	}
}