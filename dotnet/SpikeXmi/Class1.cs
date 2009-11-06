using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using System.Linq;
using System.Xml.XPath;

namespace SpikeXmi
{
	[TestFixture]
	public class Class1
	{
		[Test]
		public void TEST_NAME()
		{
			XmlReader xmlReader = XmlReader.Create("argouml.xmi");
			var namespaceManager = new XmlNamespaceManager(xmlReader.NameTable);
			string umlNs = "org.omg.xmi.namespace.UML";
			namespaceManager.AddNamespace("umlNs", umlNs);
			XDocument doc = XDocument.Load(xmlReader);
			XElement modelElement = doc.XPathSelectElement("XMI[@xmi.version='1.2'][XMI.header/XMI.metamodel/@xmi.name='UML'][XMI.header/XMI.metamodel/@xmi.version='1.4']/XMI.content/umlNs:Model", namespaceManager);
			var enumerable = modelElement.XPathSelectElements("//umlNs:Class[@xmi.id]", namespaceManager).ToList();

			Assert.That(modelElement, Is.Not.Null);

//				.Element("XMI").XPathSelectElement() .Element("")
//
//			if(doc.Root == null
//				|| doc.Root.Name != "XMI"
//				|| doc.Root.Attribute("xmi.version").Value == "1.2"
//				|| doc.Root.Element("XMI.header")
//			         	.Element("XMI").Attribute("xmi.version").Value == "1.2";
		}
	}
}