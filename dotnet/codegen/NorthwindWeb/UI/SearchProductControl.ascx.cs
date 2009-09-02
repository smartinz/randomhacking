namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;

	public partial class SearchProductControl : UserControl
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

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.Product>> SelectedItemChanged
		{
			add { listControl.SelectedItemChanged += value; }
			remove { listControl.SelectedItemChanged -= value; }
		}

		protected void listControl_ListLoading(object sender, ParamEventArgs<NorthwindWeb.Business.Product[]> e)
		{
		NorthwindWeb.Business.Category category = categoryReferenceControl.Item;
			NorthwindWeb.Business.Supplier supplier = supplierReferenceControl.Item;
			
		e.Param = new NorthwindWeb.Data.ProductRepository(_context).Search(category, supplier);
	
		}
	}
}
