namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	public partial class EmployeeDetailForm : Page
	{
		private Lazy<NorthwindWeb.Business.Employee> _lazyItem;
		private NorthwindWeb.Data.EmployeeRepository _repository;

		protected void Page_Load(object sender, EventArgs e)
		{
			dataSource.ObjectCreating += ((sender1, e1) => { e1.ObjectInstance = this; });
			Items["context"] = new Context();
			_repository = new NorthwindWeb.Data.EmployeeRepository((Context)Items["context"]);
			_lazyItem = new Lazy<NorthwindWeb.Business.Employee>(LoadCurrentItem);

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

		private NorthwindWeb.Business.Employee LoadCurrentItem()
		{
			if (formView.CurrentMode == FormViewMode.Insert)
			{
				return new NorthwindWeb.Business.Employee();
			}
			return _repository.Read(Convert.ToInt32(Request.Params["id"]));
		}

		public NorthwindWeb.Business.Employee SelectForDataSource()
		{
			return _lazyItem.Reference;
		}

		public void UpdateForDataSource(NorthwindWeb.Business.Employee item)
		{
			
			_lazyItem.Reference.EmployeeID = item.EmployeeID;
			_lazyItem.Reference.LastName = item.LastName;
			_lazyItem.Reference.FirstName = item.FirstName;
			_lazyItem.Reference.Title = item.Title;
			_lazyItem.Reference.TitleOfCourtesy = item.TitleOfCourtesy;
			_lazyItem.Reference.BirthDate = item.BirthDate;
			_lazyItem.Reference.HireDate = item.HireDate;
			_lazyItem.Reference.Address = item.Address;
			_lazyItem.Reference.City = item.City;
			_lazyItem.Reference.Region = item.Region;
			_lazyItem.Reference.PostalCode = item.PostalCode;
			_lazyItem.Reference.Country = item.Country;
			_lazyItem.Reference.HomePhone = item.HomePhone;
			_lazyItem.Reference.Extension = item.Extension;
			_lazyItem.Reference.Notes = item.Notes;
			_lazyItem.Reference.PhotoPath = item.PhotoPath;
			_repository.Update(_lazyItem.Reference);
		}

		public void InsertForDataSource(NorthwindWeb.Business.Employee item)
		{
			_lazyItem.Reference = item;
			_repository.Create(_lazyItem.Reference);
		}

		

		protected void formView_ItemInserted(object sender, FormViewInsertedEventArgs e)
		{
			if (e.Exception == null)
			{
				Response.Redirect(string.Format("~/UI/EmployeeDetailForm.aspx?id={0}", _lazyItem.Reference.EmployeeID));
			}
		}
	}
}
