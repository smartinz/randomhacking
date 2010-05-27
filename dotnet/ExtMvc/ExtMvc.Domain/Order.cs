using System;

namespace ExtMvc.Domain
{
	public class Order
	{
		private int _orderId;

		private DateTime? _orderDate;

		private DateTime? _requiredDate;

		private DateTime? _shippedDate;

		private decimal? _freight;

		private string _shipName;

		private string _shipAddress;

		private string _shipCity;

		private string _shipRegion;

		private string _shipPostalCode;

		private string _shipCountry;

		private Customer _customer;

		private Employee _employee;

		private Shipper _shipper;


		public virtual int OrderId
		{
			get { return _orderId; }
			set { _orderId = value; }
		}

		public virtual DateTime? OrderDate
		{
			get { return _orderDate; }
			set { _orderDate = value; }
		}

		public virtual DateTime? RequiredDate
		{
			get { return _requiredDate; }
			set { _requiredDate = value; }
		}

		public virtual DateTime? ShippedDate
		{
			get { return _shippedDate; }
			set { _shippedDate = value; }
		}

		public virtual decimal? Freight
		{
			get { return _freight; }
			set { _freight = value; }
		}

		public virtual string ShipName
		{
			get { return _shipName; }
			set { _shipName = value; }
		}

		public virtual string ShipAddress
		{
			get { return _shipAddress; }
			set { _shipAddress = value; }
		}

		public virtual string ShipCity
		{
			get { return _shipCity; }
			set { _shipCity = value; }
		}

		public virtual string ShipRegion
		{
			get { return _shipRegion; }
			set { _shipRegion = value; }
		}

		public virtual string ShipPostalCode
		{
			get { return _shipPostalCode; }
			set { _shipPostalCode = value; }
		}

		public virtual string ShipCountry
		{
			get { return _shipCountry; }
			set { _shipCountry = value; }
		}

		public virtual Customer Customer
		{
			get { return _customer; }
			set { _customer = value; }
		}

		public virtual Employee Employee
		{
			get { return _employee; }
			set { _employee = value; }
		}

		public virtual Shipper Shipper
		{
			get { return _shipper; }
			set { _shipper = value; }
		}

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