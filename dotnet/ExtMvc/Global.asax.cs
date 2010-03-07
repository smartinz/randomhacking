using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using log4net.Config;
using NHibernate;
using NHibernate.Cfg;

namespace ExtMvc
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class Global : HttpApplication
	{
		public static IWindsorContainer Ioc { get; private set; }

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new{controller = "Home", action = "Index", id = ""} // Parameter defaults
				);
		}

		protected void Application_Start()
		{
			RegisterRoutes(RouteTable.Routes);

			XmlConfigurator.Configure();

			Ioc = new WindsorContainer();
			Ioc.Install(new WindsorInstaller());
		}


		protected void Application_BeginRequest(object sender, EventArgs e)
		{
//			CurrentSession = _sessionFactory.OpenSession();
		}

		protected void Application_EndRequest(object sender, EventArgs e)
		{
//			if (CurrentSession != null)
//			{
//				CurrentSession.Dispose();
//			}
		}
	}
}