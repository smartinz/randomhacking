namespace ExtMvc.Domain
{
	public class CustomerDemographic
	{
		private string _customerDesc;
		public virtual string CustomerTypeId { get; set; }

		public virtual string CustomerDesc
		{
			get { return _customerDesc; }
			set { _customerDesc = value; }
		}

		public override string ToString()
		{
			return _customerDesc;
		}

		public virtual bool Equals(CustomerDemographic other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			if (CustomerTypeId != default(string))
			{
				return other.CustomerTypeId == CustomerTypeId;
			}
			return other.CustomerTypeId == CustomerTypeId && other.CustomerDesc == CustomerDesc;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (CustomerDemographic)) return false;
			return Equals((CustomerDemographic) obj);
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
				if (CustomerTypeId != default(string))
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