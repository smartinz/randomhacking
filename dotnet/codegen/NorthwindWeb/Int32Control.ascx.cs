using System;
using System.Web.UI;

namespace NorthwindWeb
{
	public partial class Int32Control : UserControl
	{
		public string Format
		{
			get
			{
				if (ViewState["format"] != null)
				{
					return ViewState["format"].ToString();
				}
				return "G";
			}
			set { ViewState["format"] = value; }
		}

		public int Value
		{
			get { return NullableValue ?? default(int); }
			set { NullableValue = value; }
		}

		public int? NullableValue
		{
			get
			{
				int value;
				return int.TryParse(textBox.Text, out value) ? value : (int?)null;
			}
			set { textBox.Text = value.HasValue ? value.Value.ToString(Format) : string.Empty; }
		}

		protected void Page_Load(object sender, EventArgs e) { }
	}
}