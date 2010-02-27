using System.Linq;
using ExtMvc.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class ProductRepository
	{
		private readonly ISession _Northwind;


		public ProductRepository(ISession Northwind)
		{
			_Northwind = Northwind;
		}

		public void Create(Product v)
		{
			_Northwind.Save(v);
		}

		public Product Read(int productId)
		{
			return _Northwind.Load<Product>(productId);
		}

		public void Update(Product v)
		{
			_Northwind.Update(v);
		}

		public void Delete(Product v)
		{
			_Northwind.Delete(v);
		}

		public IQueryable<Product> SearchNormal(int? productId, string productName, string quantityPerUnit, decimal? unitPrice, short? unitsInStock, short? unitsOnOrder, short? reorderLevel, bool? discontinued, Category category, Supplier supplier)
		{
			IQueryable<Product> queryable = _Northwind.Linq<Product>();
			if (productId != default(int?))
			{
				queryable = queryable.Where(x => x.ProductId == productId);
			}
			if (productName != default(string))
			{
				queryable = queryable.Where(x => x.ProductName == productName);
			}
			if (quantityPerUnit != default(string))
			{
				queryable = queryable.Where(x => x.QuantityPerUnit == quantityPerUnit);
			}
			if (unitPrice != default(decimal?))
			{
				queryable = queryable.Where(x => x.UnitPrice == unitPrice);
			}
			if (unitsInStock != default(short?))
			{
				queryable = queryable.Where(x => x.UnitsInStock == unitsInStock);
			}
			if (unitsOnOrder != default(short?))
			{
				queryable = queryable.Where(x => x.UnitsOnOrder == unitsOnOrder);
			}
			if (reorderLevel != default(short?))
			{
				queryable = queryable.Where(x => x.ReorderLevel == reorderLevel);
			}
			if (discontinued != default(bool?))
			{
				queryable = queryable.Where(x => x.Discontinued == discontinued);
			}
			if (category != default(Category))
			{
				queryable = queryable.Where(x => x.Category == category);
			}
			if (supplier != default(Supplier))
			{
				queryable = queryable.Where(x => x.Supplier == supplier);
			}

			return queryable;
		}
	}
}