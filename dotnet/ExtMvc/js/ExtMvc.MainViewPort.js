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
		var obj = JSON.parse('{"CustomerId":"ALFKI","CompanyName":"Alfreds Futterkiste","ContactName":"Maria Anders","ContactTitle":"Sales Representative","Address":"Obere Str. 57","City":"Berlin","Region":null,"PostalCode":"12209","Country":"Germany","Phone":"030-0074321","Fax":"030-0076545","Orders":[{"OrderId":10643,"OrderDate":"\/Date(872460000000)\/","RequiredDate":"\/Date(874879200000)\/","ShippedDate":"\/Date(873151200000)\/","Freight":29.4600,"ShipName":"Alfreds Futterkiste","ShipAddress":"Obere Str. 57","ShipCity":"Berlin","ShipRegion":null,"ShipPostalCode":"12209","ShipCountry":"Germany"},{"OrderId":10692,"OrderDate":"\/Date(875829600000)\/","RequiredDate":"\/Date(878252400000)\/","ShippedDate":"\/Date(876693600000)\/","Freight":61.0200,"ShipName":"Alfred\u0027s Futterkiste","ShipAddress":"Obere Str. 57","ShipCity":"Berlin","ShipRegion":null,"ShipPostalCode":"12209","ShipCountry":"Germany"},{"OrderId":10702,"OrderDate":"\/Date(876693600000)\/","RequiredDate":"\/Date(880326000000)\/","ShippedDate":"\/Date(877384800000)\/","Freight":23.9400,"ShipName":"Alfred\u0027s Futterkiste","ShipAddress":"Obere Str. 57","ShipCity":"Berlin","ShipRegion":null,"ShipPostalCode":"12209","ShipCountry":"Germany"},{"OrderId":10835,"OrderDate":"\/Date(884818800000)\/","RequiredDate":"\/Date(887238000000)\/","ShippedDate":"\/Date(885337200000)\/","Freight":69.5300,"ShipName":"Alfred\u0027s Futterkiste","ShipAddress":"Obere Str. 57","ShipCity":"Berlin","ShipRegion":null,"ShipPostalCode":"12209","ShipCountry":"Germany"},{"OrderId":10952,"OrderDate":"\/Date(890002800000)\/","RequiredDate":"\/Date(893628000000)\/","ShippedDate":"\/Date(890694000000)\/","Freight":40.4200,"ShipName":"Alfred\u0027s Futterkiste","ShipAddress":"Obere Str. 57","ShipCity":"Berlin","ShipRegion":null,"ShipPostalCode":"12209","ShipCountry":"Germany"},{"OrderId":11011,"OrderDate":"\/Date(892072800000)\/","RequiredDate":"\/Date(894492000000)\/","ShippedDate":"\/Date(892418400000)\/","Freight":1.2100,"ShipName":"Alfred\u0027s Futterkiste","ShipAddress":"Obere Str. 57","ShipCity":"Berlin","ShipRegion":null,"ShipPostalCode":"12209","ShipCountry":"Germany"}]}');
		var lvc = new ExtMvc.CustomerListViewContainer({
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