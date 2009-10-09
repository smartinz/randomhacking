using System;
using System.Collections;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
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

		public string GetString()
		{
			return _stringField;
		}
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
		[SetUp]
		public void SetUp() {}

		[Test]
		public void Should_create_object_graph_based_on_application_configuration_file()
		{
			var container = new WindsorContainer(new XmlInterpreter());
			Assert.That(container.Resolve<IStringProvider>(), Is.TypeOf(typeof(StringProvider)));
			Assert.That(container.Resolve<IStringProvider>().GetString(), Is.EqualTo("Value from config file"));
			Assert.That(container.Resolve<StringProviderWrapper>(), Is.TypeOf(typeof(StringProviderWrapper)));
			Assert.That(container.Resolve<StringProviderWrapper>().StringProvider.GetString(), Is.EqualTo("Value from config file"));
		}

		[Test]
		public void Should_use_provided_instance()
		{
			var container = new WindsorContainer(/*new XmlInterpreter()*/); // http://geekswithblogs.net/zgeers/archive/2008/08/22/124621.aspx
			var stringProvider = new StringProvider("provided instance");
//			container.Kernel.AddComponentInstance<IStringProvider>(stringProvider);
//			container.Register(Component.For<IStringProvider>().Instance(stringProvider));

			Assert.That(container.Resolve<IStringProvider>(), Is.SameAs(stringProvider));
		}

		[Test]
		public void Should_use_provided_parameters_to_override_configuration_file()
		{
			var container = new WindsorContainer(new XmlInterpreter());
			Assert.That(container.Resolve<IStringProvider>(new{ stringField = "Overridden value" }).GetString(), Is.EqualTo("Overridden value"));
			Assert.That(container.Resolve<StringProviderWrapper>(new{ stringField = "Overridden value" }).StringProvider.GetString(), Is.EqualTo("Overridden value"));
		}

		[Test]
		public void Should_resolve_generic_lists()
		{
			var container = new WindsorContainer(new XmlInterpreter("Array.xml"));
			var providers = container.Resolve<List<IStringProvider>>();
			Assert.That(providers.Count, Is.EqualTo(3));
		}

	}
}