﻿using System;
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
			var employeeses = employeesRepository.Search("Davolio", "Nancy", "Sales Representative");

			employeesRepository = new EmployeesRepository(new Context());
			employeeses = employeesRepository.Search("Davolio", "Nancy", "Sales Representative");
		}
	}
}