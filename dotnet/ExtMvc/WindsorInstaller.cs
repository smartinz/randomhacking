using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NHibernate;

namespace ExtMvc
{
	public class WindsorInstaller : IWindsorInstaller
	{
		private readonly ISessionFactory _sessionFactory;

		public WindsorInstaller(ISessionFactory sessionFactory)
		{
			_sessionFactory = sessionFactory;
		}

		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(AllTypes.FromAssemblyContaining(typeof (WindsorInstaller)), // TODO this will register all classes as singletons!
			                   Component.For<ISessionFactory>().Instance(_sessionFactory),
			                   Component.For<ISession>().UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession()).LifeStyle.PerWebRequest); // TODO this is likely a memory leak
		}

		#endregion
	}
}