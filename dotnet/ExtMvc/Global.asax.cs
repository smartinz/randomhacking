using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Castle.Facilities.FactorySupport;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Conversation;
using Conversation.NHibernate;
using ExtMvc.Controllers;
using ExtMvc.Data;
using ExtMvc.Domain;
using log4net.Config;
using Microsoft.Web.Mvc;
using MvcContrib.Castle;
using NHibernate;
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
			XmlConfigurator.Configure();
			_ioc = new WindsorContainer();
			_ioc.AddFacility<FactorySupportFacility>();

			_ioc.Register(Component.For<ValidatorEngine>().UsingFactoryMethod(CreateValidatorEngine));

			_ioc.Register(Component.For<ISessionFactory>().UsingFactoryMethod(CreateSessionFactory));

			IMappingEngine mappingEngine = AutoMapperConfiguration.BuildMappingEngine();
			_ioc.Register(Component.For<IMappingEngine>().Instance(mappingEngine));

			_ioc.Register(Component.For<IConversationFactory>().UsingFactoryMethod(CreateConversationFactory));
			_ioc.Register(Component.For<IConversation>().UsingFactoryMethod(CreateConversation).LifeStyle.PerWebRequest);
			_ioc.Register(Component.For<CustomerRepository>());
			_ioc.Register(Component.For<OrderRepository>());

			_ioc.RegisterControllers(typeof(CustomerController).Assembly);
			ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_ioc));

			AreaRegistration.RegisterAllAreas();
			RegisterRoutes(RouteTable.Routes);
			ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());
		}

		private static ValidatorEngine CreateValidatorEngine()
		{
			var validatorEngine = new ValidatorEngine();
			validatorEngine.Configure();
			return validatorEngine;
		}

		private static ISessionFactory CreateSessionFactory(IKernel kernel)
		{
			var validatorEngine = kernel.Resolve<ValidatorEngine>();
			NHibernate.Cfg.Configuration nhCfg = new NHibernate.Cfg.Configuration().Configure()
				.SetProperty(NHibernate.Cfg.Environment.CurrentSessionContextClass, typeof(ConversationSessionContext).AssemblyQualifiedName)
				.AddAssembly(typeof(Customer).Assembly);
			ValidatorInitializer.Initialize(nhCfg, validatorEngine);
			return nhCfg.BuildSessionFactory();
		}

		private static IConversationFactory CreateConversationFactory(IKernel kernel)
		{
			return new NHibernateConversationFactory(kernel.ResolveAll<ISessionFactory>());
		}

		private static IConversation CreateConversation(IKernel kernel)
		{
			return kernel.Resolve<IConversationFactory>().Open();
		}
	}
}