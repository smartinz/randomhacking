using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Castle.Core.Logging;
using ExtMvc.Dtos;
using NHibernate;
using NHibernate.Criterion;

namespace ExtMvc.Controllers
{
	public class OrderController : Controller
	{
		private readonly ILogger _logger;
		private readonly ISession _session;
		private readonly IMappingEngine _mapper;

		public OrderController(ILogger logger, ISession session, IMappingEngine mapper)
		{
			_logger = logger;
			_session = session;
			_mapper = mapper;
		}

		public ActionResult Find(int start, int limit, string sort, string dir)
		{
			_logger.DebugFormat("Find(start: {0}, limit: {1}, sort: {2}, dir: {3})", start, limit, sort, dir);
			ICriteria crit = _session.CreateCriteria(typeof(Domain.Order));
			var count = CriteriaTransformer.Clone(crit).SetProjection(Projections.RowCount()).UniqueResult<int>();
			if(!string.IsNullOrEmpty(sort))
			{
				crit.AddOrder(dir == "ASC" ? Order.Asc(sort) : Order.Desc(sort));
			}
			IList<Domain.Order> list = crit.SetFirstResult(start).SetMaxResults(limit).List<Domain.Order>();
			OrderDto[] items = _mapper.Map<IEnumerable<Domain.Order>, OrderDto[]>(list);
			return Json(new{ items, count });
		}
	}
}