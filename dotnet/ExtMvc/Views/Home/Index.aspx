<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!doctype html>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link rel="stylesheet" type="text/css" href="<%=Url.Content("~/ext/resources/css/ext-all.css")%>" />
	<script type="text/javascript" src="<%=Url.Content("~/ext/adapter/ext/ext-base-debug.js")%>"></script>
	<script type="text/javascript" src="<%=Url.Content("~/ext/ext-all-debug.js")%>"></script>
	<script type="text/javascript" src="<%=Url.Content("~/js/ExtMvc.MainViewport.js")%>"></script>
	<script type="text/javascript">
		"use strict";

		Ext.BLANK_IMAGE_URL = 'extjs/resources/images/default/s.gif';

		Ext.onReady(function () {
			var mainViewport = new ExtMvc.MainViewport();
		});
	</script>
	<title></title>
</head>
<body>
</body>
</html>
