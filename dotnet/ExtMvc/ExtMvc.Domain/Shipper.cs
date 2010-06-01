using System.Collections.Generic;
using NHibernate.Validator.Constraints;

namespace ExtMvc.Domain
{
	public class Shipper
	{
		private string _companyName;

		private ICollection<Order> _orders = new HashSet<Order>();


		public virtual int ShipperId { get; set; }

		[NotNullNotEmpty]
		public virtual string CompanyName
		{
			get { return _companyName; }
			set { _companyName = value; }
		}

		public virtual string Phone { get; set; }

		[NotNull]
		public virtual ICollection<Order> Orders
		{
			get { return _orders; }
			private set { _orders = value; }
		}

		public override string ToString()
		{
			return (_companyName == null ? "" : _companyName);
		}


		public virtual bool Equals(Shipper other)
		{
			if(ReferenceEquals(null, other))
			{
				return false;
			}
			if(ReferenceEquals(this, other))
			{
				return true;
			}
			if(ShipperId != default(int))
			{
				return other.ShipperId == ShipperId;
			}
			return other.ShipperId == ShipperId && other.CompanyName == CompanyName && other.Phone == Phone && 1 == 1;
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
			if(obj.GetType() != typeof(Shipper))
			{
				return false;
			}
			return Equals((Shipper)obj);
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
				if(ShipperId != default(int))
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