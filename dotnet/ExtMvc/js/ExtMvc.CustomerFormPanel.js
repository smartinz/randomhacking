"use strict";

Ext.namespace("ExtMvc");

ExtMvc.CustomerFormPanel = Ext.extend(Ext.form.FormPanel, {
	border: false,
	padding: 10,

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
		this.items = [
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
		];

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
			alert(success ? 'done' : 'error');
		});
	}
});
