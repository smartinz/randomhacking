require 'rubygems'
require 'webrick'
require 'kramdown'
require 'pow' # http://github.com/probablycorey/pow

module DevWiki
	FILE_EXTENSION = 'markdown'
	
	class WikiServlet < WEBrick::HTTPServlet::AbstractServlet
		def do_GET(req, res)
			file_path = File.join(@server[:DocumentRoot], req.path)
			raise WEBrick::HTTPStatus::NotFound unless File.exist?(file_path)
			res['content-type'] = 'text/html'
			res.body = DevWiki.to_html(file_path)
		end
	end

	def self.to_html(file)
		html = ''
		File.open(File.join(File.dirname(__FILE__), 'page_template.html')) { |f| html = f.read }
		File.open(file) do	|f| 
			html.gsub!(/<!--\s*content\s*-->/, Kramdown::Document.new(f.read).to_html) 
		end
		html
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
					File.open(target_path, 'w') do |f|
						f.puts DevWiki.to_html(source_path)
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
	DevWiki.start_server
end