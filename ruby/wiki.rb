require 'rubygems'
require 'webrick'
require 'kramdown'

DOCUMENT_ROOT = Dir.pwd
WEBSERVER_PORT = 2000

class WikiServlet < WEBrick::HTTPServlet::AbstractServlet
	def do_GET(req, res)
		file_path = DOCUMENT_ROOT + req.path
		raise WEBrick::HTTPStatus::NotFound unless File.exist?(file_path)
		res['content-type'] = 'text/html'
		File.open(file_path, 'r') do |f|
			res.body = Kramdown::Document.new(f.read).to_html
		end
	end
end

WEBrick::HTTPServlet::FileHandler.add_handler 'wiki', WikiServlet
server = WEBrick::HTTPServer.new(:Port => WEBSERVER_PORT, :DocumentRoot => DOCUMENT_ROOT)
['INT', 'TERM'].each do |signal|
	trap(signal) { server.shutdown }
end
server.start
