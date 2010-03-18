using System;
using System.IO;
using System.Reflection;
using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;

namespace SpikeWpf.Tests
{
	public static class TestDatabaseHelper
	{
		public static ISessionFactory CreateTestDatabase(Assembly assemblyContainingMapping)
		{
			string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestDb.sqlite");
			if (File.Exists(fileName))
			{
				File.Delete(fileName);
			}
			Configuration configuration = new Configuration()
				.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, typeof (SQLite20Driver).AssemblyQualifiedName)
				.SetProperty(NHibernate.Cfg.Environment.Dialect, typeof (SQLiteDialect).AssemblyQualifiedName)
				.SetProperty(NHibernate.Cfg.Environment.ConnectionString, string.Concat("Data Source=", fileName, ";Version=3;New=True;"))
				.SetProperty(NHibernate.Cfg.Environment.ProxyFactoryFactoryClass, typeof (ProxyFactoryFactory).AssemblyQualifiedName)
				.AddAssembly(assemblyContainingMapping);
			new SchemaExport(configuration).Create(true, false);
			return configuration.BuildSessionFactory();
		}
	}
}