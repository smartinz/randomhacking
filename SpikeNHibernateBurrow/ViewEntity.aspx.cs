using System;
using System.Text;
using System.Web.UI;
using NHibernate;
using NHibernate.Burrow;

namespace SpikeNHibernateBurrow
{
	public partial class ViewEntity : Page
	{
		private readonly BurrowFramework _burrowFramework = new BurrowFramework();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				return;
			}

			var entity = _burrowFramework.GetSession().Get<Entity>(int.Parse(Request.Params["Id"]));

			var sb = new StringBuilder();
			sb.AppendLine("Value1 = " + entity.Value1);
			sb.AppendLine("Value2 = " + entity.Value1);
			sb.AppendLine("Value3 = " + entity.Value1);

			lblEntity.Text = sb.ToString();

		}
	}
}