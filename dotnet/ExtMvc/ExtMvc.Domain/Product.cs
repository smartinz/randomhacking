using NHibernate.Validator.Constraints;

namespace ExtMvc.Domain
{
	public class Product
	{
		private int _productId;


		public virtual int ProductId
		{
			get { return _productId; }
			set { _productId = value; }
		}

		[NotNullNotEmpty]
		public virtual string ProductName { get; set; }

		public virtual string QuantityPerUnit { get; set; }

		public virtual decimal? UnitPrice { get; set; }

		public virtual short? UnitsInStock { get; set; }

		public virtual short? UnitsOnOrder { get; set; }

		public virtual short? ReorderLevel { get; set; }

		public virtual bool Discontinued { get; set; }

		public virtual Category Category { get; set; }

		public virtual Supplier Supplier { get; set; }

		public override string ToString()
		{
			return (_productId == null ? "" : _productId.ToString());
		}


		public virtual bool Equals(Product other)
		{
			if(ReferenceEquals(null, other))
			{
				return false;
			}
			if(ReferenceEquals(this, other))
			{
				return true;
			}
			if(ProductId != default(int))
			{
				return other.ProductId == ProductId;
			}
			return other.ProductId == ProductId && other.ProductName == ProductName && other.QuantityPerUnit == QuantityPerUnit && other.UnitPrice == UnitPrice && other.UnitsInStock == UnitsInStock && other.UnitsOnOrder == UnitsOnOrder && other.ReorderLevel == ReorderLevel && other.Discontinued == Discontinued && other.Category == Category && other.Supplier == Supplier;
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
			if(obj.GetType() != typeof(Product))
			{
				return false;
			}
			return Equals((Product)obj);
		}

		public static bool operator ==(Product left, Product right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Product left, Product right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if(ProductId != default(int))
				{
					result = (result*397) ^ ProductId.GetHashCode();
				}
				else
				{
					result = (result*397) ^ ((ProductId != default(int)) ? ProductId.GetHashCode() : 0);
					result = (result*397) ^ ((ProductName != default(string)) ? ProductName.GetHashCode() : 0);
					result = (result*397) ^ ((QuantityPerUnit != default(string)) ? QuantityPerUnit.GetHashCode() : 0);
					result = (result*397) ^ ((UnitPrice != default(decimal?)) ? UnitPrice.GetHashCode() : 0);
					result = (result*397) ^ ((UnitsInStock != default(short?)) ? UnitsInStock.GetHashCode() : 0);
					result = (result*397) ^ ((UnitsOnOrder != default(short?)) ? UnitsOnOrder.GetHashCode() : 0);
					result = (result*397) ^ ((ReorderLevel != default(short?)) ? ReorderLevel.GetHashCode() : 0);
					result = (result*397) ^ ((Discontinued != default(bool)) ? Discontinued.GetHashCode() : 0);
					result = (result*397) ^ ((Category != default(Category)) ? Category.GetHashCode() : 0);
					result = (result*397) ^ ((Supplier != default(Supplier)) ? Supplier.GetHashCode() : 0);
				}
				return result;
			}
		}
	}
}