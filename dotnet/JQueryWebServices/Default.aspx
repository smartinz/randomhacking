<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JQueryWebServices._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link type="text/css" href="<%= ResolveUrl("~/css/ui-lightness/jquery-ui-1.7.2.custom.css") %>"
		rel="stylesheet" />

	<script type="text/javascript" src="<%= ResolveUrl("~/js/jquery-1.3.2.min.js") %>"></script>

	<script type="text/javascript" src="<%= ResolveUrl("~/js/jquery-ui-1.7.2.custom.min.js") %>"></script>

	<link type="text/css" href="<%= ResolveUrl("~/css/ui.autocomplete.css") %>" rel="stylesheet" />
	<link href="css/ui.menu.css" rel="stylesheet" type="text/css" />

	<script src="js/jquery.ui.menu.js" type="text/javascript"></script>

	<script src="js/jquery.ui.position.js" type="text/javascript"></script>

	<script src="<%= ResolveUrl("~/js/jquery.ui.autocomplete.js") %>" type="text/javascript"></script>

</head>
<body>
	<form id="form1" runat="server">

	<script type="text/javascript">
		$(function() {
			$('#in').autocomplete({
				source: function(request, response) {
					$.ajax({
						type: 'POST',
						url: 'ExampleService.asmx/HelloWorld',
						data: '{"q":"' + request.term + '"}',
						contentType: 'application/json; charset=utf-8',
						dataType: 'json',
						success: function(data) {
							response(data.d);
						}
					});
				},
				change: function(event, ui) {
					// "ui" parameter can be "undefined" when using jquery.ui.autocomplete with jquery-ui-1.7.2
					$('#out').val(ui == undefined || ui.item == undefined ? '' : ui.item.id);
				}
			});
		});
	</script>

	<input id="in" type="text" />
	<input id="out" type="text" />
	</form>
</body>
</html>
