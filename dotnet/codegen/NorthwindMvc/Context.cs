using NorthwindWeb.Data;

namespace NorthwindWeb
{
    public class Context
    {
        private readonly NorthwindWebService _NorthwindWebService;

        public Context()
        {
            _NorthwindWebService = new NorthwindWebService();
        }

        public NorthwindWebService NorthwindWebService
        {
            get { return _NorthwindWebService; }
        }
    }
}