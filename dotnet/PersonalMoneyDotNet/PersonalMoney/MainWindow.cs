	using System;
using Gtk;

namespace PersonalMoney
{
	public partial class MainWindow: Gtk.Window
	{	
		public MainWindow (): base (Gtk.WindowType.Toplevel)
		{
			Build ();
		}
		
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}
	
		private void AddPage(Widget widget)
		{
			HBox hbox = new HBox();
			hbox.PackStart(new Label("Label"));
			Button closeButton = new Button("X");
			closeButton.Relief = ReliefStyle.None;
			closeButton.FocusOnClick = false;
			closeButton.Clicked += delegate {
				hbox.Destroy();
				widget.Destroy();
			};
			
			hbox.PackStart(closeButton);
			hbox.ShowAll();
			notebook.AppendPage(widget, hbox);
			notebook.ShowAll();
		}
	
		protected virtual void OnExpensesActionActivated (object sender, System.EventArgs e)
		{
			AddPage(new ExpensesWidget());
		}
	}
}
