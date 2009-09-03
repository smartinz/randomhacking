using System.Linq;
using NHibernate;
using NHibernate.Linq;
using NorthwindWebNHibernate.Business;

namespace NorthwindWebNHibernate.Data
{
	public class EmployeesRepository
	{
		private readonly Context _context;

		public EmployeesRepository(Context context)
		{
			_context = context;
		}

		public void Create(Employees v)
		{
			using(ITransaction tx = _context.NorthwindDatabase.BeginTransaction())
			{
				try
				{
					_context.NorthwindDatabase.Save(v);
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
			return _context.NorthwindDatabase.Get<Employees>(employeeId);
		}

		public void Update(Employees v)
		{
			using(ITransaction tx = _context.NorthwindDatabase.BeginTransaction())
			{
				try
				{
					_context.NorthwindDatabase.Update(v);
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
			using(ITransaction tx = _context.NorthwindDatabase.BeginTransaction())
			{
				try
				{
					_context.NorthwindDatabase.Delete(v);
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
			return from v in _context.NorthwindDatabase.Linq<Employees>()
			       where v.LastName == lastName
			             && v.FirstName == firstName
			             && v.Title == title
			       select v;
		}
	}
}