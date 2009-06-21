using NorthwindWeb.Business;

namespace NorthwindWeb.Data
{
    public class ProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public void Create(Product v)
        {
            Product r = _context.NorthwindWebService.CreateProduct(v);

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

        public Product Read(int ProductID)
        {
            return _context.NorthwindWebService.ReadProduct(ProductID);
        }

        public void Update(Product v)
        {
            Product r = _context.NorthwindWebService.UpdateProduct(v);

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

        public void Delete(Product v)
        {
            _context.NorthwindWebService.DeleteProduct(v);
        }

        public Product[] Search(Category category, Supplier supplier)
        {
            return _context.NorthwindWebService.SearchProduct(category, supplier);
        }
    }
}