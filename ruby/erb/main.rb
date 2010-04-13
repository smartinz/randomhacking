require 'erb'

template = ERB.new(File.read("new_view.erb"))
puts template.run(binding)
