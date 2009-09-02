using System;
using Gtk;
using System.Data;
using NHibernate;
using NHibernate.Cfg;

namespace PersonalMoney
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();

			Expense e = new Expense();

			Provider p = new Provider(sessionFactory.OpenSession());
			e = p.GetExpenseById(1);


			
			e.Date = new DateTime(2009, 1, 18);
			e.Description = "description";
			e.Amount = 100;
			//e.ExpenseTypeId = 1;

			using(var session = sessionFactory.OpenSession())
				using(session.BeginTransaction())
			{
				session.Save(e);
				session.Transaction.Commit();
			}


//			Expense e = new Expense();
//			
//
//
//			Provider p = new Provider();
//			e = p.GetExpenseById(1);
//
//			Console.Write(e.Id);
//			Console.Write(e.Description);
//			Console.Write(e.Amount);
//
//			Mono.Data.Sqlite.SqliteConnection conn = new Mono.Data.Sqlite.SqliteConnection("Data Source=database.sqlite3");
//			Mono.Data.Sqlite.SqliteCommand cmd = new Mono.Data.Sqlite.SqliteCommand("select * from expenses", conn);
//			conn.Open();
//			Mono.Data.Sqlite.SqliteDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
//			string s = "";
//			while(rdr.Read())
//			{
//				s+=rdr.ToString();
//			}
//			
//			
//

			
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}