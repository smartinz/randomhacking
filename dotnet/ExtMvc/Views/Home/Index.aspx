<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!doctype html>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<link rel="stylesheet" type="text/css" href="/ext/resources/css/ext-all.css" />
		<script type="text/javascript" src="/ext/adapter/ext/ext-base-debug-w-comments.js"></script>
		<script type="text/javascript" src="/ext/ext-all-debug-w-comments.js"></script>
		<script type="text/javascript" src="/js/Rpc.js"></script>
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
				<script type="text/javascript" src="/js/ExtMvc.TerritoryJsonReader.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.CategoryNormalSearchContainer.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.CustomerDemographicNormalSearchContainer.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.CustomerNormalSearchContainer.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.EmployeeNormalSearchContainer.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.OrderDetailSearchContainer.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.OrderNormalSearchContainer.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.ProductNormalSearchContainer.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.RegionNormalSearchContainer.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.ShipperNormalSearchContainer.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.SupplierNormalSearchContainer.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.TerritoryNormalSearchContainer.js"></script>
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
				<script type="text/javascript" src="/js/ExtMvc.TerritoryListField.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.MainViewPort.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.CategoryColumn.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.CustomerDemographicColumn.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.CustomerColumn.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.EmployeeColumn.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.OrderDetailColumn.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.OrderColumn.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.ProductColumn.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.RegionColumn.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.ShipperColumn.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.SupplierColumn.js"></script>
				<script type="text/javascript" src="/js/ExtMvc.TerritoryColumn.js"></script>
				
		<script type="text/javascript">
			"use strict";

			Ext.BLANK_IMAGE_URL = '/ext/resources/images/default/s.gif';
			Ext.USE_NATIVE_JSON = true;

			Ext.onReady(function () {
				Ext.QuickTips.init();
				var mainViewport = new ExtMvc.MainViewport();
			});
		</script>
		<title></title>
	</head>
	<body>
	</body>
</html>