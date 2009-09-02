using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;
using NHibernate.Linq;
using NorthwindWebNHibernate.Business;

namespace NorthwindWebNHibernate
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			IQueryable<Customers> r = from c in Global.CurrentSession.Linq<Customers>() 
//					where c.CustomerId == "ALFKI"
					select c;
			List<Customers> customerses = r.Skip(1).Take(1).ToList();
		}
	}
}