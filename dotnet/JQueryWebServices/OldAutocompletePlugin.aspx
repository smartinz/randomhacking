<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OldAutocompletePlugin.aspx.cs"
	Inherits="JQueryWebServices.OldAutocompletePlugin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

	<script type="text/javascript" src="<%= ResolveUrl("~/js/jquery-1.3.2.min.js") %>"></script>

	<link type="text/css" href="<%= ResolveUrl("~/css/jquery.autocomplete.css") %>" rel="stylesheet" />

	<script type="text/javascript" src="<%= ResolveUrl("~/js/jquery.autocomplete.js") %>"></script>

</head>
<body>
	<form id="form1" runat="server">

	<script type="text/javascript">
		$(function() {
			$('#example').autocomplete('AutoCompleteHandler.ashx', {
				mustMatch: true,
				formatItem: function(item) {
					return item.toString().split('$')[1];
				},
				formatResult: function(item) {
					return item.toString().split('$')[1];
				}
			}).result(function(event, item) {
				$('#out').val(item ? item.toString().split('$')[0] : '');
			});
		});
	</script>

	<input id="example" />
	<input id="out" />
	</form>
</body>
</html>
