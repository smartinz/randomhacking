using System;
using System.Web.UI;
using NHibernate.Burrow.WebUtil.Attributes;

namespace SpikeNHibernateBurrow
{
	public partial class ChildEntityEditControl : UserControl
	{
		[ConversationalField]
		protected ChildEntity _item;

		public ChildEntity Item
		{
			get
			{
				UiToDomain();
				return _item;
			}
			set { _item = value; }
		}

		private void UiToDomain()
		{
			_item.Value1 = Value1TextBox.Text;
			_item.Value2 = Value2TextBox.Text;
		}

		public override void DataBind()
		{
			base.DataBind();
			DomainToUi();
		}

		private void DomainToUi()
		{
			Value1TextBox.Text = Item.Value1;
			Value2TextBox.Text = Item.Value2;
		}

		protected void Page_Load(object sender, EventArgs e) {}
	}
}