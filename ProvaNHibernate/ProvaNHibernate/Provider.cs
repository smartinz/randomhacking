using System;

namespace ProvaNHibernate
{
	public class Provider
	{
		public Provider()
		{
		}

		public Expense GetExpenseById(int id)
		{
			NHibernate.ISessionFactory sessionFactory = new NHibernate.Cfg.Configuration().Configure().BuildSessionFactory();
			NHibernate.ISession session = sessionFactory.OpenSession();
			return session.Get<Expense>(id);
		}
	}
}
