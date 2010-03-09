<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<html>
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Home Page</title>
	<link rel="stylesheet" type="text/css" href="<%= Url.Content("~/extjs/resources/css/ext-all.css") %>" />

	<script type="text/javascript" src="<%= Url.Content("~/extjs/adapter/ext/ext-base.js") %>"></script>

	<script type="text/javascript" src="<%= Url.Content("~/extjs/ext-all-debug.js") %>"></script>

	<script type="text/javascript" src="<%= Url.Content("~/js/app.Program.js") %>"></script>

	<script type="text/javascript" src="<%= Url.Content("~/js/app.ui.CustomerSearchNormalPanel.js") %>"></script>

	<script type="text/javascript" src="<%= Url.Content("~/Direct/Api") %>"></script>

	<script type="text/javascript">
		Ext.BLANK_IMAGE_URL = '<%= Url.Content("~/extjs/resources/images/default/s.gif") %>';

		var program = new app.Program();
		Ext.onReady(function() {
			Ext.Direct.addProvider(Ext.app.REMOTING_API);
			program.main();
		});
	</script>

</head>
<body />
</html>
