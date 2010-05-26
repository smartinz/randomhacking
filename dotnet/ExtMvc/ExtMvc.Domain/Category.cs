using System.Collections.Generic;
using NHibernate.Validator.Constraints;

namespace ExtMvc.Domain
{
	public class Category
	{
		private int _categoryId;

		private ICollection<Product> _products = new HashSet<Product>();


		public virtual int CategoryId
		{
			get { return _categoryId; }
			set { _categoryId = value; }
		}

		[NotNullNotEmpty]
		public virtual string CategoryName { get; set; }

		public virtual string Description { get; set; }

		public virtual byte[] Picture { get; set; }

		[NotNull]
		public virtual ICollection<Product> Products
		{
			get { return _products; }
			private set { _products = value; }
		}

		public override string ToString()
		{
			return (_categoryId == null ? "" : _categoryId.ToString());
		}


		public virtual bool Equals(Category other)
		{
			if(ReferenceEquals(null, other))
			{
				return false;
			}
			if(ReferenceEquals(this, other))
			{
				return true;
			}
			if(CategoryId != default(int))
			{
				return other.CategoryId == CategoryId;
			}
			return other.CategoryId == CategoryId && other.CategoryName == CategoryName && other.Description == Description && other.Picture == Picture && 1 == 1;
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
			if(obj.GetType() != typeof(Category))
			{
				return false;
			}
			return Equals((Category)obj);
		}

		public static bool operator ==(Category left, Category right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Category left, Category right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if(CategoryId != default(int))
				{
					result = (result*397) ^ CategoryId.GetHashCode();
				}
				else
				{
					result = (result*397) ^ ((CategoryId != default(int)) ? CategoryId.GetHashCode() : 0);
					result = (result*397) ^ ((CategoryName != default(string)) ? CategoryName.GetHashCode() : 0);
					result = (result*397) ^ ((Description != default(string)) ? Description.GetHashCode() : 0);
					result = (result*397) ^ ((Picture != default(byte[])) ? Picture.GetHashCode() : 0);
				}
				return result;
			}
		}
	}
}