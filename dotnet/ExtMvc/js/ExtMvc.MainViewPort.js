"use strict";

Ext.namespace("ExtMvc");

ExtMvc.MainViewport = Ext.extend(Ext.Viewport, {
	layout: 'fit',
	hideBorders: true,
	initComponent: function () {
		this.items = [{
			xtype: 'panel',
			tbar: {
				xtype: 'toolbar',
				items: [{
					xtype: 'button',
					text: 'Search Customer',
					handler: this.searchCustomerClick,
					scope: this
				}, {
					xtype: 'button',
					text: 'Edit Customer',
					handler: this.editCustomerClick,
					scope: this
				}, {
					xtype: 'button',
					text: 'Test',
					handler: this.testClick,
					scope: this
				}]
			}
		}];
		ExtMvc.MainViewport.superclass.initComponent.call(this);
	},

	searchCustomerClick: function () {
		var window = new Ext.Window({
			title: 'Search Customer',
			width: 600,
			height: 300,
			layout: 'fit',
			items: new ExtMvc.CustomerSearchContainer()
		});
		window.show();
	},

	editCustomerClick: function () {
		var window = new Ext.Window({
			title: 'Edit Customer',
			width: 300,
			height: 300,
			layout: 'fit',
			items: new ExtMvc.CustomerFormPanel()
		});
		window.show();
	},

	testClick: function () {
		var obj = JSON.parse('{"OrderId":10643,"OrderDate":"\/Date(872460000000)\/","RequiredDate":"\/Date(874879200000)\/","ShippedDate":"\/Date(873151200000)\/","Freight":29.4600,"ShipName":"Alfreds Futterkiste","ShipAddress":"Obere Str. 57","ShipCity":"Berlin","ShipRegion":null,"ShipPostalCode":"12209","ShipCountry":"Germany"}');
		var lvc = new ExtMvc.OrderListViewContainer({
			dataProxy: new Ext.data.MemoryProxy({ items: obj })
		});
		var window = new Ext.Window({
			title: 'Test',
			width: 600,
			height: 300,
			layout: 'fit',
			items: lvc
		});
		lvc.loadItems({});
		window.show();
	}
});