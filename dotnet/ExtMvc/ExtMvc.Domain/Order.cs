using System;

namespace ExtMvc.Domain
{
	public class Order
	{
		private int _orderId;


		public virtual int OrderId
		{
			get { return _orderId; }
			set { _orderId = value; }
		}

		public virtual DateTime? OrderDate { get; set; }

		public virtual DateTime? RequiredDate { get; set; }

		public virtual DateTime? ShippedDate { get; set; }

		public virtual decimal? Freight { get; set; }

		public virtual string ShipName { get; set; }

		public virtual string ShipAddress { get; set; }

		public virtual string ShipCity { get; set; }

		public virtual string ShipRegion { get; set; }

		public virtual string ShipPostalCode { get; set; }

		public virtual string ShipCountry { get; set; }

		public virtual Customer Customer { get; set; }

		public virtual Employee Employee { get; set; }

		public virtual Shipper Shipper { get; set; }

		public override string ToString()
		{
			return (_orderId == null ? "" : _orderId.ToString());
		}


		public virtual bool Equals(Order other)
		{
			if(ReferenceEquals(null, other))
			{
				return false;
			}
			if(ReferenceEquals(this, other))
			{
				return true;
			}
			if(OrderId != default(int))
			{
				return other.OrderId == OrderId;
			}
			return other.OrderId == OrderId && other.OrderDate == OrderDate && other.RequiredDate == RequiredDate && other.ShippedDate == ShippedDate && other.Freight == Freight && other.ShipName == ShipName && other.ShipAddress == ShipAddress && other.ShipCity == ShipCity && other.ShipRegion == ShipRegion && other.ShipPostalCode == ShipPostalCode && other.ShipCountry == ShipCountry && other.Customer == Customer && other.Employee == Employee && other.Shipper == Shipper;
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
			if(obj.GetType() != typeof(Order))
			{
				return false;
			}
			return Equals((Order)obj);
		}

		public static bool operator ==(Order left, Order right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Order left, Order right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if(OrderId != default(int))
				{
					result = (result*397) ^ OrderId.GetHashCode();
				}
				else
				{
					result = (result*397) ^ ((OrderId != default(int)) ? OrderId.GetHashCode() : 0);
					result = (result*397) ^ ((OrderDate != default(DateTime?)) ? OrderDate.GetHashCode() : 0);
					result = (result*397) ^ ((RequiredDate != default(DateTime?)) ? RequiredDate.GetHashCode() : 0);
					result = (result*397) ^ ((ShippedDate != default(DateTime?)) ? ShippedDate.GetHashCode() : 0);
					result = (result*397) ^ ((Freight != default(decimal?)) ? Freight.GetHashCode() : 0);
					result = (result*397) ^ ((ShipName != default(string)) ? ShipName.GetHashCode() : 0);
					result = (result*397) ^ ((ShipAddress != default(string)) ? ShipAddress.GetHashCode() : 0);
					result = (result*397) ^ ((ShipCity != default(string)) ? ShipCity.GetHashCode() : 0);
					result = (result*397) ^ ((ShipRegion != default(string)) ? ShipRegion.GetHashCode() : 0);
					result = (result*397) ^ ((ShipPostalCode != default(string)) ? ShipPostalCode.GetHashCode() : 0);
					result = (result*397) ^ ((ShipCountry != default(string)) ? ShipCountry.GetHashCode() : 0);
					result = (result*397) ^ ((Customer != default(Customer)) ? Customer.GetHashCode() : 0);
					result = (result*397) ^ ((Employee != default(Employee)) ? Employee.GetHashCode() : 0);
					result = (result*397) ^ ((Shipper != default(Shipper)) ? Shipper.GetHashCode() : 0);
				}
				return result;
			}
		}
	}
}