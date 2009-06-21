using System;
using System.Xml.Serialization;

namespace NorthwindWeb.Business
{
    [Serializable]
    [XmlType(Namespace = "http://www.northwind.com")]
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public float Discount { get; set; }

        public Product Product { get; set; }
    }
}