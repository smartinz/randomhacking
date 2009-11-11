using System.Linq;
using System.Web;

namespace JQueryWebServices
{
	public class AutoCompleteHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			string[] data = "Core Selectors Attributes Traversing Manipulation CSS Events Effects Ajax Utilities".Split(' ');
			context.Response.ContentType = "text/plain";
			string q = context.Request.QueryString["q"].ToLower();
			foreach(var match in data.Where(d => d.ToLower().Contains(q)))
			{
				context.Response.Write(match[0]);
				context.Response.Write('$');
				context.Response.Write(match);
				context.Response.Write('\n');
			}
		}

		public bool IsReusable
		{
			get { return true; }
		}
	}
}