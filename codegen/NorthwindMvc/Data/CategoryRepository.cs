using NorthwindWeb.Business;

namespace NorthwindWeb.Data
{
    public class CategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public void Create(Category v)
        {
            Category r = _context.NorthwindWebService.CreateCategory(v);

            v.CategoryID = r.CategoryID;
            v.CategoryName = r.CategoryName;
            v.Description = r.Description;
        }

        public Category Read(int CategoryID)
        {
            return _context.NorthwindWebService.ReadCategory(CategoryID);
        }

        public void Update(Category v)
        {
            Category r = _context.NorthwindWebService.UpdateCategory(v);

            v.CategoryID = r.CategoryID;
            v.CategoryName = r.CategoryName;
            v.Description = r.Description;
        }

        public void Delete(Category v)
        {
            _context.NorthwindWebService.DeleteCategory(v);
        }

        public Category[] Search(string categoryName, string description)
        {
            return _context.NorthwindWebService.SearchCategory(categoryName, description);
        }
    }
}