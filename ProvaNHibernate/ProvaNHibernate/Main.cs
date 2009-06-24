using System;
using Gtk;
using System.Data;

namespace ProvaNHibernate
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			var a = "ciao";

			Provider p = new Provider();
			Expense e = p.GetExpenseById(1);

			Console.Write(e.Id);
			Console.Write(e.Description);

			Mono.Data.Sqlite.SqliteConnection conn = new Mono.Data.Sqlite.SqliteConnection("Data Source=database.sqlite3");
			Mono.Data.Sqlite.SqliteCommand cmd = new Mono.Data.Sqlite.SqliteCommand("select * from expenses", conn);
			conn.Open();
			Mono.Data.Sqlite.SqliteDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			string s = "";
			while(rdr.Read())
			{
				s+=rdr.ToString();
			}
			
			
			
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}