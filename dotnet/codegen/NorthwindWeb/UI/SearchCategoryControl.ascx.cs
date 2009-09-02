namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;

	public partial class SearchCategoryControl : UserControl
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

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.Category>> SelectedItemChanged
		{
			add { listControl.SelectedItemChanged += value; }
			remove { listControl.SelectedItemChanged -= value; }
		}

		protected void listControl_ListLoading(object sender, ParamEventArgs<NorthwindWeb.Business.Category[]> e)
		{
		string categoryName = (categoryNameTextBox.Text);
			string description = (descriptionTextBox.Text);
			
		e.Param = new NorthwindWeb.Data.CategoryRepository(_context).Search(categoryName, description);
	
		}
	}
}
