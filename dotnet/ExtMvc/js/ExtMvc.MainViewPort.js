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
								var tab = this.openTab('Search Category Normal', ExtMvc.CategoryNormalSearchContainer);
								tab.on('itemselected', function(sender, item) {
									var description = ExtMvc.Category.toString(item);
									this.openTab('Category ' + description, ExtMvc.CategoryFormPanel);
								}, this);
							},
							scope: this
						}
					}, {
						text: 'Create Category',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('New Category', ExtMvc.CategoryFormPanel);
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
								var tab = this.openTab('Search CustomerDemographic Normal', ExtMvc.CustomerDemographicNormalSearchContainer);
								tab.on('itemselected', function(sender, item) {
									var description = ExtMvc.CustomerDemographic.toString(item);
									this.openTab('CustomerDemographic ' + description, ExtMvc.CustomerDemographicFormPanel);
								}, this);
							},
							scope: this
						}
					}, {
						text: 'Create CustomerDemographic',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('New CustomerDemographic', ExtMvc.CustomerDemographicFormPanel);
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
								var tab = this.openTab('Search Customer Normal', ExtMvc.CustomerNormalSearchContainer);
								tab.on('itemselected', function(sender, item) {
									var description = ExtMvc.Customer.toString(item);
									this.openTab('Customer ' + description, ExtMvc.CustomerFormPanel);
								}, this);
							},
							scope: this
						}
					}, {
						text: 'Create Customer',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('New Customer', ExtMvc.CustomerFormPanel);
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
								var tab = this.openTab('Search Employee Normal', ExtMvc.EmployeeNormalSearchContainer);
								tab.on('itemselected', function(sender, item) {
									var description = ExtMvc.Employee.toString(item);
									this.openTab('Employee ' + description, ExtMvc.EmployeeFormPanel);
								}, this);
							},
							scope: this
						}
					}, {
						text: 'Create Employee',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('New Employee', ExtMvc.EmployeeFormPanel);
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
								var tab = this.openTab('Search OrderDetail', ExtMvc.OrderDetailSearchContainer);
								tab.on('itemselected', function(sender, item) {
									var description = ExtMvc.OrderDetail.toString(item);
									this.openTab('OrderDetail ' + description, ExtMvc.OrderDetailFormPanel);
								}, this);
							},
							scope: this
						}
					}, {
						text: 'Create OrderDetail',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('New OrderDetail', ExtMvc.OrderDetailFormPanel);
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
								var tab = this.openTab('Search Order Normal', ExtMvc.OrderNormalSearchContainer);
								tab.on('itemselected', function(sender, item) {
									var description = ExtMvc.Order.toString(item);
									this.openTab('Order ' + description, ExtMvc.OrderFormPanel);
								}, this);
							},
							scope: this
						}
					}, {
						text: 'Create Order',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('New Order', ExtMvc.OrderFormPanel);
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
								var tab = this.openTab('Search Product Normal', ExtMvc.ProductNormalSearchContainer);
								tab.on('itemselected', function(sender, item) {
									var description = ExtMvc.Product.toString(item);
									this.openTab('Product ' + description, ExtMvc.ProductFormPanel);
								}, this);
							},
							scope: this
						}
					}, {
						text: 'Create Product',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('New Product', ExtMvc.ProductFormPanel);
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
								var tab = this.openTab('Search Region Normal', ExtMvc.RegionNormalSearchContainer);
								tab.on('itemselected', function(sender, item) {
									var description = ExtMvc.Region.toString(item);
									this.openTab('Region ' + description, ExtMvc.RegionFormPanel);
								}, this);
							},
							scope: this
						}
					}, {
						text: 'Create Region',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('New Region', ExtMvc.RegionFormPanel);
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
								var tab = this.openTab('Search Shipper Normal', ExtMvc.ShipperNormalSearchContainer);
								tab.on('itemselected', function(sender, item) {
									var description = ExtMvc.Shipper.toString(item);
									this.openTab('Shipper ' + description, ExtMvc.ShipperFormPanel);
								}, this);
							},
							scope: this
						}
					}, {
						text: 'Create Shipper',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('New Shipper', ExtMvc.ShipperFormPanel);
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
								var tab = this.openTab('Search Supplier Normal', ExtMvc.SupplierNormalSearchContainer);
								tab.on('itemselected', function(sender, item) {
									var description = ExtMvc.Supplier.toString(item);
									this.openTab('Supplier ' + description, ExtMvc.SupplierFormPanel);
								}, this);
							},
							scope: this
						}
					}, {
						text: 'Create Supplier',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('New Supplier', ExtMvc.SupplierFormPanel);
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
								var tab = this.openTab('Search Territory Normal', ExtMvc.TerritoryNormalSearchContainer);
								tab.on('itemselected', function(sender, item) {
									var description = ExtMvc.Territory.toString(item);
									this.openTab('Territory ' + description, ExtMvc.TerritoryFormPanel);
								}, this);
							},
							scope: this
						}
					}, {
						text: 'Create Territory',
						leaf: true,
						listeners: {
							click: function () {
								this.openTab('New Territory', ExtMvc.TerritoryFormPanel);
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
		return tab;
	}
});