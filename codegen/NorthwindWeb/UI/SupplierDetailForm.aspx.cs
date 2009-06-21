namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	public partial class SupplierDetailForm : Page
	{
		private Lazy<NorthwindWeb.Business.Supplier> _lazyItem;
		private NorthwindWeb.Data.SupplierRepository _repository;

		protected void Page_Load(object sender, EventArgs e)
		{
			dataSource.ObjectCreating += ((sender1, e1) => { e1.ObjectInstance = this; });
			Items["context"] = new Context();
			_repository = new NorthwindWeb.Data.SupplierRepository((Context)Items["context"]);
			_lazyItem = new Lazy<NorthwindWeb.Business.Supplier>(LoadCurrentItem);

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

		private NorthwindWeb.Business.Supplier LoadCurrentItem()
		{
			if (formView.CurrentMode == FormViewMode.Insert)
			{
				return new NorthwindWeb.Business.Supplier();
			}
			return _repository.Read(Convert.ToInt32(Request.Params["id"]));
		}

		public NorthwindWeb.Business.Supplier SelectForDataSource()
		{
			return _lazyItem.Reference;
		}

		public void UpdateForDataSource(NorthwindWeb.Business.Supplier item)
		{
			
			_lazyItem.Reference.SupplierID = item.SupplierID;
			_lazyItem.Reference.CompanyName = item.CompanyName;
			_lazyItem.Reference.ContactName = item.ContactName;
			_lazyItem.Reference.ContactTitle = item.ContactTitle;
			_lazyItem.Reference.Address = item.Address;
			_lazyItem.Reference.City = item.City;
			_lazyItem.Reference.Region = item.Region;
			_lazyItem.Reference.PostalCode = item.PostalCode;
			_lazyItem.Reference.Country = item.Country;
			_lazyItem.Reference.Phone = item.Phone;
			_lazyItem.Reference.Fax = item.Fax;
			_lazyItem.Reference.HomePage = item.HomePage;
			_repository.Update(_lazyItem.Reference);
		}

		public void InsertForDataSource(NorthwindWeb.Business.Supplier item)
		{
			_lazyItem.Reference = item;
			_repository.Create(_lazyItem.Reference);
		}

		

		protected void formView_ItemInserted(object sender, FormViewInsertedEventArgs e)
		{
			if (e.Exception == null)
			{
				Response.Redirect(string.Format("~/UI/SupplierDetailForm.aspx?id={0}", _lazyItem.Reference.SupplierID));
			}
		}
	}
}
