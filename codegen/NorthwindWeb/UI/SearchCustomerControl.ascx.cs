namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;

	public partial class SearchCustomerControl : UserControl
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

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.Customer>> SelectedItemChanged
		{
			add { listControl.SelectedItemChanged += value; }
			remove { listControl.SelectedItemChanged -= value; }
		}

		protected void listControl_ListLoading(object sender, ParamEventArgs<NorthwindWeb.Business.Customer[]> e)
		{
		string companyName = (companyNameTextBox.Text);
			string contactName = (contactNameTextBox.Text);
			string contactTitle = (contactTitleTextBox.Text);
			
		e.Param = new NorthwindWeb.Data.CustomerRepository(_context).Search(companyName, contactName, contactTitle);
	
		}
	}
}
