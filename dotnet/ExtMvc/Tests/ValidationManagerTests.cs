using System;
using System.Web.Mvc;
using ExtMvc.Infrastructure;
using NUnit.Framework;

namespace ExtMvc.Tests
{
	[TestFixture]
	public class ValidationManagerTests
	{
		[Test]
		public void Multiple_errors_on_the_same_property()
		{
			var msd = new ModelStateDictionary();
			msd.AddModelError("item.Property", "Error");
			msd.AddModelError("item.Property", new Exception("Exception"));
			PropertyError dictionary = ValidationManager.MakeHierarchical(msd);
			Assert.That(dictionary["item"]["Property"].BuildMessage(), Is.EqualTo("Error. Exception"));
		}

		[Test]
		public void Array_property_with_errors()
		{
			var msd = new ModelStateDictionary();
			msd.AddModelError("item.Property[0].SubProperty", "Error1");
			msd.AddModelError("item.Property[1].SubProperty", "Error2");
			PropertyError dictionary = ValidationManager.MakeHierarchical(msd);
			Assert.That(dictionary["item"]["Property"][0]["SubProperty"].BuildMessage(), Is.EqualTo("Error1"));
			Assert.That(dictionary["item"]["Property"][1]["SubProperty"].BuildMessage(), Is.EqualTo("Error2"));
		}
	}
}