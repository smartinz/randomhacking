using System;
using System.Web;
using log4net.Config;
using NHibernate;
using NHibernate.Cfg;

namespace SpikeWcf
{
	public class Global : HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			XmlConfigurator.Configure();
			AutoMapperConfiguration.Configure();
			SessionFactory = new Configuration().Configure().BuildSessionFactory();
		}

		static public ISessionFactory SessionFactory;

		protected void Session_Start(object sender, EventArgs e) {}

		protected void Application_BeginRequest(object sender, EventArgs e) {}

		protected void Application_AuthenticateRequest(object sender, EventArgs e) {}

		protected void Application_Error(object sender, EventArgs e) {}

		protected void Session_End(object sender, EventArgs e) {}

		protected void Application_End(object sender, EventArgs e) {}
	}
}