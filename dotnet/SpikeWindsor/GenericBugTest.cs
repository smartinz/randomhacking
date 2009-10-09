using Castle.MicroKernel.Resolvers;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using NUnit.Framework;

namespace SpikeWindsor
{
	[TestFixture]
	public class GenericBugTest
	{
		[Test]
		public void This_test_fail()
		{
			var exception = Assert.Throws<DependencyResolverException>(() => new WindsorContainer(new XmlInterpreter("GenericsWithStrings.xml")));
			Assert.That(exception.Message, Is.EqualTo("Key invalid for parameter key. Thus the kernel was unable to override the service dependency"));
		}

		[Test]
		public void This_test_succeed()
		{
			var container = new WindsorContainer(new XmlInterpreter("GenericsWithComponents.xml"));
			Assert.That(container.Resolve<TypeWith2Generics<string, string>>("typewith2generics"), Is.Not.Null);
		}
	}

	public class TypeWith2Generics<TKey, TValue>
	{
		private readonly TKey _key;
		private readonly TValue _value;

		public TypeWith2Generics(TKey key, TValue value)
		{
			_key = key;
			_value = value;
		}
	}

	public class Component {}
}