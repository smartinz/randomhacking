using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using NUnit.Framework;

namespace SpikeWindsor
{
	public interface IStringProvider
	{
		string GetString();
	}

	public class StringProvider : IStringProvider
	{
		private readonly string _stringField;

		public StringProvider(string stringField)
		{
			_stringField = stringField;
		}

		#region IStringProvider Members

		public string GetString()
		{
			return _stringField;
		}

		#endregion
	}

	public class StringProviderWrapper
	{
		private readonly IStringProvider _stringProvider;

		public StringProviderWrapper(IStringProvider stringProvider)
		{
			_stringProvider = stringProvider;
		}

		public IStringProvider StringProvider
		{
			get { return _stringProvider; }
		}
	}

	[TestFixture]
	public class WindsorTest
	{
		WindsorContainer _container;

		[SetUp]
		public void SetUp()
		{
			_container = new WindsorContainer(new XmlInterpreter());
		}

		[Test]
		public void Should_create_object_graph_based_on_application_configuration_file()
		{
			Assert.That(_container.Resolve<IStringProvider>(), Is.TypeOf(typeof(StringProvider)));
			Assert.That(_container.Resolve<IStringProvider>().GetString(), Is.EqualTo("Value from config file"));
			Assert.That(_container.Resolve<StringProviderWrapper>(), Is.TypeOf(typeof(StringProviderWrapper)));
			Assert.That(_container.Resolve<StringProviderWrapper>().StringProvider.GetString(), Is.EqualTo("Value from config file"));
		}

		[Test]
		public void Should_use_provided_parameters_to_override_configuration_file()
		{
			Assert.That(_container.Resolve<IStringProvider>(new { stringField = "Overridden value" }).GetString(), Is.EqualTo("Overridden value"));
		}

	}
}