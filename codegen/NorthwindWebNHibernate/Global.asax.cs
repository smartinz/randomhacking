using System;
using System.Web;
using log4net.Config;
using NHibernate;
using NHibernate.Cfg;

namespace NorthwindWebNHibernate
{
	public class Global : HttpApplication
	{
		static private ISessionFactory _sessionFactory;

		static public ISession CurrentSession
		{
			get { return (ISession)HttpContext.Current.Items["current.session"]; }
			private set { HttpContext.Current.Items["current.session"] = value; }
		}

		protected void Application_Start(object sender, EventArgs e)
		{
			XmlConfigurator.Configure();
			_sessionFactory = new Configuration().Configure().BuildSessionFactory();
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			CurrentSession = _sessionFactory.OpenSession();
		}

		protected void Application_EndRequest(object sender, EventArgs e)
		{
			if(CurrentSession != null)
			{
				CurrentSession.Dispose();
			}
		}

		protected void Session_Start(object sender, EventArgs e) {}

		protected void Application_AuthenticateRequest(object sender, EventArgs e) {}

		protected void Application_Error(object sender, EventArgs e) {}

		protected void Session_End(object sender, EventArgs e) {}

		protected void Application_End(object sender, EventArgs e) {}
	}
}