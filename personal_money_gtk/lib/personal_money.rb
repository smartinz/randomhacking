begin
  require 'rubygems'
rescue LoadError
end
require 'date'
require 'gtk2'
require 'libglade2'
require 'sqlite3'
require File.join(File.dirname(__FILE__), 'personal_money', 'data_layer')
require File.join(File.dirname(__FILE__), 'personal_money', 'expense')
require File.join(File.dirname(__FILE__), 'personal_money', 'payment_form')
require File.join(File.dirname(__FILE__), 'personal_money', 'expense_type')
require File.join(File.dirname(__FILE__), 'personal_money', 'main_window')
require File.join(File.dirname(__FILE__), 'personal_money', 'expense_edit_window')
require File.join(File.dirname(__FILE__), 'personal_money', 'expenses_window')

