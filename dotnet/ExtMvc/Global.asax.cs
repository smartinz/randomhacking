using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Castle.Facilities.FactorySupport;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.Services.Logging.Log4netIntegration;
using Castle.Windsor;
using ExtMvc.Controllers;
using ExtMvc.Data;
using ExtMvc.Infrastructure;
using log4net.Config;
using Microsoft.Web.Mvc;
using MvcContrib.Castle;
using NHibernate;
using NHibernate.Context;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;
using SpikeWcf;

namespace ExtMvc
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : HttpApplication
	{
		private static IWindsorContainer _ioc;

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
			_ioc = new WindsorContainer();
			_ioc.AddFacility<FactorySupportFacility>();
			_ioc.AddFacility("logging", new LoggingFacility(typeof(Log4NetLoggerFactory).AssemblyQualifiedName, ""));

			var validatorEngine = new ValidatorEngine();
			validatorEngine.Configure();
			_ioc.Register(Component.For<ValidatorEngine>().Instance(validatorEngine));

			NHibernate.Cfg.Configuration nhCfg = new NHibernate.Cfg.Configuration().Configure();
			nhCfg.Initialize(validatorEngine);
			ISessionFactory sessionFactory = nhCfg.BuildSessionFactory();
			_ioc.Register(Component.For<ISessionFactory>().Instance(sessionFactory));

			IMappingEngine mappingEngine = AutoMapperConfiguration.BuildMappingEngine();
			_ioc.Register(Component.For<IMappingEngine>().Instance(mappingEngine));

			_ioc.Register(Component.For<IConversation>().ImplementedBy<Conversation>());
			_ioc.Register(Component.For<CustomerRepository>().ImplementedBy<CustomerRepository>());

			_ioc.RegisterControllers(typeof(CustomerController).Assembly);
			ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_ioc));

			AreaRegistration.RegisterAllAreas();
			RegisterRoutes(RouteTable.Routes);
			ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			var sessionFactory = _ioc.Resolve<ISessionFactory>();
			ISession session = sessionFactory.OpenSession();
			session.FlushMode = FlushMode.Commit;
			session.BeginTransaction();
			ManagedWebSessionContext.Bind(HttpContext.Current, session);
		}

		protected void Application_EndRequest(object sender, EventArgs e)
		{
			var sessionFactory = _ioc.Resolve<ISessionFactory>();
			ISession session = ManagedWebSessionContext.Unbind(HttpContext.Current, sessionFactory);
			if(session != null)
			{
				var conversation = _ioc.Resolve<IConversation>();
				if(session.Transaction != null && session.Transaction.IsActive)
				{
					if(conversation.Accept)
					{
						session.Transaction.Commit();
					}
					else
					{
						session.Transaction.Rollback();
					}
				}
				session.Close();
			}
		}

		#region Nested type: Log4NetLoggerFactory

		public class Log4NetLoggerFactory : Log4netFactory
		{
			public Log4NetLoggerFactory()
			{
				XmlConfigurator.Configure();
			}
		}

		#endregion
	}
}