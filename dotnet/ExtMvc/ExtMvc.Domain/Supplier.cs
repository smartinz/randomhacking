using System.Collections.Generic;
using NHibernate.Validator.Constraints;

namespace ExtMvc.Domain
{
	public class Supplier
	{
		private string _companyName;

		private ICollection<Product> _products = new HashSet<Product>();


		public virtual int SupplierId { get; set; }

		[NotNullNotEmpty]
		public virtual string CompanyName
		{
			get { return _companyName; }
			set { _companyName = value; }
		}

		public virtual string ContactName { get; set; }

		public virtual string ContactTitle { get; set; }

		public virtual string Address { get; set; }

		public virtual string City { get; set; }

		public virtual string Region { get; set; }

		public virtual string PostalCode { get; set; }

		public virtual string Country { get; set; }

		public virtual string Phone { get; set; }

		public virtual string Fax { get; set; }

		public virtual string HomePage { get; set; }

		[NotNull]
		public virtual ICollection<Product> Products
		{
			get { return _products; }
			private set { _products = value; }
		}

		public override string ToString()
		{
			return (_companyName == null ? "" : _companyName);
		}


		public virtual bool Equals(Supplier other)
		{
			if(ReferenceEquals(null, other))
			{
				return false;
			}
			if(ReferenceEquals(this, other))
			{
				return true;
			}
			if(SupplierId != default(int))
			{
				return other.SupplierId == SupplierId;
			}
			return other.SupplierId == SupplierId && other.CompanyName == CompanyName && other.ContactName == ContactName && other.ContactTitle == ContactTitle && other.Address == Address && other.City == City && other.Region == Region && other.PostalCode == PostalCode && other.Country == Country && other.Phone == Phone && other.Fax == Fax && other.HomePage == HomePage && 1 == 1;
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
			if(obj.GetType() != typeof(Supplier))
			{
				return false;
			}
			return Equals((Supplier)obj);
		}

		public static bool operator ==(Supplier left, Supplier right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Supplier left, Supplier right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if(SupplierId != default(int))
				{
					result = (result*397) ^ SupplierId.GetHashCode();
				}
				else
				{
					result = (result*397) ^ ((SupplierId != default(int)) ? SupplierId.GetHashCode() : 0);
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
					result = (result*397) ^ ((HomePage != default(string)) ? HomePage.GetHashCode() : 0);
				}
				return result;
			}
		}
	}
}