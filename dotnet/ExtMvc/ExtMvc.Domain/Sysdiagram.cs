using NHibernate.Validator.Constraints;

namespace ExtMvc.Domain
{
	public class Sysdiagram
	{
		private int _diagramId;


		[NotNullNotEmpty]
		public virtual string Name { get; set; }

		public virtual int PrincipalId { get; set; }

		public virtual int DiagramId
		{
			get { return _diagramId; }
			set { _diagramId = value; }
		}

		public virtual int? Version { get; set; }

		public virtual byte[] Definition { get; set; }

		public override string ToString()
		{
			return (_diagramId == null ? "" : _diagramId.ToString());
		}


		public virtual bool Equals(Sysdiagram other)
		{
			if(ReferenceEquals(null, other))
			{
				return false;
			}
			if(ReferenceEquals(this, other))
			{
				return true;
			}
			if(DiagramId != default(int))
			{
				return other.DiagramId == DiagramId;
			}
			return other.Name == Name && other.PrincipalId == PrincipalId && other.DiagramId == DiagramId && other.Version == Version && other.Definition == Definition;
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
			if(obj.GetType() != typeof(Sysdiagram))
			{
				return false;
			}
			return Equals((Sysdiagram)obj);
		}

		public static bool operator ==(Sysdiagram left, Sysdiagram right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Sysdiagram left, Sysdiagram right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if(DiagramId != default(int))
				{
					result = (result*397) ^ DiagramId.GetHashCode();
				}
				else
				{
					result = (result*397) ^ ((Name != default(string)) ? Name.GetHashCode() : 0);
					result = (result*397) ^ ((PrincipalId != default(int)) ? PrincipalId.GetHashCode() : 0);
					result = (result*397) ^ ((DiagramId != default(int)) ? DiagramId.GetHashCode() : 0);
					result = (result*397) ^ ((Version != default(int?)) ? Version.GetHashCode() : 0);
					result = (result*397) ^ ((Definition != default(byte[])) ? Definition.GetHashCode() : 0);
				}
				return result;
			}
		}
	}
}