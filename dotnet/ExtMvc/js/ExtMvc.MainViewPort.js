/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace('ExtMvc');

ExtMvc.MainViewport = Ext.extend(Ext.Viewport, {
	layout: 'border',
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
						text: 'Search Category',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Category', ExtMvc.CategorySearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'CustomerDemographic',
					children: [{
						text: 'Search CustomerDemographic',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search CustomerDemographic', ExtMvc.CustomerDemographicSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Customer',
					children: [{
						text: 'Search Customer',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Customer', ExtMvc.CustomerSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Employee',
					children: [{
						text: 'Search Employee',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Employee', ExtMvc.EmployeeSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'OrderDetail',
					children: [{
						text: 'Search OrderDetail',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search OrderDetail', ExtMvc.OrderDetailSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Order',
					children: [{
						text: 'Search Order',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Order', ExtMvc.OrderSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Product',
					children: [{
						text: 'Search Product',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Product', ExtMvc.ProductSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Region',
					children: [{
						text: 'Search Region',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Region', ExtMvc.RegionSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Shipper',
					children: [{
						text: 'Search Shipper',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Shipper', ExtMvc.ShipperSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Supplier',
					children: [{
						text: 'Search Supplier',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Supplier', ExtMvc.SupplierSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Sysdiagram',
					children: [{
						text: 'Search Sysdiagram',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Sysdiagram', ExtMvc.SysdiagramSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Territory',
					children: [{
						text: 'Search Territory',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Territory', ExtMvc.TerritorySearchContainer);
							},
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

	openTab: function (title, Constructor) {
		var tab;

		Ext.each(this.tabPanel.items.items, function (item) {
			if (item.title === title) {
				tab = item;
				return false;
			}
		});

		tab = tab || this.tabPanel.add(new Constructor({
			title: title,
			closable: true
		}));

		tab.show();
	}
});