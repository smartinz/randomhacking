using Castle.Facilities.FactorySupport;
using Castle.Facilities.Logging;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;

namespace ExtMvc.Cfg
{
	public class GlobalWindsorInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.AddFacility<FactorySupportFacility>();
			container.AddFacility("logging", new LoggingFacility(LoggerImplementation.Log4net, "log4net.cfg.xml"));

			container.Register(Component.For<ValidatorEngine>().UsingFactoryMethod(CreateValidatorEngine));

			container.Register(Component.For<ISessionFactory>().UsingFactoryMethod(CreateSessionFactory),
			                   Component.For<ISession>().UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession()).LifeStyle.PerWebRequest);
		}

		private static ValidatorEngine CreateValidatorEngine()
		{
			var validatorEngine = new ValidatorEngine();
			validatorEngine.Configure();
			return validatorEngine;
		}

		private static ISessionFactory CreateSessionFactory(IKernel kernel)
		{
			Configuration cfg = new Configuration().Configure();
			cfg.Initialize(kernel.Resolve<ValidatorEngine>());
			return cfg.BuildSessionFactory();
		}
	}
}