using System;
using NHibernate.Driver;

namespace NHibernate.Driver
{
	public class MonoSQLiteDriver : ReflectionBasedDriver
	{
		public MonoSQLiteDriver() : base("Mono.Data.Sqlite", 	"Mono.Data.Sqlite.SqliteConnection", "Mono.Data.Sqlite.SqliteCommand")
		{
#pragma warning disable 168
			// Needed to force Mono.Data.Sqlite assembly reference (Nunit tests in monodevelop doesn't work otherwise)
			Mono.Data.Sqlite.SqliteConnection connection;
			Mono.Data.Sqlite.SqliteCommand command;
#pragma warning restore 168
		}
		
		public override bool UseNamedPrefixInSql
		{
			get { return true; }
		}
		
		public override bool UseNamedPrefixInParameter
		{
			get { return true; }
		}
		
		public override string NamedPrefix
		{
			get { return "@"; }
		}
		
		public override bool SupportsMultipleOpenReaders
		{
			get { return false; }
		}
	}
}
