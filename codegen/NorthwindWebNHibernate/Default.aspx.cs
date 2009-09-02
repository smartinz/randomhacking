using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using NHibernate.Linq;
using NorthwindWebNHibernate.Business;

namespace NorthwindWebNHibernate
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var r = from c in Global.CurrentSession.Linq<Customers>() 
					where c.CustomerId == "ALFKI"
					select c;
			List<Customers> customerses = r.ToList();
		}
	}
}