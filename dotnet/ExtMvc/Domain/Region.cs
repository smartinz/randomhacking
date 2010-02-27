using Iesi.Collections.Generic;

namespace ExtMvc.Domain
{
	public class Region
	{
		private string _regionDescription;

		private ISet<Territory> _territories = new HashedSet<Territory>();


		public virtual int RegionId { get; set; }

		public virtual string RegionDescription
		{
			get { return _regionDescription; }
			set { _regionDescription = value; }
		}

		public virtual ISet<Territory> Territories
		{
			get { return _territories; }
			set { _territories = value; }
		}

		public override string ToString()
		{
			return _regionDescription;
		}


		public virtual bool Equals(Region other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			if (RegionId != default(int))
			{
				return other.RegionId == RegionId;
			}
			return other.RegionId == RegionId && other.RegionDescription == RegionDescription && 1 == 1;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Region)) return false;
			return Equals((Region) obj);
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
				if (RegionId != default(int))
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