namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	public partial class OrderDetailForm : Page
	{
		private Lazy<NorthwindWeb.Business.Order> _lazyItem;
		private NorthwindWeb.Data.OrderRepository _repository;

		protected void Page_Load(object sender, EventArgs e)
		{
			dataSource.ObjectCreating += ((sender1, e1) => { e1.ObjectInstance = this; });
			Items["context"] = new Context();
			_repository = new NorthwindWeb.Data.OrderRepository((Context)Items["context"]);
			_lazyItem = new Lazy<NorthwindWeb.Business.Order>(LoadCurrentItem);

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

		private NorthwindWeb.Business.Order LoadCurrentItem()
		{
			if (formView.CurrentMode == FormViewMode.Insert)
			{
				return new NorthwindWeb.Business.Order();
			}
			return _repository.Read(Convert.ToInt32(Request.Params["id"]));
		}

		public NorthwindWeb.Business.Order SelectForDataSource()
		{
			return _lazyItem.Reference;
		}

		public void UpdateForDataSource(NorthwindWeb.Business.Order item)
		{
			
			_lazyItem.Reference.OrderID = item.OrderID;
			_lazyItem.Reference.OrderDate = item.OrderDate;
			_lazyItem.Reference.RequiredDate = item.RequiredDate;
			_lazyItem.Reference.ShippedDate = item.ShippedDate;
			_lazyItem.Reference.Freight = item.Freight;
			_lazyItem.Reference.ShipName = item.ShipName;
			_lazyItem.Reference.ShipAddress = item.ShipAddress;
			_lazyItem.Reference.ShipCity = item.ShipCity;
			_lazyItem.Reference.ShipRegion = item.ShipRegion;
			_lazyItem.Reference.ShipPostalCode = item.ShipPostalCode;
			_lazyItem.Reference.ShipCountry = item.ShipCountry;
			_lazyItem.Reference.OrderDetails = item.OrderDetails;
			_lazyItem.Reference.Customer = item.Customer;
			_lazyItem.Reference.Employee = item.Employee;
			_lazyItem.Reference.Shipper = item.Shipper;
			_repository.Update(_lazyItem.Reference);
		}

		public void InsertForDataSource(NorthwindWeb.Business.Order item)
		{
			_lazyItem.Reference = item;
			_repository.Create(_lazyItem.Reference);
		}

		
		protected void OrderDetailsListControl_ListLoading(object sender, ParamEventArgs<NorthwindWeb.Business.OrderDetail[]> e)
		{
			e.Param = _lazyItem.Reference.OrderDetails;
		}
			

		protected void formView_ItemInserted(object sender, FormViewInsertedEventArgs e)
		{
			if (e.Exception == null)
			{
				Response.Redirect(string.Format("~/UI/OrderDetailForm.aspx?id={0}", _lazyItem.Reference.OrderID));
			}
		}
	}
}
