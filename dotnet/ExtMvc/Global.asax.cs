using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using ExtMvc.Cfg;
using ExtMvc.Infrastructure;
using Microsoft.Web.Mvc;
using MvcContrib.Castle;

namespace ExtMvc
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

		protected void Application_Start()
		{
			var windsorContainer = new WindsorContainer();
			windsorContainer.Install(new GlobalWindsorInstaller());
			windsorContainer.Install(new PresentationWindsorInstaller());
			ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(windsorContainer));

			AreaRegistration.RegisterAllAreas();
			RegisterRoutes(RouteTable.Routes);
			ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());
		}
	}
}