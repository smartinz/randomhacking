<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
	<script type="text/javascript" src="/js/ExtMvc.MainViewPort.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CategoryGridPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CustomerDemographicGridPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CustomerGridPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.EmployeeGridPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.OrderDetailGridPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.OrderGridPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.ProductGridPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.RegionGridPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.ShipperGridPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.SupplierGridPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.SysdiagramGridPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.TerritoryGridPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CategoryJsonReader.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CustomerDemographicJsonReader.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CustomerJsonReader.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.EmployeeJsonReader.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.OrderDetailJsonReader.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.OrderJsonReader.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.ProductJsonReader.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.RegionJsonReader.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.ShipperJsonReader.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.SupplierJsonReader.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.SysdiagramJsonReader.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.TerritoryJsonReader.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CategorySearchContainer.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CustomerDemographicSearchContainer.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CustomerSearchContainer.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.EmployeeSearchContainer.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.OrderDetailSearchContainer.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.OrderSearchContainer.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.ProductSearchContainer.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.RegionSearchContainer.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.ShipperSearchContainer.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.SupplierSearchContainer.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.SysdiagramSearchContainer.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.TerritorySearchContainer.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CategoryField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CustomerDemographicField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CustomerField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.EmployeeField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.OrderDetailField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.OrderField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.ProductField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.RegionField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.ShipperField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.SupplierField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.SysdiagramField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.TerritoryField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CategoryFormPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CustomerDemographicFormPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CustomerFormPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.EmployeeFormPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.OrderDetailFormPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.OrderFormPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.ProductFormPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.RegionFormPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.ShipperFormPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.SupplierFormPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.SysdiagramFormPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.TerritoryFormPanel.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CategoryListField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CustomerDemographicListField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.CustomerListField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.EmployeeListField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.OrderDetailListField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.OrderListField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.ProductListField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.RegionListField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.ShipperListField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.SupplierListField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.SysdiagramListField.js"></script>
	<script type="text/javascript" src="/js/ExtMvc.TerritoryListField.js"></script>
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
