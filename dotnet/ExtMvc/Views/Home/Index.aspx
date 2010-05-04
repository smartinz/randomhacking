<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
	<script type="text/javascript" src="/js/ExtMvc.MainViewPort.js"></script>
	<script src="/js/ExtMvc.CustomerSearchContainer.js" type="text/javascript"></script>
	<script src="/js/ExtMvc.CustomerJsonReader.js" type="text/javascript"></script>
	<script src="/js/ExtMvc.CustomerGridPanel.js" type="text/javascript"></script>
	<script src="/js/ExtMvc.OrderGridPanel.js" type="text/javascript"></script>
	<script src="/js/ExtMvc.OrderJsonReader.js" type="text/javascript"></script>
	<script src="/js/ExtMvc.OrderListField.js" type="text/javascript"></script>
	<script src="/js/ExtMvc.CustomerFormPanel.js" type="text/javascript"></script>
	<script src="/js/ExtMvc.CustomerField.js" type="text/javascript"></script>
	<script type="text/javascript">
		"use strict";

		Ext.onReady(function () {
			Ext.QuickTips.init();
			var mainViewport = new ExtMvc.MainViewport();
		});
	</script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
</asp:Content>
