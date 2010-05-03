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

		this.OrderListViewContainer = new ExtMvc.OrderListViewContainer({ title: 'Orders' });

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
			items: [
				this.OrderListViewContainer
			]
		}];

		ExtMvc.CustomerFormPanel.superclass.initComponent.call(this);
	},

	loadClick: function () {
		var that = this;
		that.el.mask('Please wait...', 'x-mask-loading');
		Rpc.call('/Customer/Get', { id: 'ALFKI' }, function (success, ret) {
			that.getForm().setValues(ret);
			that.OrderListViewContainer.setValue(ret.Orders);
			that.OrderListViewContainer.loadItems();
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
