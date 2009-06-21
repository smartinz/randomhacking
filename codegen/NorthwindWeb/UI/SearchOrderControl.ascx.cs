namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;

	public partial class SearchOrderControl : UserControl
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

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.Order>> SelectedItemChanged
		{
			add { listControl.SelectedItemChanged += value; }
			remove { listControl.SelectedItemChanged -= value; }
		}

		protected void listControl_ListLoading(object sender, ParamEventArgs<NorthwindWeb.Business.Order[]> e)
		{
		NorthwindWeb.Business.Employee employee = employeeReferenceControl.Item;
			System.DateTime dateFrom = (dateFromControl.Value);
			System.DateTime dateTo = (dateToControl.Value);
			
		e.Param = new NorthwindWeb.Data.OrderRepository(_context).Search(employee, dateFrom, dateTo);
	
		}
	}
}
