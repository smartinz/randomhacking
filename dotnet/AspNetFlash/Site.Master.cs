using System;
using System.Web.UI;

namespace AspNetFlash
{
	public partial class Site : MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string message = FlashMessageManager.GetMessageAndDelete();
			flashLabel.Visible = !string.IsNullOrEmpty(message);
			flashLabel.Text = string.IsNullOrEmpty(message) ? "" : Server.HtmlEncode(message);
		}
	}
}