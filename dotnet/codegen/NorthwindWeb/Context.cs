		namespace NorthwindWeb
		{
		public class Context
		{
		
		private NorthwindWeb.Data.NorthwindWebService _NorthwindWebService;
	
		public Context()
		{
		
		_NorthwindWebService = new NorthwindWeb.Data.NorthwindWebService();
	
		}
		
		public NorthwindWeb.Data.NorthwindWebService NorthwindWebService
		{
		get
		{
		return _NorthwindWebService;
		}
		}
	
		}
		}
