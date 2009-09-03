using System.Linq;
using NHibernate;
using NorthwindWebNHibernate.Business;
using NHibernate.Linq;

namespace NorthwindWebNHibernate.Data
{
	public class EmployeesRepository
	{
		private readonly ISession _session;

		public EmployeesRepository(ISession session)
		{
			_session = session;
		}

		public void Create(Employees v)
		{
			using(ITransaction tx = _session.BeginTransaction())
			{
				try
				{
					_session.Save(v);
					tx.Commit();
				}
				catch
				{
					tx.Rollback();
					throw;
				}
			}
		}

		public Employees Read(int employeeId)
		{
			return _session.Get<Employees>(employeeId);
		}

		public void Update(Employees v)
		{
			using(ITransaction tx = _session.BeginTransaction())
			{
				try
				{
					_session.Update(v);
					tx.Commit();
				}
				catch
				{
					tx.Rollback();
					throw;
				}
			}
		}

		public void Delete(Employees v)
		{
			using(ITransaction tx = _session.BeginTransaction())
			{
				try
				{
					_session.Delete(v);
					tx.Commit();
				}
				catch
				{
					tx.Rollback();
					throw;
				}
			}
		}

		public IQueryable<Employees> Search(string lastName, string firstName, string title)
		{
			return from v in _session.Linq<Employees>()
			       where v.LastName == lastName
			             && v.FirstName == firstName
			             && v.Title == title
			       select v;
		}
	}
}
