using System.Linq;
using ExtMvc.Domain;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class CategoryRepository : IRepository
	{
		private readonly ISessionFactory _northwind;


		public CategoryRepository(ISessionFactory northwind)
		{
			_northwind = northwind;
		}

		public void Create(Category v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public Category Read(int categoryId)
		{
			return _northwind.GetCurrentSession().Load<Category>(categoryId);
		}

		public void Update(Category v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(Category v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<Category> Search(int? categoryId, string categoryName, string description)
		{
			IQueryable<Category> queryable = _northwind.GetCurrentSession().Linq<Category>();
			if(categoryId != default(int?))
			{
				queryable = queryable.Where(x => x.CategoryId == categoryId);
			}
			if(categoryName != default(string))
			{
				queryable = queryable.Where(x => x.CategoryName.StartsWith(categoryName));
			}
			if(description != default(string))
			{
				queryable = queryable.Where(x => x.Description.StartsWith(description));
			}

			return new QueryablePresentableSet<Category>(queryable);
		}
	}
}