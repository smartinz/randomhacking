using System.Reflection;
using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;

namespace Conversation.Tests
{
	public static class TestDatabaseHelper
	{
		public static ISessionFactory CreateTestDatabase()
		{
			Configuration configuration = new Configuration()
				.SetProperty(Environment.ConnectionDriver, typeof(SqlClientDriver).AssemblyQualifiedName)
				.SetProperty(Environment.Dialect, typeof(MsSql2005Dialect).AssemblyQualifiedName)
				.SetProperty(Environment.ConnectionString, string.Concat(@"Data Source=.\SQLEXPRESS;Initial Catalog=Tests;Integrated Security=True"))
				.SetProperty(Environment.ProxyFactoryFactoryClass, typeof(ProxyFactoryFactory).AssemblyQualifiedName)
				.SetProperty(Environment.CurrentSessionContextClass, typeof(ConversationSessionContext).AssemblyQualifiedName)
				.AddAssembly(Assembly.GetExecutingAssembly());
			new SchemaExport(configuration).Create(false, true);
			return configuration.BuildSessionFactory();
		}
	}
}