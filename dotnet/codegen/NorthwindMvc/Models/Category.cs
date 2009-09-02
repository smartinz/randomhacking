using System;
using System.Xml.Serialization;

namespace NorthwindWeb.Business
{
    [Serializable]
    [XmlType(Namespace = "http://www.northwind.com")]
    public class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format("Category.CategoryID={0}", CategoryID);
        }
    }
}