using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace ExtMvc.Data
{
	public class OrderRepository
	{
		private readonly ISessionFactory _sessionFactory;

		public OrderRepository(ISessionFactory sessionFactory)
		{
			_sessionFactory = sessionFactory;
		}

		public Tuple<IEnumerable<Domain.Order>, int> Find(int start, int limit, string sort, string dir)
		{
			ICriteria crit = _sessionFactory.GetCurrentSession().CreateCriteria(typeof(Domain.Order));
			var count = CriteriaTransformer.Clone(crit).SetProjection(Projections.RowCount()).UniqueResult<int>();
			if(!string.IsNullOrEmpty(sort))
			{
				crit.AddOrder(dir == "ASC" ? Order.Asc(sort) : Order.Desc(sort));
			}
			IList<Domain.Order> list = crit.SetFirstResult(start).SetMaxResults(limit).List<Domain.Order>();
			return new Tuple<IEnumerable<Domain.Order>, int>(list, count);
		}
	}
}