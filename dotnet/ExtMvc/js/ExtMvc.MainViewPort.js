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
						text: 'Search Category Normal',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Category Normal', ExtMvc.CategoryNormalSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'CustomerDemographic',
					children: [{
						text: 'Search CustomerDemographic Normal',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search CustomerDemographic Normal', ExtMvc.CustomerDemographicNormalSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Customer',
					children: [{
						text: 'Search Customer Normal',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Customer Normal', ExtMvc.CustomerNormalSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Employee',
					children: [{
						text: 'Search Employee Normal',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Employee Normal', ExtMvc.EmployeeNormalSearchContainer);
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
						text: 'Search Order Normal',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Order Normal', ExtMvc.OrderNormalSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Product',
					children: [{
						text: 'Search Product Normal',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Product Normal', ExtMvc.ProductNormalSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Region',
					children: [{
						text: 'Search Region Normal',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Region Normal', ExtMvc.RegionNormalSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Shipper',
					children: [{
						text: 'Search Shipper Normal',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Shipper Normal', ExtMvc.ShipperNormalSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Supplier',
					children: [{
						text: 'Search Supplier Normal',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Supplier Normal', ExtMvc.SupplierNormalSearchContainer);
							},
							scope: this
						}
					}]
				}, {
					text: 'Territory',
					children: [{
						text: 'Search Territory Normal',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('Search Territory Normal', ExtMvc.TerritoryNormalSearchContainer);
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