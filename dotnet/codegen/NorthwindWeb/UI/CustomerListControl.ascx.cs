namespace NorthwindWeb.UI
{
	using System;
	using System.Linq;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	public partial class CustomerListControl : UserControl
	{
		private Lazy<NorthwindWeb.Business.Customer[]> _lazyList;

		public NorthwindWeb.Business.Customer[] List
		{
			get { return _lazyList.Reference; }
			set { _lazyList.Reference = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			dataSource.ObjectCreating += ((sender1, e1) => { e1.ObjectInstance = this; });
			_lazyList = new Lazy<NorthwindWeb.Business.Customer[]>(OnListLoading);
		}

		public bool AllowSelection
		{
			get
			{
				return 1 == gridView.Columns.Cast<DataControlField>().Count(column => column is CommandField && ((CommandField)column).ShowSelectButton && column.Visible);
			}
			set
			{
				DataControlField selectButton = gridView.Columns.Cast<DataControlField>().FirstOrDefault(column => column is CommandField && ((CommandField)column).ShowSelectButton);
				selectButton.Visible = value;
			}
		}

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.Customer[]>> ListLoading;

		private NorthwindWeb.Business.Customer[] OnListLoading()
		{
			if (ListLoading == null)
			{
				throw new Exception("Parent page/control must handle NorthwindWeb.UI.CustomerListControl.ListLoading event");
			}
			var returnEventArgs = new ParamEventArgs<NorthwindWeb.Business.Customer[]>();
			ListLoading(this, returnEventArgs);
			return returnEventArgs.Param;
		}

		public NorthwindWeb.Business.Customer[] SelectForDataSource()
		{
			return _lazyList.Reference;
		}

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.Customer>> SelectedItemChanged;
	
		protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedItemChanged != null)
			{
				NorthwindWeb.Business.Customer selectedItem = _lazyList.Reference.FirstOrDefault(item => item.CustomerID == Convert.ToString(gridView.SelectedValue));
				SelectedItemChanged(this, new ParamEventArgs<NorthwindWeb.Business.Customer>(selectedItem));
			}
		}
	
	}
}
