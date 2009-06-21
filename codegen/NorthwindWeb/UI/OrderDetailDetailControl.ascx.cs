namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	public partial class OrderDetailDetailControl : UserControl
	{
		private Lazy<NorthwindWeb.Business.OrderDetail> _lazyItem;

		public NorthwindWeb.Business.OrderDetail Item
		{
			get
			{
				if (formView.CurrentMode == FormViewMode.Edit)
				{
					formView.UpdateItem(false);
				}
				if (formView.CurrentMode == FormViewMode.Insert)
				{
					formView.InsertItem(false);
				}
				return _lazyItem.Reference;
			}
			set { _lazyItem.Reference = value; }
		}

		public FormViewMode Mode
		{
			get { return formView.DefaultMode; }
			set
			{
				formView.DefaultMode = value;
				formView.ChangeMode(formView.DefaultMode);
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			dataSource.ObjectCreating += ((sender1, e1) => { e1.ObjectInstance = this; });
			_lazyItem = new Lazy<NorthwindWeb.Business.OrderDetail>(OnItemLoading);
		}

		public event EventHandler<ParamEventArgs<NorthwindWeb.Business.OrderDetail>> ItemLoading;

		private NorthwindWeb.Business.OrderDetail OnItemLoading()
		{
			if (ItemLoading == null)
			{
				throw new Exception("Parent page/control must handle OrderDetailDetailControl.ItemLoading event");
			}
			var returnEventArgs = new ParamEventArgs<NorthwindWeb.Business.OrderDetail>();
			ItemLoading(this, returnEventArgs);
			return returnEventArgs.Param;
		}

		public NorthwindWeb.Business.OrderDetail SelectForDataSource()
		{
			return _lazyItem.Reference;
		}

		public void UpdateForDataSource(NorthwindWeb.Business.OrderDetail item)
		{
			_lazyItem.Reference = item;
		}

		public void InsertForDataSource(NorthwindWeb.Business.OrderDetail item)
		{
			_lazyItem.Reference = item;
		}
	}
}
