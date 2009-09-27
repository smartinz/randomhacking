using System;
using System.Collections.Generic;
using Antlr3.ST;
using NUnit.Framework;

namespace SpikeStringTemplate
{
	[TestFixture]
	public class Class1
	{
		[Test]
		public void CallingSubtemplate()
		{
			string actual = EvaluateFile("template", new Dictionary<string, object>{
				{ "field", "value" }
			});
			string expected = @"
Field: value

subtemplate Field: value
";
			Assert.That(actual, Is.EqualTo(expected));
		}

		public string EvaluateFile(string fileName, IDictionary<string, object> context)
		{
			var stringTemplateGroup = new StringTemplateGroup("group", AppDomain.CurrentDomain.BaseDirectory);
			stringTemplateGroup.ErrorListener = new StringTemplateErrorListener();
			StringTemplate stringTemplate = stringTemplateGroup.GetInstanceOf(fileName, context);
			return stringTemplate.ToString();
		}
	}

	public class StringTemplateErrorListener : IStringTemplateErrorListener
	{
		public void Error(string msg, Exception e)
		{
			throw new NotImplementedException();
		}

		public void Warning(string msg)
		{
			throw new NotImplementedException();
		}
	}
}