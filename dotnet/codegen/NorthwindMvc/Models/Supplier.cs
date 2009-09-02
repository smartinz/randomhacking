using System;
using System.Xml.Serialization;

namespace NorthwindWeb.Business
{
    [Serializable]
    [XmlType(Namespace = "http://www.northwind.com")]
    public class Supplier
    {
        public int SupplierID { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string HomePage { get; set; }

        public override string ToString()
        {
            return string.Format("Supplier.SupplierID={0}", SupplierID);
        }
    }
}