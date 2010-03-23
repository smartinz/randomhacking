using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Castle.Windsor;
using NUnit.Framework;

namespace WindsorLoggingFacilitySpike
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void Works()
		{
			var ioc = new WindsorContainer();
			ioc.AddFacility("logging", new LoggingFacility(LoggerImplementation.Log4net, "log4net.cfg.xml"));
			var factory = ioc.Resolve<ILoggerFactory>();
			factory.Create(typeof(Test)).Info("Works!");
		}
	}
}