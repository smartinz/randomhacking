using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net.Config;
using NHibernate;
using NHibernate.Cfg;

namespace ExtMvc
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : HttpApplication
	{
		private static ISessionFactory _sessionFactory;

		public static ISession CurrentSession
		{
			get { return (ISession) HttpContext.Current.Items["current.session"]; }
			set { HttpContext.Current.Items["current.session"] = value; }
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new {controller = "Home", action = "Index", id = ""} // Parameter defaults
				);
		}

		protected void Application_Start()
		{
			RegisterRoutes(RouteTable.Routes);
			XmlConfigurator.Configure();
			_sessionFactory = new Configuration().Configure().BuildSessionFactory();
		}


		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			CurrentSession = _sessionFactory.OpenSession();
		}

		protected void Application_EndRequest(object sender, EventArgs e)
		{
			if (CurrentSession != null)
			{
				CurrentSession.Dispose();
			}
		}
	}
}