namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;

    public partial class CustomerReferenceControl : UserControl
    {
        private Lazy<NorthwindWeb.Business.Customer> _lazyItem;

        public NorthwindWeb.Business.Customer Item
        {
            get { return _lazyItem.Reference; }
            set { SelectItem(value); }
        }

        private void SelectItem(NorthwindWeb.Business.Customer item)
        {
            _lazyItem.Reference = item;
            idHiddenField.Value = item == null ? string.Empty : item.CustomerID.ToString();
            linkButton.Text = item == null ? "Select..." : item.ToString();
        	dialogHandlingPanel.Visible = false;
		}

        protected void Page_Load(object sender, EventArgs e)
        {
            var repository = new NorthwindWeb.Data.CustomerRepository((Context)Page.Items["context"]);
            _lazyItem = new Lazy<NorthwindWeb.Business.Customer>(() => string.IsNullOrEmpty(idHiddenField.Value) ? null : repository.Read(Convert.ToString(idHiddenField.Value)));
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
			dialogHandlingPanel.Visible = true;
        }

        protected void searchControl_SelectedItemChanged(object sender, ParamEventArgs<NorthwindWeb.Business.Customer> e)
        {
            SelectItem(e.Param);
        }

		protected void selectNoneLinkButton_Click(object sender, EventArgs e)
		{
			SelectItem(null);
		}
		
		protected void cancelLinkButton_Click(object sender, EventArgs e)
    	{
			dialogHandlingPanel.Visible = false;
		}
    }
}
