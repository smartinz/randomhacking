using System;
using System.Web.UI;

namespace NorthwindWeb
{
	public partial class DateTimeControl : UserControl
	{
		public string Format
		{
			get
			{
				if (ViewState["format"] != null)
				{
					return ViewState["format"].ToString();
				}
				return "d";
			}
			set { ViewState["format"] = value; }
		}

		public DateTime Value
		{
			get { return NullableValue ?? default(DateTime); }
			set { NullableValue = value; }
		}

		public DateTime? NullableValue
		{
			get
			{
				DateTime value;
				return DateTime.TryParse(textBox.Text, out value) ? value : (DateTime?)null;
			}
			set { textBox.Text = value.HasValue ? value.Value.ToString(Format) : string.Empty; }
		}

		protected void Page_Load(object sender, EventArgs e) { }
	}
}