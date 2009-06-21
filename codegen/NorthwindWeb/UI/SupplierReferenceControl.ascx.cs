namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;

    public partial class SupplierReferenceControl : UserControl
    {
        private Lazy<NorthwindWeb.Business.Supplier> _lazyItem;

        public NorthwindWeb.Business.Supplier Item
        {
            get { return _lazyItem.Reference; }
            set { SetItem(value); }
        }

        private void SetItem(NorthwindWeb.Business.Supplier item)
        {
            _lazyItem.Reference = item;
            idHiddenField.Value = item == null ? string.Empty : item.SupplierID.ToString();
            linkButton.Text = item == null ? "Select..." : item.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var repository = new NorthwindWeb.Data.SupplierRepository((Context)Page.Items["context"]);
            _lazyItem = new Lazy<NorthwindWeb.Business.Supplier>(() => string.IsNullOrEmpty(idHiddenField.Value) ? null : repository.Read(Convert.ToInt32(idHiddenField.Value)));
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            multiView.SetActiveView(descriptionView);
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            multiView.SetActiveView(selectionView);
        }

        protected void searchControl_SelectedItemChanged(object sender, ParamEventArgs<NorthwindWeb.Business.Supplier> e)
        {
            SetItem(e.Param);
            multiView.SetActiveView(descriptionView);
        }
    }
}
