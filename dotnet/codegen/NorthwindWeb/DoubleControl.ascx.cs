using System;
using System.Web.UI;

namespace NorthwindWeb
{
	public partial class DoubleControl : UserControl
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

		public double Value
		{
			get { return NullableValue ?? default(double); }
			set { NullableValue = value; }
		}

		public double? NullableValue
		{
			get
			{
				double value;
				return double.TryParse(textBox.Text, out value) ? value : (double?)null;
			}
			set { textBox.Text = value.HasValue ? value.Value.ToString(Format) : string.Empty; }
		}

		protected void Page_Load(object sender, EventArgs e) { }
	}
}