<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JQueryWebServices._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

	<script type="text/javascript" src="<%= ResolveUrl("~/js/jquery-1.3.2.min.js") %>"></script>

</head>
<body>
	<form id="form1" runat="server">

	<script type="text/javascript">
		$(function() {
			$('#go').click(function() {
				$.ajax({
					type: 'POST',
					url: 'ExampleService.asmx/HelloWorld',
					data: '{"q":"' + $('#in').val() + '"}',
					contentType: 'application/json; charset=utf-8',
					dataType: 'json',
					success: function(msg) {
						$('#out').html(msg.d[0].description);
					}
				});
			});
		});
	</script>

	<input id="in" type="text" />
	<input id="go" type="button" value="GO" />
	<div id="out" />
	</form>
</body>
</html>
