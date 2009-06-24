class ExpenseEditWindow < Gtk::Window
  def initialize(data_layer, expense)
    super()
    glade = GladeXML.new(File.join(File.dirname(__FILE__), 'expense_edit_window.glade'), 'table') { |handler| method(handler) }
    glade.widget_names.each do |name|
      instance_variable_set("@#{name}".intern, glade[name])
    end
    set_default_size(300, 200)
    add(@table)
    @data_layer = data_layer
    @expense = expense

    @expense_type_combobox.clear
    @expense_type_combobox.model = Gtk::ListStore.new(ExpenseType, String)
    cell_renderer_text = Gtk::CellRendererText.new
    @expense_type_combobox.pack_start(cell_renderer_text, false)
    @expense_type_combobox.set_attributes(cell_renderer_text, :text => 1)

    @payment_form_combobox.clear
    @payment_form_combobox.model = Gtk::ListStore.new(PaymentForm, String)
    cell_renderer_text = Gtk::CellRendererText.new
    @payment_form_combobox.pack_start(cell_renderer_text, false)
    @payment_form_combobox.set_attributes(cell_renderer_text, :text => 1)
        
    load_expense_type_combobox
    load_payment_form_combobox
    setup_expense
    
    @accepted = false
  end
  
  attr_reader :accepted
  
  def run
    signal_connect('hide') { |window| Gtk.main_quit }
    self.show_all
    Gtk.main
    @accepted
  end

private

  def load_expense_type_combobox
    @expense_type_to_iter_hash = {}
    list_store = @expense_type_combobox.model
    list_store.clear
    expense_types = @data_layer.get_expense_types.sort! { |a, b| a.description <=> b.description }
    expense_types.each do |expense_type|
      iter = list_store.append
      iter[0] = expense_type
      iter[1] = expense_type.description
      @expense_type_to_iter_hash[expense_type] = iter
    end
    @expense_type_combobox.active = 0
  end
  
  def load_payment_form_combobox
    @payment_form_to_iter_hash = {}
    list_store = @payment_form_combobox.model
    list_store.clear
    payment_forms = @data_layer.get_payment_forms.sort! { |a, b| a.description <=> b.description }
    payment_forms.each do |payment_form|
      iter = list_store.append
      iter[0] = payment_form
      iter[1] = payment_form.description
      @payment_form_to_iter_hash[payment_form] = iter
    end
    @payment_form_combobox.active = 0
  end

  def on_ok_button_clicked
    begin
      expense_date = Date.parse(@expense_date_entry.text, true)
      amount = @amount_entry.text.to_f
      expense_type = @expense_type_combobox.active_iter[0]
      payment_form = @payment_form_combobox.active_iter[0]
      description = @description_entry.text
      accounting_month = Date.parse(@accounting_month_entry.text)
      number_accounting_month = @number_accounting_month_entry.text.to_i
      @expense.expense_date = expense_date
      @expense.amount = amount
      @expense.expense_type = expense_type
      @expense.payment_form = payment_form
      @expense.description = description
      @expense.accounting_month = accounting_month
      @expense.number_accounting_month = number_accounting_month
      @expense.save(@data_layer)
    rescue 
      show_error_dialog(self, $!)
      return
    end
    @accepted = true
    hide
  end

  def on_cancel_button_clicked
    @accepted = false
    hide
  end

  def setup_expense
    self.title = "Edit [#{@expense.to_s}]"
    @expense_date_entry.text = @expense.expense_date.to_s
    @amount_entry.text = @expense.amount.to_s
    @expense_type_combobox.active_iter = @expense_type_to_iter_hash[@expense.expense_type] if @expense_type_to_iter_hash[@expense.expense_type]
    @payment_form_combobox.active_iter = @payment_form_to_iter_hash[@expense.payment_form] if @payment_form_to_iter_hash[@expense.payment_form]
    @description_entry.text = @expense.description
    @accounting_month_entry.text = @expense.accounting_month.to_s
    @number_accounting_month_entry.text = @expense.number_accounting_month.to_s
  end
  
  def show_error_dialog(parent_window, message)
    dialog = Gtk::MessageDialog.new(parent_window, Gtk::Dialog::DESTROY_WITH_PARENT, Gtk::MessageDialog::ERROR, Gtk::MessageDialog::BUTTONS_OK, message)
    dialog.run
    dialog.destroy
  end
end
