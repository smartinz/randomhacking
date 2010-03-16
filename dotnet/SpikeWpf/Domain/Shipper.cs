using Iesi.Collections.Generic;

namespace SpikeWpf.Domain
{
	public class Shipper
	{
		private string _companyName;

		private ISet<Order> _orders = new HashedSet<Order>();


		public virtual int ShipperId { get; set; }

		public virtual string CompanyName
		{
			get { return _companyName; }
			set { _companyName = value; }
		}

		public virtual string Phone { get; set; }

		public virtual ISet<Order> Orders
		{
			get { return _orders; }
			set { _orders = value; }
		}

		public override string ToString()
		{
			return _companyName;
		}


		public virtual bool Equals(Shipper other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			if (ShipperId != default(int))
			{
				return other.ShipperId == ShipperId;
			}
			return other.ShipperId == ShipperId && other.CompanyName == CompanyName && other.Phone == Phone && 1 == 1;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Shipper)) return false;
			return Equals((Shipper) obj);
		}

		public static bool operator ==(Shipper left, Shipper right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Shipper left, Shipper right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if (ShipperId != default(int))
				{
					result = (result*397) ^ ShipperId.GetHashCode();
				}
				else
				{
					result = (result*397) ^ ((ShipperId != default(int)) ? ShipperId.GetHashCode() : 0);
					result = (result*397) ^ ((CompanyName != default(string)) ? CompanyName.GetHashCode() : 0);
					result = (result*397) ^ ((Phone != default(string)) ? Phone.GetHashCode() : 0);
				}
				return result;
			}
		}
	}
}