using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using NUnit.Framework;

namespace SpikeWindsor
{
	public interface IClass2
	{
		void Method();
	}

	public class Class2 : IClass2
	{
		private readonly string _stringField;

		public Class2(string stringField)
		{
			_stringField = stringField;
		}

		#region IClass2 Members

		public void Method() {}

		#endregion
	}

	public class Class1
	{
		private readonly IClass2 _class2;

		public Class1(IClass2 class2)
		{
			_class2 = class2;
		}
	}

	[TestFixture]
	public class WindsorTest
	{
		// http://www.castleproject.org/container/gettingstarted/index.html

		[Test]
		public void tt()
		{
			var container = new WindsorContainer(new XmlInterpreter());
			var class2 = container.Resolve<IClass2>();
			var class1 = container.Resolve<Class1>();
		}
	}
}