namespace NorthwindWeb.UI
{
	using System;
	using System.Linq;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	public partial class OrderListControl : UserControl
	{
		private Lazy<NorthwindWeb.Business.Order[]> _lazyList;

		public NorthwindWeb.Business.Order[] List
		{
			get { return _lazyList.Reference; }
			set { _lazyList.Reference = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			dataSource.ObjectCreating += ((sender1, e1) => { e1.ObjectInstance = this; });
			_lazyList = new Lazy<NorthwindWeb.Business.Order[]>(OnListLoading);
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

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.Order[]>> ListLoading;

		private NorthwindWeb.Business.Order[] OnListLoading()
		{
			if (ListLoading == null)
			{
				throw new Exception("Parent page/control must handle NorthwindWeb.UI.OrderListControl.ListLoading event");
			}
			var returnEventArgs = new ParamEventArgs<NorthwindWeb.Business.Order[]>();
			ListLoading(this, returnEventArgs);
			return returnEventArgs.Param;
		}

		public NorthwindWeb.Business.Order[] SelectForDataSource()
		{
			return _lazyList.Reference;
		}

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.Order>> SelectedItemChanged;
	
		protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedItemChanged != null)
			{
				NorthwindWeb.Business.Order selectedItem = _lazyList.Reference.FirstOrDefault(item => item.OrderID == Convert.ToInt32(gridView.SelectedValue));
				SelectedItemChanged(this, new ParamEventArgs<NorthwindWeb.Business.Order>(selectedItem));
			}
		}
	
	}
}
