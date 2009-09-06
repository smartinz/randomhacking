using System;
using System.Reflection;
using System.Text;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using NUnit.Framework;

namespace SpikeDynamicProxy
{
	[TestFixture]
	public class Class1
	{
		private static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();

		public class Class
		{
			public virtual string StringProperty { get; set; }
			public virtual string StringMethod(string parameter)
			{
				return "";
			}
		}

		public class ClassInterceptor : IInterceptor
		{
			public StringBuilder Sb = new StringBuilder();
 
			public void Intercept(IInvocation invocation)
			{
				Sb.Append(invocation.Method.Name);
				Sb.AppendLine();
			}
		} 

		[Test]
		public void tt()
		{
			var interceptor = new ClassInterceptor();
			var instance = ProxyGenerator.CreateClassProxy<Class>(interceptor);

			instance.StringProperty = "value";
			string value = instance.StringProperty;
			value = instance.StringMethod(value);

			string expected = @"
set_StringProperty
get_StringProperty
StringMethod
".TrimStart('\n', '\r');

			string actual = interceptor.Sb.ToString();
			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}