using Iesi.Collections.Generic;
using Newtonsoft.Json;

namespace ExtMvc.Domain
{
	[JsonObject()]
	public class Customer
	{
		private string _contactName;
		private ISet<CustomerDemographic> _customerdemographics = new HashedSet<CustomerDemographic>();
		private ISet<Order> _orders = new HashedSet<Order>();

		public virtual string CustomerId { get; set; }
		public virtual string CompanyName { get; set; }

		public virtual string ContactName
		{
			get { return _contactName; }
			set { _contactName = value; }
		}

		public virtual string ContactTitle { get; set; }

		public virtual string Address { get; set; }

		public virtual string City { get; set; }

		public virtual string Region { get; set; }

		public virtual string PostalCode { get; set; }

		public virtual string Country { get; set; }

		public virtual string Phone { get; set; }

		public virtual string Fax { get; set; }

		public virtual ISet<CustomerDemographic> Customerdemographics
		{
			get { return _customerdemographics; }
			set { _customerdemographics = value; }
		}

		public virtual ISet<Order> Orders
		{
			get { return _orders; }
			set { _orders = value; }
		}

		public override string ToString()
		{
			return _contactName;
		}


		public virtual bool Equals(Customer other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			if (CustomerId != default(string))
			{
				return other.CustomerId == CustomerId;
			}
			return other.CustomerId == CustomerId && other.CompanyName == CompanyName && other.ContactName == ContactName && other.ContactTitle == ContactTitle && other.Address == Address && other.City == City && other.Region == Region && other.PostalCode == PostalCode && other.Country == Country && other.Phone == Phone && other.Fax == Fax && 1 == 1 && 1 == 1;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Customer)) return false;
			return Equals((Customer) obj);
		}

		public static bool operator ==(Customer left, Customer right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Customer left, Customer right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if (CustomerId != default(string))
				{
					result = (result*397) ^ CustomerId.GetHashCode();
				}
				else
				{
					result = (result*397) ^ ((CustomerId != default(string)) ? CustomerId.GetHashCode() : 0);
					result = (result*397) ^ ((CompanyName != default(string)) ? CompanyName.GetHashCode() : 0);
					result = (result*397) ^ ((ContactName != default(string)) ? ContactName.GetHashCode() : 0);
					result = (result*397) ^ ((ContactTitle != default(string)) ? ContactTitle.GetHashCode() : 0);
					result = (result*397) ^ ((Address != default(string)) ? Address.GetHashCode() : 0);
					result = (result*397) ^ ((City != default(string)) ? City.GetHashCode() : 0);
					result = (result*397) ^ ((Region != default(string)) ? Region.GetHashCode() : 0);
					result = (result*397) ^ ((PostalCode != default(string)) ? PostalCode.GetHashCode() : 0);
					result = (result*397) ^ ((Country != default(string)) ? Country.GetHashCode() : 0);
					result = (result*397) ^ ((Phone != default(string)) ? Phone.GetHashCode() : 0);
					result = (result*397) ^ ((Fax != default(string)) ? Fax.GetHashCode() : 0);
				}
				return result;
			}
		}
	}
}