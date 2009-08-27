using System.Collections.Generic;
using NUnit.Framework;
using OptionParser;

namespace OptionParset.Tests
{
	[TestFixture]
	public class OptionsTest
	{
		[Test]
		public void Should_parse_options()
		{
			string arg1 = null, arg2 = null, arg3 = null;
			var o = new Options{
				{ "arg1", "Argument 1", v => arg1 = v },
				{ "arg2", "Argument 2", v => arg2 = v },
				{ "arg3", "Argument 3", v => arg3 = v }
			};
			bool malformedArgumentActionCalled = false;
			o.MalformedArgumentAction = delegate(string v) {
				Assert.That(v, Is.EqualTo("malformed"));
				malformedArgumentActionCalled = true;
			};
			IDictionary<string, string> unmatchedParameters = o.Parse(new[]{ "--arg1=val1", "-arg2=val2", "/arg3:val3", "malformed", "-unmatched=val4" });

			Assert.That(arg1, Is.EqualTo("val1"));
			Assert.That(arg2, Is.EqualTo("val2"));
			Assert.That(arg3, Is.EqualTo("val3"));
			Assert.That(unmatchedParameters.Count, Is.EqualTo(1));
			Assert.That(unmatchedParameters["unmatched"], Is.EqualTo("val4"));
			Assert.That(malformedArgumentActionCalled, Is.True);
		}

		[Test]
		public void Should_generate_help_string()
		{
			var o = new Options{
				{ "arg1", "Argument 1", v => v.ToString() },
				{ "arg2", "Argument 2", v => v.ToString() },
				{ "arg3", "Argument 3", v => v.ToString() }
			};
			var expected = @"
arg1	Argument 1
arg2	Argument 2
arg3	Argument 3
".TrimStart('\r', '\n');
			Assert.That(o.ToString(), Is.EqualTo(expected));
		}
	}
}