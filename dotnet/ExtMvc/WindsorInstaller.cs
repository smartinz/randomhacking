using System;
using Castle.Facilities.FactorySupport;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NHibernate;
using NHibernate.Cfg;

namespace ExtMvc
{
	public class WindsorInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.AddFacility<FactorySupportFacility>();
			container.Register(Component.For<ISessionFactory>().UsingFactoryMethod(() => new Configuration().Configure().BuildSessionFactory()),
			                   Component.For<Disposable>().LifeStyle.Transient,
							   Component.For<WithDisposableDependency>().LifeStyle.PerWebRequest,
			                   Component.For<ISession>().UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession()).LifeStyle.PerWebRequest); // TODO this is likely a memory leak
		}

		#endregion
	}

	public class WithDisposableDependency
	{
		private readonly Disposable _disposable;

		public WithDisposableDependency(Disposable disposable)
		{
			_disposable = disposable;
		}
	}

	public class Disposable : IDisposable
	{
		#region IDisposable Members

		public void Dispose()
		{
			int i = 0;
		}

		#endregion
	}
}