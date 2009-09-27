using System;
using System.Web.UI;
using NHibernate;
using NHibernate.Burrow;
using NHibernate.Burrow.WebUtil.Attributes;

namespace SpikeNHibernateBurrow
{
	public partial class EntityWizard : Page
	{
		private readonly BurrowFramework _burrowFramework = new BurrowFramework();

		[ConversationalField]
		protected Entity _entity;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				return;
			}

			_burrowFramework.CurrentConversation.SpanWithPostBacks(TransactionStrategy.BusinessTransaction);
			string id = Request.Params["Id"];
			ISession session = _burrowFramework.GetSession();
			_entity = id == null ? new Entity() : session.Get<Entity>(int.Parse(id));

			txtValue1.Text = _entity.Value1;
			txtValue2.Text = _entity.Value2;
			txtValue3.Text = _entity.Value3;
		}

		protected void btnToStep2_Click(object sender, EventArgs e)
		{
			_entity.Value1 = txtValue1.Text;
			MultiView.SetActiveView(Step2View);
		}

		protected void btnToStep3_Click(object sender, EventArgs e)
		{
			_entity.Value2 = txtValue2.Text;
			MultiView.SetActiveView(Step3View);
		}

		protected void btnFinish_Click(object sender, EventArgs e)
		{
			_entity.Value3 = txtValue3.Text;
			_burrowFramework.GetSession().SaveOrUpdate(_entity);
			_burrowFramework.CurrentConversation.FinishSpan();
			Response.Redirect("ViewEntity.aspx?id=" + _entity.Id);
			MultiView.SetActiveView(Step1View);
		}

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			_burrowFramework.CurrentConversation.GiveUp();
			Response.Redirect("EntityWizard.aspx");
		}

		protected void btnAddChildEntity_Click(object sender, EventArgs e)
		{
			if(ChildEntityEditControl1.Visible)
			{
				_entity.AddChildren(ChildEntityEditControl1.Item);
				ChildEntityEditControl1.Item = null;
				ChildEntityEditControl1.Visible = false;
			}
			else
			{
				ChildEntityEditControl1.Item = new ChildEntity();
				ChildEntityEditControl1.DataBind();
				ChildEntityEditControl1.Visible = true;
			}
		}
	}
}