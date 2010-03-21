require 'rubygems'
require 'webrick'
require 'kramdown'

module DevWiki
	WIKI_FILE_EXTENSION = 'markdown'
	EXPORTED_WIKI_FILE_EXTENSION = 'html'
	TEMPLATE_FILE_PATH = File.join(File.dirname(__FILE__), 'page_template.html')
	
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

	def self.to_html(file, file_extension = WIKI_FILE_EXTENSION)
		file_content = ''
		File.open(file) {	|f| file_content = f.read }
		file_content = Kramdown::Document.new(file_content).to_html
		file_content.gsub!(/\[\[(\w+)\]\]/) do
      "<a href=\"#{$1}.#{file_extension}\">#{$1}</a>"
    end

		template_content = ''
		File.open(TEMPLATE_FILE_PATH) { |f| template_content = f.read }
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
				if file_extension == DevWiki::WIKI_FILE_EXTENSION
					File.open(replace_file_extension(target_path, EXPORTED_WIKI_FILE_EXTENSION), 'w') do |f|
						f.puts DevWiki.to_html(source_path, EXPORTED_WIKI_FILE_EXTENSION)
					end
				else
					FileUtils.cp source_path, target_path
				end
			else
				DevWiki.export source_path, target_path
			end
		end
	end

	def self.replace_file_extension(file_name, new_extension)
		old_extension = File.extname(file_name)[1..-1]
		file_name[0..-(old_extension.length+1)] + new_extension
	end

	def self.start_server(port = 2000, document_root = Dir.pwd)
		WEBrick::HTTPServlet::FileHandler.add_handler WIKI_FILE_EXTENSION, DevWiki::WikiServlet
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