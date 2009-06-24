using System;
using System.Collections.Generic;
using Gtk;

namespace PersonalMoney
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ExpensesWidget : Gtk.Bin
	{
		private ListStore _listStore;

		private Provider _provider;
		
		public ExpensesWidget(Provider provider)
		{
			_provider = provider;
			this.Build();
			SetupTreeview();
			//_listStore.AppendValues(new DateTime(2009,1,30), "Type", 100, "Description");
			_listStore.AppendValues(new Expense { Date = new DateTime(2009,1,30), Description = "Description", Amount = 100, Type = new ExpenseType { Description = "Type" } } );
			IList<Expense> expenses = provider.GetExpenses();
			
			from expense in expenses 
		}

		private void RenderDate(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
			(cell as CellRendererText).Text = ((DateTime)model.GetValue(iter, 0)).ToString();
		}

		private void SetupTreeview()
		{
			TreeViewColumn treeViewColumn;
			CellRendererText cellRendererText;
			
			treeViewColumn = new TreeViewColumn();
			treeViewColumn.Title = "Date";
			cellRendererText = new CellRendererText();
			treeViewColumn.PackStart(cellRendererText, true);
			//treeViewColumn.AddAttribute(cellRendererText, "text", 0);
			//treeViewColumn.SetCellDataFunc(cellRendererText, new TreeCellDataFunc(RenderDate));
			treeViewColumn.SetCellDataFunc(cellRendererText, delegate(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter){
				(cell as CellRendererText).Text = (model.GetValue(iter, 0) as Expense).Date.ToString();
			});
			treeview.AppendColumn(treeViewColumn);
			treeViewColumn = new TreeViewColumn();
			treeViewColumn.Title = "Type";
			cellRendererText = new CellRendererText();
			treeViewColumn.PackStart(cellRendererText, true);
			//treeViewColumn.AddAttribute(cellRendererText, "text", 1);
			treeViewColumn.SetCellDataFunc(cellRendererText, delegate(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter){
				(cell as CellRendererText).Text = (model.GetValue(iter, 0) as Expense).Type.Description;
			});
			treeview.AppendColumn(treeViewColumn);
			
			treeViewColumn = new TreeViewColumn();
			treeViewColumn.Title = "Amount";
			cellRendererText = new CellRendererText();
			treeViewColumn.PackStart(cellRendererText, true);
			treeViewColumn.SetCellDataFunc(cellRendererText, delegate(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter){
				(cell as CellRendererText).Text = (model.GetValue(iter, 0) as Expense).Amount.ToString();
			});
			treeview.AppendColumn(treeViewColumn);
			
			treeViewColumn = new TreeViewColumn();
			treeViewColumn.Title = "Description";
			cellRendererText = new CellRendererText();
			treeViewColumn.PackStart(cellRendererText, true);
			treeViewColumn.SetCellDataFunc(cellRendererText, delegate(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter){
				(cell as CellRendererText).Text = (model.GetValue(iter, 0) as Expense).Description;
			});
			treeview.AppendColumn(treeViewColumn);

			//_listStore = new ListStore(typeof(DateTime), typeof(String), typeof(int), typeof(String));
			_listStore = new ListStore(typeof(Expense));
			treeview.Model = _listStore;
		}
	}
}
