#!/usr/bin/env ruby
require File.join(File.dirname(__FILE__), '..', 'lib', 'personal_money')

main_window = MainWindow.new(File.join(File.dirname(__FILE__), 'personal_money.sqlite3'))
main_window.signal_connect('destroy') { Gtk.main_quit }
main_window.show_all
Gtk.main

