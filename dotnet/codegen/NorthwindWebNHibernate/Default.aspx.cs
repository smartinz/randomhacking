using System;
using System.Linq;
using System.Web.UI;
using NorthwindWebNHibernate.Business;
using NorthwindWebNHibernate.Data;

namespace NorthwindWebNHibernate
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var employeesRepository = new EmployeesRepository(new Context());
			IQueryable<Employees> employeeses = employeesRepository.Search("Davolio", "Nancy", "Sales Representative");
		}
	}
}