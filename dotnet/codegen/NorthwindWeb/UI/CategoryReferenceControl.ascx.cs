namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;

    public partial class CategoryReferenceControl : UserControl
    {
        private Lazy<NorthwindWeb.Business.Category> _lazyItem;

        public NorthwindWeb.Business.Category Item
        {
            get { return _lazyItem.Reference; }
            set { SetItem(value); }
        }

        private void SetItem(NorthwindWeb.Business.Category item)
        {
            _lazyItem.Reference = item;
            idHiddenField.Value = item == null ? string.Empty : item.CategoryID.ToString();
            linkButton.Text = item == null ? "Select..." : item.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var repository = new NorthwindWeb.Data.CategoryRepository((Context)Page.Items["context"]);
            _lazyItem = new Lazy<NorthwindWeb.Business.Category>(() => string.IsNullOrEmpty(idHiddenField.Value) ? null : repository.Read(Convert.ToInt32(idHiddenField.Value)));
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            multiView.SetActiveView(descriptionView);
        }

        protected void linkButton_Click(object sender, EventArgs e)
        {
            multiView.SetActiveView(selectionView);
        }

        protected void searchControl_SelectedItemChanged(object sender, ParamEventArgs<NorthwindWeb.Business.Category> e)
        {
            SetItem(e.Param);
            multiView.SetActiveView(descriptionView);
        }
    }
}
