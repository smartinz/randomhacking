namespace NorthwindWeb.UI
{
	using System;
	using System.Linq;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	public partial class OrderDetailListControl : UserControl
	{
		private Lazy<NorthwindWeb.Business.OrderDetail[]> _lazyList;

		public NorthwindWeb.Business.OrderDetail[] List
		{
			get { return _lazyList.Reference; }
			set { _lazyList.Reference = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			dataSource.ObjectCreating += ((sender1, e1) => { e1.ObjectInstance = this; });
			_lazyList = new Lazy<NorthwindWeb.Business.OrderDetail[]>(OnListLoading);
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

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.OrderDetail[]>> ListLoading;

		private NorthwindWeb.Business.OrderDetail[] OnListLoading()
		{
			if (ListLoading == null)
			{
				throw new Exception("Parent page/control must handle NorthwindWeb.UI.OrderDetailListControl.ListLoading event");
			}
			var returnEventArgs = new ParamEventArgs<NorthwindWeb.Business.OrderDetail[]>();
			ListLoading(this, returnEventArgs);
			return returnEventArgs.Param;
		}

		public NorthwindWeb.Business.OrderDetail[] SelectForDataSource()
		{
			return _lazyList.Reference;
		}

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.OrderDetail>> SelectedItemChanged;
	
	}
}
