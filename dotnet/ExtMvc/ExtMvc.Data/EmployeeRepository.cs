using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class EmployeeRepository : IRepository
	{
		private readonly ISessionFactory _northwind;


		public EmployeeRepository(ISessionFactory northwind)
		{
			_northwind = northwind;
		}

		public void Create(Employee v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public Employee Read(int employeeId)
		{
			return _northwind.GetCurrentSession().Load<Employee>(employeeId);
		}

		public void Update(Employee v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(Employee v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<Employee> SearchNormal()
		{
			IQueryable<Employee> queryable = _northwind.GetCurrentSession().Linq<Employee>();
			return new QueryablePresentableSet<Employee>(queryable);
		}
	}
}