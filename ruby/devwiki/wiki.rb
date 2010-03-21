require 'rubygems'
require 'webrick'
require 'kramdown'
require 'pow' # http://github.com/probablycorey/pow

module DevWiki
	FILE_EXTENSION = 'markdown'
	
	class WikiServlet < WEBrick::HTTPServlet::AbstractServlet
		def self.get_instance(config, *options)
			WikiServlet.new config[:DocumentRoot]
		end

		def initialize(document_root)
			@document_root = document_root
		end

		def do_GET(req, res)
			file_path = File.join(@document_root, req.path)
			raise WEBrick::HTTPStatus::NotFound unless File.exist?(file_path)
			res['content-type'] = 'text/html'
			res.body = DevWiki.to_html(file_path)
		end
	end

	def self.to_html(file, file_extension = FILE_EXTENSION)
		file_content = ''
		File.open(file) {	|f| file_content = f.read }
		file_content = Kramdown::Document.new(file_content).to_html
		file_content.gsub!(/\[\[(\w+)\]\]/) do
      "<a href=\"#{$1}.#{file_extension}\">#{$1}</a>"
    end

		template_content = ''
		File.open(File.join(File.dirname(__FILE__), 'page_template.html')) { |f| template_content = f.read }
		template_content.gsub(/<!--\s*content\s*-->/, file_content)
	end
	
	def self.export(source_dir, target_dir)
		FileUtils.mkdir_p(target_dir) unless File.exist?(target_dir)
		Dir.foreach(source_dir) do |child|
			next if child == '.'
			next if child == '..'

			source_path = File.join(source_dir, child)
			target_path = File.join(target_dir, child)

			if File.file?(source_path)
				file_extension = File.extname(source_path)[1..-1]
				if file_extension == DevWiki::FILE_EXTENSION
					File.open(target_path[0..-(file_extension.length+1)] + 'html', 'w') do |f|
						f.puts DevWiki.to_html(source_path, 'html')
					end
				else
					FileUtils.cp source_path, target_path
				end
			else
				DevWiki.export source_path, target_path
			end
		end
	end

	def self.start_server(port = 2000, document_root = Dir.pwd)
		WEBrick::HTTPServlet::FileHandler.add_handler FILE_EXTENSION, DevWiki::WikiServlet
		server = WEBrick::HTTPServer.new(:Port => port, :DocumentRoot => document_root)
		['INT', 'TERM'].each do |signal|
			trap(signal) { server.shutdown }
		end
		server.start
	end
end

if $0 == __FILE__
	DevWiki.export File.dirname(__FILE__), 'c:/users/gimmi/temp/export'
	#DevWiki.start_server
end