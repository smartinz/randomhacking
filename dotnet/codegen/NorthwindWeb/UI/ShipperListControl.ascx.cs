namespace NorthwindWeb.UI
{
	using System;
	using System.Linq;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	public partial class ShipperListControl : UserControl
	{
		private Lazy<NorthwindWeb.Business.Shipper[]> _lazyList;

		public NorthwindWeb.Business.Shipper[] List
		{
			get { return _lazyList.Reference; }
			set { _lazyList.Reference = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			dataSource.ObjectCreating += ((sender1, e1) => { e1.ObjectInstance = this; });
			_lazyList = new Lazy<NorthwindWeb.Business.Shipper[]>(OnListLoading);
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

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.Shipper[]>> ListLoading;

		private NorthwindWeb.Business.Shipper[] OnListLoading()
		{
			if (ListLoading == null)
			{
				throw new Exception("Parent page/control must handle NorthwindWeb.UI.ShipperListControl.ListLoading event");
			}
			var returnEventArgs = new ParamEventArgs<NorthwindWeb.Business.Shipper[]>();
			ListLoading(this, returnEventArgs);
			return returnEventArgs.Param;
		}

		public NorthwindWeb.Business.Shipper[] SelectForDataSource()
		{
			return _lazyList.Reference;
		}

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.Shipper>> SelectedItemChanged;
	
		protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedItemChanged != null)
			{
				NorthwindWeb.Business.Shipper selectedItem = _lazyList.Reference.FirstOrDefault(item => item.ShipperID == Convert.ToInt32(gridView.SelectedValue));
				SelectedItemChanged(this, new ParamEventArgs<NorthwindWeb.Business.Shipper>(selectedItem));
			}
		}
	
	}
}
