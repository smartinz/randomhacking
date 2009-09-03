using System;
using System.Linq;
using System.Web;

namespace NorthwindWebNHibernate
{
	public class Global : HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e) {}

		protected void Application_EndRequest(object sender, EventArgs e)
		{
			// needed to dispose NHibernate sessions
			string[] keys = HttpContext.Current.Items.Keys.Cast<object>().Select(k => k.ToString()).Where(k => k.EndsWith(".nhibernatesession")).ToArray();
			foreach(string key in keys)
			{
				((IDisposable)HttpContext.Current.Items[key]).Dispose();
			}
		}

		protected void Session_Start(object sender, EventArgs e) {}

		protected void Application_AuthenticateRequest(object sender, EventArgs e) {}

		protected void Application_Error(object sender, EventArgs e) {}

		protected void Session_End(object sender, EventArgs e) {}

		protected void Application_End(object sender, EventArgs e) {}
	}
}