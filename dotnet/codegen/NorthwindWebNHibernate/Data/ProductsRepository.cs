namespace NorthwindWebNHibernate.Data
{
	public class ProductsRepository
	{
		private NorthwindWebNHibernate.Context _context;
		
		public ProductsRepository(NorthwindWebNHibernate.Context context)
		{
			_context = context;
		}
		
		public void Create(NorthwindWebNHibernate.Business.Products v)
		{
			using(NHibernate.ITransaction tx = _context.NorthwindDbo.BeginTransaction())
			{
				try
				{
					_context.NorthwindDbo.Save(v);
					tx.Commit();
				}
				catch
				{
					tx.Rollback();
					throw;
				}
			}
		}

		public NorthwindWebNHibernate.Business.Products Read(int ProductId)
		{
			return _context.NorthwindDbo.Get<NorthwindWebNHibernate.Business.Products>(ProductId);
		}

		public void Update(NorthwindWebNHibernate.Business.Products v)
		{
			using(NHibernate.ITransaction tx = _context.NorthwindDbo.BeginTransaction())
			{
				try
				{
					_context.NorthwindDbo.Update(v);
					tx.Commit();
				}
				catch
				{
					tx.Rollback();
					throw;
				}
			}
		}

		public void Delete(NorthwindWebNHibernate.Business.Products v)
		{
			using (NHibernate.ITransaction tx = _context.NorthwindDbo.BeginTransaction())
			{
				try
				{
					_context.NorthwindDbo.Delete(v);
					tx.Commit();
				}
				catch
				{
					tx.Rollback();
					throw;
				}
			}
		}

				public System.Collections.Generic.IEnumerable<NorthwindWebNHibernate.Business.Products> Search(int productId, string productName, string quantityPerUnit, decimal unitPrice, short unitsInStock, short unitsOnOrder, short reorderLevel, bool discontinued, NorthwindWebNHibernate.Business.Categories fkProductsCategories, NorthwindWebNHibernate.Business.Suppliers fkProductsSuppliers)
				{
					return _context.NorthwindDbo.CreateCriteria<NorthwindWebNHibernate.Business.Products>()
									.Add(NHibernate.Criterion.Restrictions.Eq("productId", productId))
												.Add(NHibernate.Criterion.Restrictions.Eq("productName", productName))
												.Add(NHibernate.Criterion.Restrictions.Eq("quantityPerUnit", quantityPerUnit))
												.Add(NHibernate.Criterion.Restrictions.Eq("unitPrice", unitPrice))
												.Add(NHibernate.Criterion.Restrictions.Eq("unitsInStock", unitsInStock))
												.Add(NHibernate.Criterion.Restrictions.Eq("unitsOnOrder", unitsOnOrder))
												.Add(NHibernate.Criterion.Restrictions.Eq("reorderLevel", reorderLevel))
												.Add(NHibernate.Criterion.Restrictions.Eq("discontinued", discontinued))
												.Add(NHibernate.Criterion.Restrictions.Eq("fkProductsCategories", fkProductsCategories))
												.Add(NHibernate.Criterion.Restrictions.Eq("fkProductsSuppliers", fkProductsSuppliers))
								
						.List<NorthwindWebNHibernate.Business.Products>();
				}
				
	}
}
