using System;
using System.IO;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using NUnit.Framework;

namespace SpikeWindsor
{
	[TestFixture]
	public class GenericBugTest
	{
		[Test]
		public void Two_strings()
		{
			const string content = @"<?xml version='1.0' encoding='utf-8' ?>
<configuration>
	<components>
		<component id='typewith2generics' type='SpikeWindsor.TypeWith2Generics`2[[System.String], [System.String]], SpikeWindsor'>
			<parameters>
				<key>string value</key>
				<value>string value 2</value>
			</parameters>
		</component>
	</components>
</configuration>
";
			string fileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
			File.WriteAllText(fileName, content);
			var container = new WindsorContainer(new XmlInterpreter(fileName));
			var generics = container.Resolve<TypeWith2Generics<string, string>>("typewith2generics");
			Assert.That(generics.Key, Is.EqualTo("string value"));
			Assert.That(generics.Value, Is.EqualTo("string value 2"));
		}

		[Test]
		public void String_and_component()
		{
			const string content = @"<?xml version='1.0' encoding='utf-8' ?>
<configuration>
	<components>
		<component id='typewith2generics' type='SpikeWindsor.TypeWith2Generics`2[[System.String], [SpikeWindsor.Component, SpikeWindsor]], SpikeWindsor'>
			<parameters>
				<key>string value</key>
				<value>${component}</value>
			</parameters>
		</component>
		<component id='component' type='SpikeWindsor.Component, SpikeWindsor' />
	</components>
</configuration>
";
			string fileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
			File.WriteAllText(fileName, content);
			var container = new WindsorContainer(new XmlInterpreter(fileName));
			var generics = container.Resolve<TypeWith2Generics<string, Component>>("typewith2generics");
			Assert.That(generics.Key, Is.EqualTo("string value"));
			Assert.That(generics.Value, Is.InstanceOf(typeof(Component)));
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

		public TKey Key
		{
			get { return _key; }
		}

		public TValue Value
		{
			get { return _value; }
		}
	}

	public class Component {}
}