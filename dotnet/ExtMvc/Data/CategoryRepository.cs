using System.Linq;
using ExtMvc.Domain;
using NHibernate;
using NHibernate.Linq;

namespace ExtMvc.Data
{
	public class CategoryRepository
	{
		private readonly ISession _Northwind;

		public CategoryRepository(ISession Northwind)
		{
			_Northwind = Northwind;
		}

		public void Create(Category v)
		{
			_Northwind.Save(v);
		}

		public Category Read(int categoryId)
		{
			return _Northwind.Load<Category>(categoryId);
		}

		public void Update(Category v)
		{
			_Northwind.Update(v);
		}

		public void Delete(Category v)
		{
			_Northwind.Delete(v);
		}

		public IQueryable<Category> SearchNormal()
		{
			IQueryable<Category> queryable = _Northwind.Linq<Category>();
			return queryable;
		}
	}
}