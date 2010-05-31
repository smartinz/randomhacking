/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace('ExtMvc');

ExtMvc.MainViewport = Ext.extend(Ext.Viewport, {
	layout: 'border',
	hideBorders: true,
	initComponent: function () {

		this.treePanel = new Ext.tree.TreePanel({
			xtype: 'treepanel',
			title: 'Main Menu',
			region: 'west',
			split: true,
			collapsible: true,
			width: 200,
			rootVisible: false,
			root: {
				text: 'Root Node',
				children: [{
					text: 'Category',
					children: [{
						text: 'Search ',
						leaf: true,
						listeners: {
							click: this.searchCategoryClick,
							scope: this
						}
					}]
				}, {
					text: 'CustomerDemographic',
					children: [{
						text: 'Search ',
						leaf: true,
						listeners: {
							click: this.searchCustomerDemographicClick,
							scope: this
						}
					}]
				}, {
					text: 'Customer',
					children: [{
						text: 'Search ',
						leaf: true,
						listeners: {
							click: this.searchCustomerClick,
							scope: this
						}
					}]
				}, {
					text: 'Employee',
					children: [{
						text: 'Search ',
						leaf: true,
						listeners: {
							click: this.searchEmployeeClick,
							scope: this
						}
					}]
				}, {
					text: 'OrderDetail',
					children: [{
						text: 'Search ',
						leaf: true,
						listeners: {
							click: this.searchOrderDetailClick,
							scope: this
						}
					}]
				}, {
					text: 'Order',
					children: [{
						text: 'Search ',
						leaf: true,
						listeners: {
							click: this.searchOrderClick,
							scope: this
						}
					}]
				}, {
					text: 'Product',
					children: [{
						text: 'Search ',
						leaf: true,
						listeners: {
							click: this.searchProductClick,
							scope: this
						}
					}]
				}, {
					text: 'Region',
					children: [{
						text: 'Search ',
						leaf: true,
						listeners: {
							click: this.searchRegionClick,
							scope: this
						}
					}]
				}, {
					text: 'Shipper',
					children: [{
						text: 'Search ',
						leaf: true,
						listeners: {
							click: this.searchShipperClick,
							scope: this
						}
					}]
				}, {
					text: 'Supplier',
					children: [{
						text: 'Search ',
						leaf: true,
						listeners: {
							click: this.searchSupplierClick,
							scope: this
						}
					}]
				}, {
					text: 'Sysdiagram',
					children: [{
						text: 'Search ',
						leaf: true,
						listeners: {
							click: this.searchSysdiagramClick,
							scope: this
						}
					}]
				}, {
					text: 'Territory',
					children: [{
						text: 'Search ',
						leaf: true,
						listeners: {
							click: this.searchTerritoryClick,
							scope: this
						}
					}]
				}]
			},
			loader: {}
		});

		this.tabPanel = new Ext.TabPanel({
			xtype: 'tabpanel',
			activeTab: 0,
			region: 'center',
			items: [{
				xtype: 'panel',
				title: 'Welcome Page'
			}]
		});

		this.items = [this.treePanel, this.tabPanel];
		ExtMvc.MainViewport.superclass.initComponent.call(this);
	},

	searchCategoryClick: function () {
		this.tabPanel.add(new ExtMvc.CategorySearchContainer({
			title: 'Search Category ',
			closable: true
		})).show();
	},

	searchCustomerDemographicClick: function () {
		this.tabPanel.add(new ExtMvc.CustomerDemographicSearchContainer({
			title: 'Search CustomerDemographic ',
			closable: true
		})).show();
	},

	searchCustomerClick: function () {
		this.tabPanel.add(new ExtMvc.CustomerSearchContainer({
			title: 'Search Customer ',
			closable: true
		})).show();
	},

	searchEmployeeClick: function () {
		this.tabPanel.add(new ExtMvc.EmployeeSearchContainer({
			title: 'Search Employee ',
			closable: true
		})).show();
	},

	searchOrderDetailClick: function () {
		this.tabPanel.add(new ExtMvc.OrderDetailSearchContainer({
			title: 'Search OrderDetail ',
			closable: true
		})).show();
	},

	searchOrderClick: function () {
		this.tabPanel.add(new ExtMvc.OrderSearchContainer({
			title: 'Search Order ',
			closable: true
		})).show();
	},

	searchProductClick: function () {
		this.tabPanel.add(new ExtMvc.ProductSearchContainer({
			title: 'Search Product ',
			closable: true
		})).show();
	},

	searchRegionClick: function () {
		this.tabPanel.add(new ExtMvc.RegionSearchContainer({
			title: 'Search Region ',
			closable: true
		})).show();
	},

	searchShipperClick: function () {
		this.tabPanel.add(new ExtMvc.ShipperSearchContainer({
			title: 'Search Shipper ',
			closable: true
		})).show();
	},

	searchSupplierClick: function () {
		this.tabPanel.add(new ExtMvc.SupplierSearchContainer({
			title: 'Search Supplier ',
			closable: true
		})).show();
	},

	searchSysdiagramClick: function () {
		this.tabPanel.add(new ExtMvc.SysdiagramSearchContainer({
			title: 'Search Sysdiagram ',
			closable: true
		})).show();
	},

	searchTerritoryClick: function () {
		this.tabPanel.add(new ExtMvc.TerritorySearchContainer({
			title: 'Search Territory ',
			closable: true
		})).show();
	}
});