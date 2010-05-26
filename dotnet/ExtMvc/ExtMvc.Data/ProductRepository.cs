using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class ProductRepository
	{
		private readonly ISessionFactory _northwind;


		public ProductRepository(ISessionFactory northwind)
		{
			_northwind = northwind;
		}

		public void Create(Product v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public Product Read(int productId)
		{
			return _northwind.GetCurrentSession().Load<Product>(productId);
		}

		public void Update(Product v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(Product v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<Product> Search(int? productId, string productName, string quantityPerUnit, decimal? unitPrice, short? unitsInStock, short? unitsOnOrder, short? reorderLevel, bool? discontinued)
		{
			IQueryable<Product> queryable = _northwind.GetCurrentSession().Linq<Product>();
			if(productId != default(int?))
			{
				queryable = queryable.Where(x => x.ProductId == productId);
			}
			if(productName != default(string))
			{
				queryable = queryable.Where(x => x.ProductName.StartsWith(productName));
			}
			if(quantityPerUnit != default(string))
			{
				queryable = queryable.Where(x => x.QuantityPerUnit.StartsWith(quantityPerUnit));
			}
			if(unitPrice != default(decimal?))
			{
				queryable = queryable.Where(x => x.UnitPrice == unitPrice);
			}
			if(unitsInStock != default(short?))
			{
				queryable = queryable.Where(x => x.UnitsInStock == unitsInStock);
			}
			if(unitsOnOrder != default(short?))
			{
				queryable = queryable.Where(x => x.UnitsOnOrder == unitsOnOrder);
			}
			if(reorderLevel != default(short?))
			{
				queryable = queryable.Where(x => x.ReorderLevel == reorderLevel);
			}
			if(discontinued != default(bool?))
			{
				queryable = queryable.Where(x => x.Discontinued == discontinued);
			}

			return new Nexida.Infrastructure.QueryablePresentableSet<Product>(queryable);
		}
	}
}