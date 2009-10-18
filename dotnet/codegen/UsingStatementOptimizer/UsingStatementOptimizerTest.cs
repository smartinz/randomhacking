using NUnit.Framework;

namespace UsingStatementOptimizer
{
	[TestFixture]
	public class UsingStatementOptimizerTest
	{
		[Test]
		public void Should_add_one_namespace_with_the_same_class_2_times()
		{
			var target = new UsingStatementOptimizer();
			Assert.That(target.ShortenName("BaseNs.Namespace.Class"), Is.EqualTo("Class"));
			Assert.That(target.ShortenName("BaseNs.Namespace.Class"), Is.EqualTo("Class"));
			string actual = TestUtils.DumpToString(target.GetViewData());
			const string expected = @"
0: BaseNs.Namespace
";
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void Should_add_one_namespace_with_2_classes_with_the_same_namespace()
		{
			var target = new UsingStatementOptimizer();
			Assert.That(target.ShortenName("BaseNs.Namespace.Class1"), Is.EqualTo("Class1"));
			Assert.That(target.ShortenName("BaseNs.Namespace.Class2"), Is.EqualTo("Class2"));
			string actual = TestUtils.DumpToString(target.GetViewData());
			const string expected = @"
0: BaseNs.Namespace
";
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void Should_maintain_part_of_the_namespace_with_different_class_with_the_same_name()
		{
			var target = new UsingStatementOptimizer();
			Assert.That(target.ShortenName("BaseNs.Namespace1.Class"), Is.EqualTo("Class"));
			Assert.That(target.ShortenName("BaseNs.Namespace2.Class"), Is.EqualTo("Namespace2.Class"));
			string actual = TestUtils.DumpToString(target.GetViewData());
			const string expected = @"
0: BaseNs.Namespace1
1: BaseNs
";
			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}