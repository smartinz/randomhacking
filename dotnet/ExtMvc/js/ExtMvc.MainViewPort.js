/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace('ExtMvc');

ExtMvc.MainViewport = Ext.extend(Ext.Viewport, {
	layout: 'fit',
	hideBorders: true,
	initComponent: function () {
		this.items = [{
			xtype: 'panel',
			tbar: {
				xtype: 'toolbar',
				items: [{
					text: 'Category',
					menu: {
						items: [{
							text: 'Search ',
							handler: this.searchCategoryClick,
							scope: this
						}]
					}
				}, {
					text: 'CustomerDemographic',
					menu: {
						items: [{
							text: 'Search ',
							handler: this.searchCustomerDemographicClick,
							scope: this
						}]
					}
				}, {
					text: 'Customer',
					menu: {
						items: [{
							text: 'Search ',
							handler: this.searchCustomerClick,
							scope: this
						}]
					}
				}, {
					text: 'Employee',
					menu: {
						items: [{
							text: 'Search ',
							handler: this.searchEmployeeClick,
							scope: this
						}]
					}
				}, {
					text: 'OrderDetail',
					menu: {
						items: [{
							text: 'Search ',
							handler: this.searchOrderDetailClick,
							scope: this
						}]
					}
				}, {
					text: 'Order',
					menu: {
						items: [{
							text: 'Search ',
							handler: this.searchOrderClick,
							scope: this
						}]
					}
				}, {
					text: 'Product',
					menu: {
						items: [{
							text: 'Search ',
							handler: this.searchProductClick,
							scope: this
						}]
					}
				}, {
					text: 'Region',
					menu: {
						items: [{
							text: 'Search ',
							handler: this.searchRegionClick,
							scope: this
						}]
					}
				}, {
					text: 'Shipper',
					menu: {
						items: [{
							text: 'Search ',
							handler: this.searchShipperClick,
							scope: this
						}]
					}
				}, {
					text: 'Supplier',
					menu: {
						items: [{
							text: 'Search ',
							handler: this.searchSupplierClick,
							scope: this
						}]
					}
				}, {
					text: 'Sysdiagram',
					menu: {
						items: [{
							text: 'Search ',
							handler: this.searchSysdiagramClick,
							scope: this
						}]
					}
				}, {
					text: 'Territory',
					menu: {
						items: [{
							text: 'Search ',
							handler: this.searchTerritoryClick,
							scope: this
						}]
					}
				}]
			}
		}];
		ExtMvc.MainViewport.superclass.initComponent.call(this);
	},
	
	searchCategoryClick: function () {
			var window = new Ext.Window({
				title: 'Search Category ',
				width: 300,
				height: 300,
				layout: 'fit',
				maximizable: true,
				items: new ExtMvc.CategorySearchContainer()
			});
			window.show();
		}, searchCustomerDemographicClick: function () {
			var window = new Ext.Window({
				title: 'Search CustomerDemographic ',
				width: 300,
				height: 300,
				layout: 'fit',
				maximizable: true,
				items: new ExtMvc.CustomerDemographicSearchContainer()
			});
			window.show();
		}, searchCustomerClick: function () {
			var window = new Ext.Window({
				title: 'Search Customer ',
				width: 300,
				height: 300,
				layout: 'fit',
				maximizable: true,
				items: new ExtMvc.CustomerSearchContainer()
			});
			window.show();
		}, searchEmployeeClick: function () {
			var window = new Ext.Window({
				title: 'Search Employee ',
				width: 300,
				height: 300,
				layout: 'fit',
				maximizable: true,
				items: new ExtMvc.EmployeeSearchContainer()
			});
			window.show();
		}, searchOrderDetailClick: function () {
			var window = new Ext.Window({
				title: 'Search OrderDetail ',
				width: 300,
				height: 300,
				layout: 'fit',
				maximizable: true,
				items: new ExtMvc.OrderDetailSearchContainer()
			});
			window.show();
		}, searchOrderClick: function () {
			var window = new Ext.Window({
				title: 'Search Order ',
				width: 300,
				height: 300,
				layout: 'fit',
				maximizable: true,
				items: new ExtMvc.OrderSearchContainer()
			});
			window.show();
		}, searchProductClick: function () {
			var window = new Ext.Window({
				title: 'Search Product ',
				width: 300,
				height: 300,
				layout: 'fit',
				maximizable: true,
				items: new ExtMvc.ProductSearchContainer()
			});
			window.show();
		}, searchRegionClick: function () {
			var window = new Ext.Window({
				title: 'Search Region ',
				width: 300,
				height: 300,
				layout: 'fit',
				maximizable: true,
				items: new ExtMvc.RegionSearchContainer()
			});
			window.show();
		}, searchShipperClick: function () {
			var window = new Ext.Window({
				title: 'Search Shipper ',
				width: 300,
				height: 300,
				layout: 'fit',
				maximizable: true,
				items: new ExtMvc.ShipperSearchContainer()
			});
			window.show();
		}, searchSupplierClick: function () {
			var window = new Ext.Window({
				title: 'Search Supplier ',
				width: 300,
				height: 300,
				layout: 'fit',
				maximizable: true,
				items: new ExtMvc.SupplierSearchContainer()
			});
			window.show();
		}, searchSysdiagramClick: function () {
			var window = new Ext.Window({
				title: 'Search Sysdiagram ',
				width: 300,
				height: 300,
				layout: 'fit',
				maximizable: true,
				items: new ExtMvc.SysdiagramSearchContainer()
			});
			window.show();
		}, searchTerritoryClick: function () {
			var window = new Ext.Window({
				title: 'Search Territory ',
				width: 300,
				height: 300,
				layout: 'fit',
				maximizable: true,
				items: new ExtMvc.TerritorySearchContainer()
			});
			window.show();
		}
});