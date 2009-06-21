namespace NorthwindWeb.UI
{
	using System;
	using System.Web.UI;

	public partial class SearchSupplierForm : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Items["context"] = new Context();
		}

		protected void searchControl_SelectedItemChanged(object sender, ParamEventArgs<NorthwindWeb.Business.Supplier> e)
		{
			if (e.Param != null)
			{
				Response.Redirect(string.Format("~/UI/SupplierDetailForm.aspx?id={0}", e.Param.SupplierID));
			}
		}
	}
}
