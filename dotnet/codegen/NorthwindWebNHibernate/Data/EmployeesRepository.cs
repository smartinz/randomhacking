namespace NorthwindWebNHibernate.Data
{
	public class EmployeesRepository
	{
		private NorthwindWebNHibernate.Context _context;
		
		public EmployeesRepository(NorthwindWebNHibernate.Context context)
		{
			_context = context;
		}
		
		public void Create(NorthwindWebNHibernate.Business.Employees v)
		{
			using(NHibernate.ITransaction tx = _context.NorthwindDbo.BeginTransaction())
			{
				try
				{
					_context.NorthwindDbo.Save(v);
					tx.Commit();
				}
				catch
				{
					tx.Rollback();
					throw;
				}
			}
		}

		public NorthwindWebNHibernate.Business.Employees Read(int EmployeeId)
		{
			return _context.NorthwindDbo.Get<NorthwindWebNHibernate.Business.Employees>(EmployeeId);
		}

		public void Update(NorthwindWebNHibernate.Business.Employees v)
		{
			using(NHibernate.ITransaction tx = _context.NorthwindDbo.BeginTransaction())
			{
				try
				{
					_context.NorthwindDbo.Update(v);
					tx.Commit();
				}
				catch
				{
					tx.Rollback();
					throw;
				}
			}
		}

		public void Delete(NorthwindWebNHibernate.Business.Employees v)
		{
			using (NHibernate.ITransaction tx = _context.NorthwindDbo.BeginTransaction())
			{
				try
				{
					_context.NorthwindDbo.Delete(v);
					tx.Commit();
				}
				catch
				{
					tx.Rollback();
					throw;
				}
			}
		}

				public System.Collections.Generic.IEnumerable<NorthwindWebNHibernate.Business.Employees> Search(int employeeId, string lastName, string firstName, string title, string titleOfCourtesy, System.DateTime? birthDate, System.DateTime? hireDate, string address, string city, string region, string postalCode, string country, string homePhone, string extension, string notes, string photoPath, NorthwindWebNHibernate.Business.Employees fkEmployeesEmployees)
				{
					return _context.NorthwindDbo.CreateCriteria<NorthwindWebNHibernate.Business.Employees>()
									.Add(NHibernate.Criterion.Restrictions.Eq("employeeId", employeeId))
												.Add(NHibernate.Criterion.Restrictions.Eq("lastName", lastName))
												.Add(NHibernate.Criterion.Restrictions.Eq("firstName", firstName))
												.Add(NHibernate.Criterion.Restrictions.Eq("title", title))
												.Add(NHibernate.Criterion.Restrictions.Eq("titleOfCourtesy", titleOfCourtesy))
												.Add(NHibernate.Criterion.Restrictions.Eq("birthDate", birthDate))
												.Add(NHibernate.Criterion.Restrictions.Eq("hireDate", hireDate))
												.Add(NHibernate.Criterion.Restrictions.Eq("address", address))
												.Add(NHibernate.Criterion.Restrictions.Eq("city", city))
												.Add(NHibernate.Criterion.Restrictions.Eq("region", region))
												.Add(NHibernate.Criterion.Restrictions.Eq("postalCode", postalCode))
												.Add(NHibernate.Criterion.Restrictions.Eq("country", country))
												.Add(NHibernate.Criterion.Restrictions.Eq("homePhone", homePhone))
												.Add(NHibernate.Criterion.Restrictions.Eq("extension", extension))
												.Add(NHibernate.Criterion.Restrictions.Eq("notes", notes))
												.Add(NHibernate.Criterion.Restrictions.Eq("photoPath", photoPath))
												.Add(NHibernate.Criterion.Restrictions.Eq("fkEmployeesEmployees", fkEmployeesEmployees))
								
						.List<NorthwindWebNHibernate.Business.Employees>();
				}
				
	}
}
