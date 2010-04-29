<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
	<script type="text/javascript" src="/js/ExtMvc.MainViewPort.js"></script>
	<script src="/js/ExtMvc.CustomerSearchPanel.js" type="text/javascript"></script>
	<script src="/js/ExtMvc.SearchCustomerWindow.js" type="text/javascript"></script>
	<script src="/js/ExtMvc.EditCustomerWindow.js" type="text/javascript"></script>
	<script src="/js/ExtMvc.CustomerGridPanel.js" type="text/javascript"></script>
	<script src="/js/ExtMvc.OrderGridPanel.js" type="text/javascript"></script>
	<script type="text/javascript">
		"use strict";

		Ext.onReady(function () {
			Ext.QuickTips.init();
			var mainViewport = new ExtMvc.MainViewport();

			var ogp = new ExtMvc.OrderGridPanel();
			var tt = new Ext.Window({
				title: 'Order',
				width: 600,
				height: 300,
				layout: 'fit',
				items: ogp
			});
			tt.show();
			ogp.getStore().load({
				params: Ext.apply({
					start: 0,
					limit: ogp.getBottomToolbar().pageSize // TODO not very good (break encapsulation)
				}, vals)
			});
		});
	</script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
</asp:Content>
