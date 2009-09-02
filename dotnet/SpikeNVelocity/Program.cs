using System.Collections.Generic;
using System.Diagnostics;

namespace SpikeNVelocity
{
	internal class Program
	{
		private static void Main()
		{
			string template = @"
From: $from
To: $to
Subject: $subject

Hello $customer.Name

$customer.Inner.La

We're please to yada yada yada.
".Trim('\n', '\r');

			var context = new Dictionary<string, object>{
				{ "from", "somewhere" },
				{ "to", "someone" },
				{ "subject", "Welcome to NVelocity" },
				{ "customer", new{ Inner = new{ La = "la" }, Name = "John Doe" } }
			};

			var evaluator = new NVelocityEvaluator();
			var actualResult = evaluator.Evaluate(template, context);
			var expectedResult = @"
From: somewhere
To: someone
Subject: Welcome to NVelocity

Hello John Doe

la

We're please to yada yada yada.
".Trim('\r', '\n');
			Debug.Assert(expectedResult == actualResult);
		}
	}
}