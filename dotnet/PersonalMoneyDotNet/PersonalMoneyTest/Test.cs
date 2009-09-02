using System;
using NUnit.Framework;
using PersonalMoney;
using NHibernate;
using NHibernate.Cfg;

namespace PersonalMoneyTest
{
	[TestFixture]
	public class Test
	{
		
		ISessionFactory _sessionFactory;
			
		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			_sessionFactory = new Configuration().Configure().BuildSessionFactory();
		}
		
		[Test]
		public void TestCase()
		{
			ExpenseType t = new ExpenseType();
			t.Description = "Auto";
			
			Expense e = new Expense();
			e.Date = new DateTime(2009, 1, 18);
			e.Description = "description";
			e.Type = t;
			e.Amount = 100;

			using(var session = _sessionFactory.OpenSession())
				using(session.BeginTransaction())
			{
				session.Save(t);
				session.Save(e);
				session.Transaction.Commit();
			}
			int id = e.Id;
			e = _sessionFactory.OpenSession().Get<Expense>(id);
		
			Assert.AreEqual(id, e.Id);
			Assert.AreEqual("description", e.Description);
			Assert.AreEqual("Auto", e.Type.Description);
			Assert.AreEqual(100, e.Amount);
		}
	}
}
