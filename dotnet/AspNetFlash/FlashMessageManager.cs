using System;
using System.Web;

namespace AspNetFlash
{
	public static class FlashMessageManager
	{
		public static void SetMessage(string message)
		{
			var cookie = new HttpCookie("flash", message ?? "");
			cookie.Expires = DateTime.Now.AddDays(string.IsNullOrEmpty(message) ? -1 : 1);
			HttpContext.Current.Response.Cookies.Add(cookie);
		}

		public static string GetMessageAndDelete()
		{
			HttpCookie cookie = HttpContext.Current.Request.Cookies["flash"];
			if (cookie != null)
			{
				SetMessage(null);
				return cookie.Value;
			}
			return null;
		}
	}
}