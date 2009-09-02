		namespace NorthwindWeb.Data
		{
		public class ProductRepository
		{
		private NorthwindWeb.Context _context;
		public ProductRepository(NorthwindWeb.Context context)
		{
		_context = context;
		}
		
		public void Create(NorthwindWeb.Business.Product v)
		{
		var r = _context.NorthwindWebService.CreateProduct(v);
		
			v.ProductID = r.ProductID;
			v.ProductName = r.ProductName;
			v.QuantityPerUnit = r.QuantityPerUnit;
			v.UnitPrice = r.UnitPrice;
			v.UnitsInStock = r.UnitsInStock;
			v.UnitsOnOrder = r.UnitsOnOrder;
			v.ReorderLevel = r.ReorderLevel;
			v.Discontinued = r.Discontinued;
			v.Supplier = r.Supplier;
			v.Category = r.Category;
		}
	
		public NorthwindWeb.Business.Product Read(int ProductID)
		{
		return _context.NorthwindWebService.ReadProduct(ProductID);
		}
	
		public void Update(NorthwindWeb.Business.Product v)
		{
		var r = _context.NorthwindWebService.UpdateProduct(v);
		
			v.ProductID = r.ProductID;
			v.ProductName = r.ProductName;
			v.QuantityPerUnit = r.QuantityPerUnit;
			v.UnitPrice = r.UnitPrice;
			v.UnitsInStock = r.UnitsInStock;
			v.UnitsOnOrder = r.UnitsOnOrder;
			v.ReorderLevel = r.ReorderLevel;
			v.Discontinued = r.Discontinued;
			v.Supplier = r.Supplier;
			v.Category = r.Category;
		}
	
		public void Delete(NorthwindWeb.Business.Product v)
		{
		_context.NorthwindWebService.DeleteProduct(v);
		}
	
		public NorthwindWeb.Business.Product[] Search(NorthwindWeb.Business.Category category, NorthwindWeb.Business.Supplier supplier)
		{
		return _context.NorthwindWebService.SearchProduct(category, supplier);
		}
	
		}
		}
