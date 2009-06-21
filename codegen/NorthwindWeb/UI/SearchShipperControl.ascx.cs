namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;

	public partial class SearchShipperControl : UserControl
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

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.Shipper>> SelectedItemChanged
		{
			add { listControl.SelectedItemChanged += value; }
			remove { listControl.SelectedItemChanged -= value; }
		}

		protected void listControl_ListLoading(object sender, ParamEventArgs<NorthwindWeb.Business.Shipper[]> e)
		{
		string companyName = (companyNameTextBox.Text);
			string phone = (phoneTextBox.Text);
			
		e.Param = new NorthwindWeb.Data.ShipperRepository(_context).Search(companyName, phone);
	
		}
	}
}
