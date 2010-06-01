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

		public IPresentableSet<Category> SearchNormal()
		{
			IQueryable<Category> queryable = _northwind.GetCurrentSession().Linq<Category>();
			return new QueryablePresentableSet<Category>(queryable);
		}
	}
}