using System;
using System.Web.UI;

namespace WebApplication
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e) {}

		protected void actionButton_Click(object sender, EventArgs e)
		{
			outputLabel.Text = inputTextBox.Text;
		}
	}
}