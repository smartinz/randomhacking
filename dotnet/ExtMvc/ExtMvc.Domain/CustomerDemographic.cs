using System.Collections.Generic;
using NHibernate.Validator.Constraints;

namespace ExtMvc.Domain
{
	public class CustomerDemographic
	{
		private string _customerTypeId;

		private ICollection<Customer> _customers = new HashSet<Customer>();


		[NotNullNotEmpty]
		public virtual string CustomerTypeId
		{
			get { return _customerTypeId; }
			set { _customerTypeId = value; }
		}

		public virtual string CustomerDesc { get; set; }

		[NotNull]
		public virtual ICollection<Customer> Customers
		{
			get { return _customers; }
			private set { _customers = value; }
		}

		public override string ToString()
		{
			return (_customerTypeId == null ? "" : _customerTypeId);
		}


		public virtual bool Equals(CustomerDemographic other)
		{
			if(ReferenceEquals(null, other))
			{
				return false;
			}
			if(ReferenceEquals(this, other))
			{
				return true;
			}
			if(CustomerTypeId != default(string))
			{
				return other.CustomerTypeId == CustomerTypeId;
			}
			return other.CustomerTypeId == CustomerTypeId && other.CustomerDesc == CustomerDesc && 1 == 1;
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
			if(obj.GetType() != typeof(CustomerDemographic))
			{
				return false;
			}
			return Equals((CustomerDemographic)obj);
		}

		public static bool operator ==(CustomerDemographic left, CustomerDemographic right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(CustomerDemographic left, CustomerDemographic right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if(CustomerTypeId != default(string))
				{
					result = (result*397) ^ CustomerTypeId.GetHashCode();
				}
				else
				{
					result = (result*397) ^ ((CustomerTypeId != default(string)) ? CustomerTypeId.GetHashCode() : 0);
					result = (result*397) ^ ((CustomerDesc != default(string)) ? CustomerDesc.GetHashCode() : 0);
				}
				return result;
			}
		}
	}
}