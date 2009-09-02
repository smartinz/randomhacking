using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.Attributes;
using System.Collections.Generic;

namespace PersonalMoney
{
	public class Provider
	{
		private ISession _session;
		
		public Provider(ISession session)
		{
			_session = session;
		}

		public IList<Expense> GetExpenses()
		{
			return _session.CreateCriteria(typeof(Expense)).List<Expense>();
		}
			
		public Expense GetExpenseById(int id)
		{
			return _session.Get<Expense>(id);
		}
	}
}
