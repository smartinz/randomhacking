namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	public partial class ProductDetailForm : Page
	{
		private Lazy<NorthwindWeb.Business.Product> _lazyItem;
		private NorthwindWeb.Data.ProductRepository _repository;

		protected void Page_Load(object sender, EventArgs e)
		{
			dataSource.ObjectCreating += ((sender1, e1) => { e1.ObjectInstance = this; });
			Items["context"] = new Context();
			_repository = new NorthwindWeb.Data.ProductRepository((Context)Items["context"]);
			_lazyItem = new Lazy<NorthwindWeb.Business.Product>(LoadCurrentItem);

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

		private NorthwindWeb.Business.Product LoadCurrentItem()
		{
			if (formView.CurrentMode == FormViewMode.Insert)
			{
				return new NorthwindWeb.Business.Product();
			}
			return _repository.Read(Convert.ToInt32(Request.Params["id"]));
		}

		public NorthwindWeb.Business.Product SelectForDataSource()
		{
			return _lazyItem.Reference;
		}

		public void UpdateForDataSource(NorthwindWeb.Business.Product item)
		{
			
			_lazyItem.Reference.ProductID = item.ProductID;
			_lazyItem.Reference.ProductName = item.ProductName;
			_lazyItem.Reference.QuantityPerUnit = item.QuantityPerUnit;
			_lazyItem.Reference.UnitPrice = item.UnitPrice;
			_lazyItem.Reference.UnitsInStock = item.UnitsInStock;
			_lazyItem.Reference.UnitsOnOrder = item.UnitsOnOrder;
			_lazyItem.Reference.ReorderLevel = item.ReorderLevel;
			_lazyItem.Reference.Discontinued = item.Discontinued;
			_lazyItem.Reference.Supplier = item.Supplier;
			_lazyItem.Reference.Category = item.Category;
			_repository.Update(_lazyItem.Reference);
		}

		public void InsertForDataSource(NorthwindWeb.Business.Product item)
		{
			_lazyItem.Reference = item;
			_repository.Create(_lazyItem.Reference);
		}

		

		protected void formView_ItemInserted(object sender, FormViewInsertedEventArgs e)
		{
			if (e.Exception == null)
			{
				Response.Redirect(string.Format("~/UI/ProductDetailForm.aspx?id={0}", _lazyItem.Reference.ProductID));
			}
		}
	}
}
