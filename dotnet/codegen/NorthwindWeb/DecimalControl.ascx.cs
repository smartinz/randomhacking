using System;
using System.Web.UI;

namespace NorthwindWeb
{
	public partial class DecimalControl : UserControl
	{
		public string Format
		{
			get
			{
				if (ViewState["format"] != null)
				{
					return ViewState["format"].ToString();
				}
				return "F";
			}
			set { ViewState["format"] = value; }
		}

		public decimal Value
		{
			get { return NullableValue ?? default(decimal); }
			set { NullableValue = value; }
		}

		public decimal? NullableValue
		{
			get
			{
				decimal value;
				return decimal.TryParse(textBox.Text, out value) ? value : (decimal?)null;
			}
			set { textBox.Text = value.HasValue ? value.Value.ToString(Format) : string.Empty; }
		}

		protected void Page_Load(object sender, EventArgs e) { }
	}
}