using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ExtMvc.Domain
{
	public class OrderDetail : IXmlSerializable
	{
		private int _orderId;

		private int _productId;


		public virtual int OrderId
		{
			get { return _orderId; }
			set { _orderId = value; }
		}

		public virtual int ProductId
		{
			get { return _productId; }
			set { _productId = value; }
		}

		public virtual decimal UnitPrice { get; set; }

		public virtual short Quantity { get; set; }

		public virtual float Discount { get; set; }

		public override string ToString()
		{
			return (_orderId == null ? "" : _orderId.ToString()) + " " + (_productId == null ? "" : _productId.ToString());
		}


		public virtual bool Equals(OrderDetail other)
		{
			if(ReferenceEquals(null, other))
			{
				return false;
			}
			if(ReferenceEquals(this, other))
			{
				return true;
			}
			if(OrderId != default(int) && ProductId != default(int))
			{
				return other.OrderId == OrderId && other.ProductId == ProductId;
			}
			return other.OrderId == OrderId && other.ProductId == ProductId && other.UnitPrice == UnitPrice && other.Quantity == Quantity && other.Discount == Discount;
		}

		public override bool Equals(object obj)
		{
			if(ReferenceEquals(null, obj))
			{
				return false;
			}
			if(ReferenceEquals(this, obj))
			{
				return true;
			}
			if(obj.GetType() != typeof(OrderDetail))
			{
				return false;
			}
			return Equals((OrderDetail)obj);
		}

		public static bool operator ==(OrderDetail left, OrderDetail right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(OrderDetail left, OrderDetail right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if(OrderId != default(int) && ProductId != default(int))
				{
					result = (result*397) ^ OrderId.GetHashCode();
					result = (result*397) ^ ProductId.GetHashCode();
				}
				else
				{
					result = (result*397) ^ ((OrderId != default(int)) ? OrderId.GetHashCode() : 0);
					result = (result*397) ^ ((ProductId != default(int)) ? ProductId.GetHashCode() : 0);
					result = (result*397) ^ ((UnitPrice != default(decimal)) ? UnitPrice.GetHashCode() : 0);
					result = (result*397) ^ ((Quantity != default(short)) ? Quantity.GetHashCode() : 0);
					result = (result*397) ^ ((Discount != default(float)) ? Discount.GetHashCode() : 0);
				}
				return result;
			}
		}

		#region IXmlSerializable Members

		// Objects with composite keys must be serializable in order to work with NHibernate's lazy loading.
		// Only the key part need to be serialized.

		public virtual XmlSchema GetSchema()
		{
			return null;
		}

		public virtual void ReadXml(XmlReader reader)
		{
			reader.MoveToContent();
			reader.MoveToAttribute("OrderId");
			OrderId = reader.ReadContentAsInt();
			reader.MoveToAttribute("ProductId");
			ProductId = reader.ReadContentAsInt();
		}

		public virtual void WriteXml(XmlWriter writer)
		{
			writer.WriteStartAttribute("OrderId");
			writer.WriteValue(OrderId);
			writer.WriteEndAttribute();
			writer.WriteStartAttribute("ProductId");
			writer.WriteValue(ProductId);
			writer.WriteEndAttribute();
		}

		#endregion
	}
}