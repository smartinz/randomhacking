/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc, Rpc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.CustomerFormPanel = Ext.extend(Ext.form.FormPanel, {
	border: false,
	layout: 'vbox',
	layoutConfig: {
		align: 'stretch',
		pack: 'start'
	},
	//padding: 10,

	initComponent: function () {
		this.buttons = [{
			text: 'Load',
			handler: this.loadClick,
			scope: this
		}, {
			text: 'Save',
			handler: this.saveClick,
			scope: this
		}];

		this.OrdersListViewContainer = new ExtMvc.CustomerListViewContainer({
			title: 'Customers',
			dataProxy: new Ext.data.MemoryProxy({ items: JSON.parse('{"CustomerId":"ALFKI","CompanyName":"Alfreds Futterkiste","ContactName":"Maria Anders","ContactTitle":"Sales Representative","Address":"Obere Str. 57","City":"Berlin","Region":null,"PostalCode":"12209","Country":"Germany","Phone":"030-0074321","Fax":"030-0076545","Orders":[{"OrderId":10643,"OrderDate":"\/Date(872460000000)\/","RequiredDate":"\/Date(874879200000)\/","ShippedDate":"\/Date(873151200000)\/","Freight":29.4600,"ShipName":"Alfreds Futterkiste","ShipAddress":"Obere Str. 57","ShipCity":"Berlin","ShipRegion":null,"ShipPostalCode":"12209","ShipCountry":"Germany"},{"OrderId":10692,"OrderDate":"\/Date(875829600000)\/","RequiredDate":"\/Date(878252400000)\/","ShippedDate":"\/Date(876693600000)\/","Freight":61.0200,"ShipName":"Alfred\u0027s Futterkiste","ShipAddress":"Obere Str. 57","ShipCity":"Berlin","ShipRegion":null,"ShipPostalCode":"12209","ShipCountry":"Germany"},{"OrderId":10702,"OrderDate":"\/Date(876693600000)\/","RequiredDate":"\/Date(880326000000)\/","ShippedDate":"\/Date(877384800000)\/","Freight":23.9400,"ShipName":"Alfred\u0027s Futterkiste","ShipAddress":"Obere Str. 57","ShipCity":"Berlin","ShipRegion":null,"ShipPostalCode":"12209","ShipCountry":"Germany"},{"OrderId":10835,"OrderDate":"\/Date(884818800000)\/","RequiredDate":"\/Date(887238000000)\/","ShippedDate":"\/Date(885337200000)\/","Freight":69.5300,"ShipName":"Alfred\u0027s Futterkiste","ShipAddress":"Obere Str. 57","ShipCity":"Berlin","ShipRegion":null,"ShipPostalCode":"12209","ShipCountry":"Germany"},{"OrderId":10952,"OrderDate":"\/Date(890002800000)\/","RequiredDate":"\/Date(893628000000)\/","ShippedDate":"\/Date(890694000000)\/","Freight":40.4200,"ShipName":"Alfred\u0027s Futterkiste","ShipAddress":"Obere Str. 57","ShipCity":"Berlin","ShipRegion":null,"ShipPostalCode":"12209","ShipCountry":"Germany"},{"OrderId":11011,"OrderDate":"\/Date(892072800000)\/","RequiredDate":"\/Date(894492000000)\/","ShippedDate":"\/Date(892418400000)\/","Freight":1.2100,"ShipName":"Alfred\u0027s Futterkiste","ShipAddress":"Obere Str. 57","ShipCity":"Berlin","ShipRegion":null,"ShipPostalCode":"12209","ShipCountry":"Germany"}]}') })
		});

		// see http://www.extjs.com/forum/showthread.php?98131
		this.items = [{
			layout: 'form',
			border: false,
			padding: 10,
			items: [
				{ name: 'CompanyName', fieldLabel: 'Company name', xtype: 'textfield', anchor: '100%' },
				{ name: 'ContactName', fieldLabel: 'Contact name', xtype: 'textfield', anchor: '100%' },
				{ name: 'ContactTitle', fieldLabel: 'Contact title', xtype: 'textfield', anchor: '100%' },
				{ name: 'Address', fieldLabel: 'Address', xtype: 'textfield', anchor: '100%' },
				{ name: 'City', fieldLabel: 'City', xtype: 'textfield', anchor: '100%' },
				{ name: 'Region', fieldLabel: 'Region', xtype: 'textfield', anchor: '100%' },
				{ name: 'PostalCode', fieldLabel: 'Postal code', xtype: 'textfield', anchor: '100%' },
				{ name: 'Country', fieldLabel: 'Country', xtype: 'textfield', anchor: '100%' },
				{ name: 'Phone', fieldLabel: 'Phone', xtype: 'textfield', anchor: '100%' },
				{ name: 'Fax', fieldLabel: 'Fax', xtype: 'textfield', anchor: '100%' },
				new ExtMvc.CustomerField({ name: 'Test', fieldLabel: 'Customer', anchor: '100%' })
			]
		}, {
			flex: 1,
			xtype: 'tabpanel',
			plain: true,
			border: false,
			activeTab: 0,
			deferredRender: false, // IMPORTANT! See http://www.extjs.com/deploy/dev/examples/form/dynamic.js
			items: [ this.OrdersListViewContainer ]
		}];

		ExtMvc.CustomerFormPanel.superclass.initComponent.call(this);
	},

	loadClick: function () {
		var that = this;
		that.el.mask('Please wait...', 'x-mask-loading');
		Rpc.call('/Customer/Get', { id: 'ALFKI' }, function (success, ret) {
			that.getForm().setValues(ret);
			that.el.unmask();
		});
	},

	saveClick: function () {
		var vals = this.getForm().getFieldValues();
		Rpc.call('/Customer/Update', { customer: vals }, function (success) {
			document.alert(success ? 'done' : 'error');
		});
	}
});
