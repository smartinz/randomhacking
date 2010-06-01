using System.Collections.Generic;
using NHibernate.Validator.Constraints;

namespace ExtMvc.Domain
{
	public class Region
	{
		private string _regionDescription;

		private ICollection<Territory> _territories = new HashSet<Territory>();


		public virtual int RegionId { get; set; }

		[NotNullNotEmpty]
		public virtual string RegionDescription
		{
			get { return _regionDescription; }
			set { _regionDescription = value; }
		}

		[NotNull]
		public virtual ICollection<Territory> Territories
		{
			get { return _territories; }
			private set { _territories = value; }
		}

		public override string ToString()
		{
			return (_regionDescription == null ? "" : _regionDescription);
		}


		public virtual bool Equals(Region other)
		{
			if(ReferenceEquals(null, other))
			{
				return false;
			}
			if(ReferenceEquals(this, other))
			{
				return true;
			}
			if(RegionId != default(int))
			{
				return other.RegionId == RegionId;
			}
			return other.RegionId == RegionId && other.RegionDescription == RegionDescription && 1 == 1;
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
			if(obj.GetType() != typeof(Region))
			{
				return false;
			}
			return Equals((Region)obj);
		}

		public static bool operator ==(Region left, Region right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Region left, Region right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if(RegionId != default(int))
				{
					result = (result*397) ^ RegionId.GetHashCode();
				}
				else
				{
					result = (result*397) ^ ((RegionId != default(int)) ? RegionId.GetHashCode() : 0);
					result = (result*397) ^ ((RegionDescription != default(string)) ? RegionDescription.GetHashCode() : 0);
				}
				return result;
			}
		}
	}
}