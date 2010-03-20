require 'rubygems'
require 'webrick'
require 'kramdown'

module Wiki
	class WikiServlet < WEBrick::HTTPServlet::AbstractServlet
		def do_GET(req, res)
			file_path = File.join(@server[:DocumentRoot], req.path)
			raise WEBrick::HTTPStatus::NotFound unless File.exist?(file_path)
			res['content-type'] = 'text/html'
			res.body = Wiki.to_html(file_path)
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
	
	def self.export(target_dir, document_root = Dir.pwd)
		
	end

	def self.start_server(port = 2000, document_root = Dir.pwd)
		WEBrick::HTTPServlet::FileHandler.add_handler 'markdown', Wiki::WikiServlet
		server = WEBrick::HTTPServer.new(:Port => port, :DocumentRoot => document_root)
		['INT', 'TERM'].each do |signal|
			trap(signal) { server.shutdown }
		end
		server.start
	end
end

if $0 == __FILE__
	Wiki.start_server
end