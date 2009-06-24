class ExpensesWindow < Gtk::Window
  def initialize(data_layer)
    super()
    glade = GladeXML.new(File.join(File.dirname(__FILE__), 'expenses_window.glade'), 'vbox') { |handler| method(handler) }
    glade.widget_names.each do |name|
      instance_variable_set("@#{name}".intern, glade[name])
    end

    add(@vbox)
    signal_connect('destroy') { on_window_destroy() }
    self.default_width = 800
    self.default_height = 500
    
    @data_layer = data_layer
    self.title = "Expenses [#{@data_layer.to_s}]"
    
    @treeview.model = Gtk::ListStore.new(Expense, Integer, Date, Integer, Integer, String, Integer, String, String, Date, Integer)

    @treeview.append_column(Gtk::TreeViewColumn.new('Id', Gtk::CellRendererText.new, :text => 1))
    
    renderer = Gtk::CellRendererText.new
    column = Gtk::TreeViewColumn.new('Date', renderer)
    column.set_cell_data_func(renderer) { |col, renderer, model, iter| date_column_set_cell_data_function(col, renderer, model, iter) }
    @treeview.append_column(column)
    
    @treeview.append_column(Gtk::TreeViewColumn.new('Amount', Gtk::CellRendererText.new, :text => 3))
    @treeview.append_column(Gtk::TreeViewColumn.new('Payment form', Gtk::CellRendererText.new, :text => 5))
    @treeview.append_column(Gtk::TreeViewColumn.new('Expense type', Gtk::CellRendererText.new, :text => 7))
    @treeview.append_column(Gtk::TreeViewColumn.new('Description', Gtk::CellRendererText.new, :text => 8))

    renderer = Gtk::CellRendererText.new
    column = Gtk::TreeViewColumn.new('Accounting month', renderer)
    column.set_cell_data_func(renderer) { |col, renderer, model, iter| accounting_month_column_set_cell_data_function(col, renderer, model, iter) }
    @treeview.append_column(column)
    
    @treeview.append_column(Gtk::TreeViewColumn.new('Number of accounting month', Gtk::CellRendererText.new, :text => 10))
  end
  
  def show_all
    super
    on_refresh_toolbutton_clicked()
  end
  
private

  def date_column_set_cell_data_function(col, renderer, model, iter)
    renderer.text = iter[0].expense_date.to_s
  end

  def accounting_month_column_set_cell_data_function(col, renderer, model, iter)
    renderer.text = iter[0].accounting_month.to_s
  end

  def on_window_destroy
    hide_all
  end
  
  def on_refresh_toolbutton_clicked
    list_store = @treeview.model
    @treeview.model = nil
    list_store.clear
    expenses = @data_layer.get_expenses
    expenses.each do |expense|
      add_expense_to_list_store(list_store, expense)
    end
    @treeview.model = list_store
  end
  
  def add_expense_to_list_store(list_store, expense)
    iter = list_store.append
    iter[0] = expense
    update_iter(iter)
  end
  
  def update_iter(iter)
    expense = iter[0]
    iter[1] = expense.expense_id
    iter[2] = expense.expense_date
    iter[3] = expense.amount
    iter[4] = expense.payment_form.payment_form_id
    iter[5] = expense.payment_form.description
    iter[6] = expense.expense_type.expense_type_id
    iter[7] = expense.expense_type.description
    iter[8] = expense.description
    iter[9] = expense.accounting_month
    iter[10] = expense.number_accounting_month
  end

  def on_new_toolbutton_clicked
    expense = Expense.new(@data_layer)
    if open_expense_editor(expense)
      add_expense_to_list_store(@treeview.model, expense)
    end
  end

  def on_edit_toolbutton_clicked
    if @treeview.selection.selected
      if open_expense_editor(@treeview.selection.selected[0]) 
        update_iter(@treeview.selection.selected)
      end
    end
  end

  def on_delete_toolbutton_clicked
    if @treeview.selection.selected
    
      if open_expense_editor(@treeview.selection.selected[0]) 
        update_iter(@treeview.selection.selected)
      end
    end
  end

  def open_expense_editor(expense)
    expense_edit_window = ExpenseEditWindow.new(@data_layer, expense)
    expense_edit_window.transient_for = self
    expense_edit_window.window_position = Gtk::Window::Position::CENTER_ON_PARENT
    expense_edit_window.modal = true
    expense_edit_window.destroy_with_parent = true    
    expense_edit_window.skip_taskbar_hint = true
    expense_edit_window.skip_pager_hint = true
    accepted = expense_edit_window.run
#    expense_edit_window.destroy
    accepted
  end
end
