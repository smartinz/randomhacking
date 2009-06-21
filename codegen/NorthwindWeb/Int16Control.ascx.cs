using System;
using System.Web.UI;

namespace NorthwindWeb
{
	public partial class Int16Control : UserControl
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

		public short Value
		{
			get { return NullableValue ?? default(short); }
			set { NullableValue = value; }
		}

		public short? NullableValue
		{
			get
			{
				short value;
				return short.TryParse(textBox.Text, out value) ? value : (short?)null;
			}
			set { textBox.Text = value.HasValue ? value.Value.ToString(Format) : string.Empty; }
		}

		protected void Page_Load(object sender, EventArgs e) { }
	}
}