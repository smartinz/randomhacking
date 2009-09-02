namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;

	public partial class SearchSupplierControl : UserControl
	{
		public Context _context;

		protected void Page_Load(object sender, EventArgs e)
		{
			_context = (Context)Page.Items["context"];
		}

		protected void searchButton_Click(object sender, EventArgs e)
		{
			DataBind();
		}

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.Supplier>> SelectedItemChanged
		{
			add { listControl.SelectedItemChanged += value; }
			remove { listControl.SelectedItemChanged -= value; }
		}

		protected void listControl_ListLoading(object sender, ParamEventArgs<NorthwindWeb.Business.Supplier[]> e)
		{
		string companyName = (companyNameTextBox.Text);
			string contactName = (contactNameTextBox.Text);
			string counrty = (counrtyTextBox.Text);
			
		e.Param = new NorthwindWeb.Data.SupplierRepository(_context).Search(companyName, contactName, counrty);
	
		}
	}
}
