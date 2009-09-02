namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;

	public partial class SearchEmployeeControl : UserControl
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

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.Employee>> SelectedItemChanged
		{
			add { listControl.SelectedItemChanged += value; }
			remove { listControl.SelectedItemChanged -= value; }
		}

		protected void listControl_ListLoading(object sender, ParamEventArgs<NorthwindWeb.Business.Employee[]> e)
		{
		string lastName = (lastNameTextBox.Text);
			string firstName = (firstNameTextBox.Text);
			string title = (titleTextBox.Text);
			
		e.Param = new NorthwindWeb.Data.EmployeeRepository(_context).Search(lastName, firstName, title);
	
		}
	}
}
