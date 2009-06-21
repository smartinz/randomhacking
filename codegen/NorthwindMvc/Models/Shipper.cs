using System;
using System.Xml.Serialization;

namespace NorthwindWeb.Business
{
    [Serializable]
    [XmlType(Namespace = "http://www.northwind.com")]
    public class Shipper
    {
        public int ShipperID { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }

        public override string ToString()
        {
            return string.Format("Shipper.ShipperID={0}", ShipperID);
        }
    }
}