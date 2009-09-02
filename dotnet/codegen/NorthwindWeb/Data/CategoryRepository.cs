		namespace NorthwindWeb.Data
		{
		public class CategoryRepository
		{
		private NorthwindWeb.Context _context;
		public CategoryRepository(NorthwindWeb.Context context)
		{
		_context = context;
		}
		
		public void Create(NorthwindWeb.Business.Category v)
		{
		var r = _context.NorthwindWebService.CreateCategory(v);
		
			v.CategoryID = r.CategoryID;
			v.CategoryName = r.CategoryName;
			v.Description = r.Description;
		}
	
		public NorthwindWeb.Business.Category Read(int CategoryID)
		{
		return _context.NorthwindWebService.ReadCategory(CategoryID);
		}
	
		public void Update(NorthwindWeb.Business.Category v)
		{
		var r = _context.NorthwindWebService.UpdateCategory(v);
		
			v.CategoryID = r.CategoryID;
			v.CategoryName = r.CategoryName;
			v.Description = r.Description;
		}
	
		public void Delete(NorthwindWeb.Business.Category v)
		{
		_context.NorthwindWebService.DeleteCategory(v);
		}
	
		public NorthwindWeb.Business.Category[] Search(string categoryName, string description)
		{
		return _context.NorthwindWebService.SearchCategory(categoryName, description);
		}
	
		}
		}
