using System;
using System.Collections.Generic;
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
			var exception = new Exception("Exception");
			msd.AddModelError("item.Property", exception);

			PropertyError pe = ValidationManager.MakeHierarchical(msd);
	
			Assert.That(pe["item"]["Property"].Errors[0].ErrorMessage, Is.EqualTo("Error"));
			Assert.That(pe["item"]["Property"].Errors[1].Exception, Is.SameAs(exception));

			dynamic d = ValidationManager.BuildDictionary(pe);
	
			Assert.That(d["item"]["Property"], Is.EqualTo("Error. Exception"));
		}

		[Test]
		public void Array_property_with_errors()
		{
			var msd = new ModelStateDictionary();
			msd.AddModelError("item.Property[0].SubProperty", "Error1");
			msd.AddModelError("item.Property[1].SubProperty", "Error2");

			PropertyError pe = ValidationManager.MakeHierarchical(msd);
	
			Assert.That(pe["item"]["Property"][0]["SubProperty"].BuildMessage(), Is.EqualTo("Error1"));
			Assert.That(pe["item"]["Property"][1]["SubProperty"].BuildMessage(), Is.EqualTo("Error2"));

			dynamic d = ValidationManager.BuildDictionary(pe);
	
			Assert.That(d["item"]["Property"][0]["SubProperty"], Is.EqualTo("Error1"));
			Assert.That(d["item"]["Property"][1]["SubProperty"], Is.EqualTo("Error2"));
		}
	}
}