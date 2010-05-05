/*jslint white: true, browser: true, devel: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
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
				new ExtMvc.OrderListField({ title: 'Orders', name: 'Orders' })
			]
		}];

		ExtMvc.CustomerFormPanel.superclass.initComponent.call(this);
	},

/*
	// For a less invasive wait message
	onRender: function (ct, position) {
		ExtMvc.CustomerFormPanel.superclass.onRender.call(this, ct, position);
		if (!this.getForm().waitMsgTarget) {
			this.getForm().waitMsgTarget = this.el.id;
		}
	},
*/

	loadClick: function () {
		this.getForm().doAction(new Rpc.JsonLoadFormAction(this.getForm(), {
			url: '/Customer/Get',
			params: { id: 'ALFKI' },
			waitMsg: 'Loading...'
		}));
	},

	saveClick: function () {
		this.getForm().doAction(new Rpc.JsonSubmitFormAction(this.getForm(), {
			url: '/Customer/Update',
			waitMsg: 'Saving...'
		}));
	}
});
