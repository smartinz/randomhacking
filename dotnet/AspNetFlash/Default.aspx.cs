using System;
using System.Web.UI;

namespace AspNetFlash
{
	public partial class Default : Page
	{
		protected void Page_Load(object sender, EventArgs e) {}

		protected void Button1_Click(object sender, EventArgs e)
		{
			FlashMessageManager.SetMessage("Flash message (strange chars: èèò@à°)");
			Response.Redirect("~/Default.aspx");
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Default.aspx");
		}

		protected void Button3_Click(object sender, EventArgs e) {}
	}
}