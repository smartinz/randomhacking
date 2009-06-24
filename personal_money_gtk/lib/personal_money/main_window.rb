class MainWindow < Gtk::Window
  def initialize(file_name, *args)
    super(*args)
    glade = GladeXML.new(File.join(File.dirname(__FILE__), 'main_window.glade'), 'vbox') { |handler| method(handler) }
    glade.widget_names.each do |name|
      instance_variable_set("@#{name}".intern, glade[name])
    end
    add(@vbox)
    signal_connect('destroy') { on_window_destroy }
    setup_data_layer(file_name)
  end

private

  def on_window_destroy
    hide_all()
  end
  
  def on_expenses_toolbutton_clicked
    expenses_window = ExpensesWindow.new(@data_layer)
    expenses_window.transient_for = self
    expenses_window.window_position = Gtk::Window::Position::CENTER
    expenses_window.destroy_with_parent = true    
    expenses_window.skip_taskbar_hint = true
    expenses_window.skip_pager_hint = true
    expenses_window.show_all
  end
  
  def on_open_toolbutton_clicked
    dialog = Gtk::FileChooserDialog.new("Open Personal Money Database", self, Gtk::FileChooser::ACTION_OPEN, nil, [Gtk::Stock::CANCEL, Gtk::Dialog::RESPONSE_CANCEL], [Gtk::Stock::OPEN, Gtk::Dialog::RESPONSE_ACCEPT])
    if dialog.run == Gtk::Dialog::RESPONSE_ACCEPT
      setup_data_layer dialog.filename
    end
    dialog.destroy
  end
  
  def setup_data_layer(file_name)
    if file_name
      @data_layer = DataLayer.new(file_name)
    else
      @data_layer = nil
    end
    self.title = "Personal Money [#{@data_layer.to_s}]"
    @expenses_toolbutton.sensitive = (@data_layer != nil)
  end
end
