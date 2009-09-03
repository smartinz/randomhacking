using System.Web;
using log4net.Config;
using NHibernate;
using NHibernate.Cfg;

namespace NorthwindWebNHibernate
{
	public class Context
	{
		static private readonly ISessionFactory SessionFactory;

		static Context()
		{
			XmlConfigurator.Configure();
			SessionFactory = new Configuration().Configure().BuildSessionFactory();
		}

		public ISession NorthwindDatabase
		{
			get
			{
				if (!HttpContext.Current.Items.Contains("NorthwindDatabase.nhibernatesession"))
				{
					HttpContext.Current.Items["NorthwindDatabase.nhibernatesession"] = SessionFactory.OpenSession();
				}
				return (ISession)HttpContext.Current.Items["NorthwindDatabase.nhibernatesession"];
			}
		}

	}
}