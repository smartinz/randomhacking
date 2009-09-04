namespace NorthwindWebNHibernate
{
	public class Context
	{
		static private readonly NHibernate.ISessionFactory SessionFactory;

		static Context()
		{
			log4net.Config.XmlConfigurator.Configure();
			SessionFactory = new NHibernate.Cfg.Configuration().Configure().BuildSessionFactory();
		}
		public NHibernate.ISession NorthwindDbo 
		{
			get
			{
				if (!System.Web.HttpContext.Current.Items.Contains("NorthwindDbo.nhibernatesession"))
				{
					System.Web.HttpContext.Current.Items["NorthwindDbo.nhibernatesession"] = SessionFactory.OpenSession();
				}
				return (NHibernate.ISession)System.Web.HttpContext.Current.Items["NorthwindDbo.nhibernatesession"];
			}
		}

	}
}
