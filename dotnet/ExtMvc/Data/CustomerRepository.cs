using System;
using System.Collections.Generic;
using ExtMvc.Domain;
using ExtMvc.Dtos;
using NHibernate;
using NHibernate.Criterion;

namespace ExtMvc.Data
{
	public class CustomerRepository
	{
		private readonly ISessionFactory _sessionFactory;

		public CustomerRepository(ISessionFactory sessionFactory)
		{
			_sessionFactory = sessionFactory;
		}

		public Tuple<IEnumerable<Customer>, int> Find(string companyName, string contactName, string contactTitle, int start, int limit, string sort, string dir)
		{
			ICriteria crit = _sessionFactory.GetCurrentSession().CreateCriteria(typeof(Customer));
			if (!string.IsNullOrEmpty(companyName))
			{
				crit.Add(Restrictions.InsensitiveLike("CompanyName", companyName, MatchMode.Start));
			}
			if (!string.IsNullOrEmpty(contactName))
			{
				crit.Add(Restrictions.InsensitiveLike("ContactName", companyName, MatchMode.Start));
			}
			if (!string.IsNullOrEmpty(contactTitle))
			{
				crit.Add(Restrictions.InsensitiveLike("ContactTitle", companyName, MatchMode.Start));
			}
			var count = CriteriaTransformer.Clone(crit).SetProjection(Projections.RowCount()).UniqueResult<int>();
			if (!string.IsNullOrEmpty(sort))
			{
				crit.AddOrder(dir == "ASC" ? NHibernate.Criterion.Order.Asc(sort) : NHibernate.Criterion.Order.Desc(sort));
			}
			var customers = crit.SetFirstResult(start).SetMaxResults(limit).List<Customer>();
			return new Tuple<IEnumerable<Customer>, int>(customers, count);
		}

		public Customer Read(string id)
		{
			return _sessionFactory.GetCurrentSession().Get<Customer>(id);
		}
	}
}