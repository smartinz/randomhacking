namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	public partial class ShipperDetailForm : Page
	{
		private Lazy<NorthwindWeb.Business.Shipper> _lazyItem;
		private NorthwindWeb.Data.ShipperRepository _repository;

		protected void Page_Load(object sender, EventArgs e)
		{
			dataSource.ObjectCreating += ((sender1, e1) => { e1.ObjectInstance = this; });
			Items["context"] = new Context();
			_repository = new NorthwindWeb.Data.ShipperRepository((Context)Items["context"]);
			_lazyItem = new Lazy<NorthwindWeb.Business.Shipper>(LoadCurrentItem);

			if (!IsPostBack)
			{
				if (string.IsNullOrEmpty(Request.Params["id"]))
				{
					ViewState["id"] = null;
					formView.ChangeMode(FormViewMode.Insert);
				}
				else
				{
					ViewState["id"] = Convert.ToInt32(Request.Params["id"]);
				}
			}
		}

		private NorthwindWeb.Business.Shipper LoadCurrentItem()
		{
			if (formView.CurrentMode == FormViewMode.Insert)
			{
				return new NorthwindWeb.Business.Shipper();
			}
			return _repository.Read(Convert.ToInt32(Request.Params["id"]));
		}

		public NorthwindWeb.Business.Shipper SelectForDataSource()
		{
			return _lazyItem.Reference;
		}

		public void UpdateForDataSource(NorthwindWeb.Business.Shipper item)
		{
			
			_lazyItem.Reference.ShipperID = item.ShipperID;
			_lazyItem.Reference.CompanyName = item.CompanyName;
			_lazyItem.Reference.Phone = item.Phone;
			_repository.Update(_lazyItem.Reference);
		}

		public void InsertForDataSource(NorthwindWeb.Business.Shipper item)
		{
			_lazyItem.Reference = item;
			_repository.Create(_lazyItem.Reference);
		}

		

		protected void formView_ItemInserted(object sender, FormViewInsertedEventArgs e)
		{
			if (e.Exception == null)
			{
				Response.Redirect(string.Format("~/UI/ShipperDetailForm.aspx?id={0}", _lazyItem.Reference.ShipperID));
			}
		}
	}
}
