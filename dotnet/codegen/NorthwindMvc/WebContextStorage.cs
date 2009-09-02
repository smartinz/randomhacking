using System.Web;
using NorthwindWeb;

namespace NorthwindMvc
{
	public class WebContextStorage : IContextStorage
	{
		#region IContextStorage Members

		public Context Get()
		{
			return HttpContext.Current.Items["Context"] as Context;
		}

		#endregion

		public static void Set(Context context)
		{
			HttpContext.Current.Items["Context"] = context;
		}
	}
}