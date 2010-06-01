using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class ProductRepository : IRepository
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

		public IPresentableSet<Product> SearchNormal(int? productId, string productName, bool? discontinued, Category category, Supplier supplier)
		{
			IQueryable<Product> queryable = _northwind.GetCurrentSession().Linq<Product>();
			if(productId != default(int?))
			{
				queryable = queryable.Where(x => x.ProductId == productId);
			}
			if(!string.IsNullOrEmpty(productName))
			{
				queryable = queryable.Where(x => x.ProductName.StartsWith(productName));
			}
			if(discontinued != default(bool?))
			{
				queryable = queryable.Where(x => x.Discontinued == discontinued);
			}
			if(category != default(Category))
			{
				queryable = queryable.Where(x => x.Category == category);
			}
			if(supplier != default(Supplier))
			{
				queryable = queryable.Where(x => x.Supplier == supplier);
			}

			return new QueryablePresentableSet<Product>(queryable);
		}
	}
}