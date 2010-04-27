using Castle.Facilities.FactorySupport;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ExtMvc.Infrastructure;
using Newtonsoft.Json;
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
			container.Register(Component.For<IWindsorContainer>().Instance(container));

			container.Register(Component.For<ISessionFactory>().UsingFactoryMethod(() => new Configuration().Configure().BuildSessionFactory()),
			                   Component.For<ISession>().UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession()).LifeStyle.PerWebRequest);

			container.Register(Component.For<JsonSerializerSettingsBuilder>());


			container.Register(Component.For<CategoryStringConverter>().LifeStyle.Transient);

			container.Register(Component.For<JsonConverter>().ImplementedBy<CategoryJsonConverter>());


			container.Register(Component.For<CustomerDemographicStringConverter>().LifeStyle.Transient);

			container.Register(Component.For<JsonConverter>().ImplementedBy<CustomerDemographicJsonConverter>());


			container.Register(Component.For<CustomerStringConverter>().LifeStyle.Transient);

			container.Register(Component.For<JsonConverter>().ImplementedBy<CustomerJsonConverter>());


			container.Register(Component.For<EmployeeStringConverter>().LifeStyle.Transient);

			container.Register(Component.For<JsonConverter>().ImplementedBy<EmployeeJsonConverter>());


			container.Register(Component.For<OrderDetailStringConverter>().LifeStyle.Transient);

			container.Register(Component.For<JsonConverter>().ImplementedBy<OrderDetailJsonConverter>());


			container.Register(Component.For<OrderStringConverter>().LifeStyle.Transient);

			container.Register(Component.For<JsonConverter>().ImplementedBy<OrderJsonConverter>());


			container.Register(Component.For<ProductStringConverter>().LifeStyle.Transient);

			container.Register(Component.For<JsonConverter>().ImplementedBy<ProductJsonConverter>());


			container.Register(Component.For<RegionStringConverter>().LifeStyle.Transient);

			container.Register(Component.For<JsonConverter>().ImplementedBy<RegionJsonConverter>());


			container.Register(Component.For<ShipperStringConverter>().LifeStyle.Transient);

			container.Register(Component.For<JsonConverter>().ImplementedBy<ShipperJsonConverter>());


			container.Register(Component.For<SupplierStringConverter>().LifeStyle.Transient);

			container.Register(Component.For<JsonConverter>().ImplementedBy<SupplierJsonConverter>());


			container.Register(Component.For<SysdiagramStringConverter>().LifeStyle.Transient);

			container.Register(Component.For<JsonConverter>().ImplementedBy<SysdiagramJsonConverter>());


			container.Register(Component.For<TerritoryStringConverter>().LifeStyle.Transient);

			container.Register(Component.For<JsonConverter>().ImplementedBy<TerritoryJsonConverter>());
		}

		#endregion
	}
}