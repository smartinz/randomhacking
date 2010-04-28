<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
	<script type="text/javascript" src="/js/ExtMvc.MainViewPort.js"></script>
	<script src="/js/ExtMvc.CustomerSearchPanel.js" type="text/javascript"></script>
	<script src="/js/ExtMvc.SearchCustomerWindow.js" type="text/javascript"></script>
	<script src="/js/ExtMvc.EditCustomerWindow.js" type="text/javascript"></script>
	<script src="/js/ExtMvc.CustomerGridPanel.js" type="text/javascript"></script>

	<script type="text/javascript">
		"use strict";

		Ext.onReady(function () {
			var mainViewport = new ExtMvc.MainViewport();
		});
	</script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
</asp:Content>
