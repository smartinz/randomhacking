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

		public NHibernate.ISession NorthwindDatabase
		{
			get
			{
				if (!System.Web.HttpContext.Current.Items.Contains("NorthwindDatabase.nhibernatesession"))
				{
					System.Web.HttpContext.Current.Items["NorthwindDatabase.nhibernatesession"] = SessionFactory.OpenSession();
				}
				return (NHibernate.ISession)System.Web.HttpContext.Current.Items["NorthwindDatabase.nhibernatesession"];
			}
		}

	}
}