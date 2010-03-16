using Iesi.Collections.Generic;

namespace SpikeWpf.Domain
{
	public class Territory
	{
		private ISet<Employee> _Employees = new HashedSet<Employee>();
		private string _TerritoryDescription;


		public virtual string TerritoryId { get; set; }

		public virtual string TerritoryDescription
		{
			get { return _TerritoryDescription; }
			set { _TerritoryDescription = value; }
		}

		public virtual ISet<Employee> Employees
		{
			get { return _Employees; }
			set { _Employees = value; }
		}

		public virtual Region Region { get; set; }

		public override string ToString()
		{
			return _TerritoryDescription;
		}


		public virtual bool Equals(Territory other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			if (TerritoryId != default(string))
			{
				return other.TerritoryId == TerritoryId;
			}
			return other.TerritoryId == TerritoryId && other.TerritoryDescription == TerritoryDescription && 1 == 1 && other.Region == Region;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Territory)) return false;
			return Equals((Territory) obj);
		}

		public static bool operator ==(Territory left, Territory right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Territory left, Territory right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if (TerritoryId != default(string))
				{
					result = (result*397) ^ TerritoryId.GetHashCode();
				}
				else
				{
					result = (result*397) ^ ((TerritoryId != default(string)) ? TerritoryId.GetHashCode() : 0);
					result = (result*397) ^ ((TerritoryDescription != default(string)) ? TerritoryDescription.GetHashCode() : 0);

					result = (result*397) ^ ((Region != default(Region)) ? Region.GetHashCode() : 0);
				}
				return result;
			}
		}
	}
}