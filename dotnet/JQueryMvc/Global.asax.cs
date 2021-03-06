﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net.Config;
using Microsoft.Web.Mvc;
using NHibernate;
using NHibernate.Cfg;

namespace JQueryMvc
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new{ controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
				);
		}

		static public ISessionFactory SessionFactory;
		
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RegisterRoutes(RouteTable.Routes);
			ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());

			XmlConfigurator.Configure();
			SessionFactory = new Configuration().Configure().BuildSessionFactory();
		}
	}
}