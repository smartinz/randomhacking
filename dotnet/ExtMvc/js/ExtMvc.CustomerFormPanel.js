"use strict";

Ext.namespace("ExtMvc");

ExtMvc.CustomerFormPanel = Ext.extend(Ext.form.FormPanel, {
	border: false,
	padding: 10,
	defaults: { xtype: 'textfield', anchor: '100%' },

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

		this.triggerField = new ExtMvc.CustomerField({
			name: 'Test',
			fieldLabel: 'Fax',
			anchor: '100%'
		});

		// see http://www.extjs.com/forum/showthread.php?98131
		this.items = [
			{ name: 'CompanyName', fieldLabel: 'Company name' },
			{ name: 'ContactName', fieldLabel: 'Contact name' },
			{ name: 'ContactTitle', fieldLabel: 'Contact title' },
			{ name: 'Address', fieldLabel: 'Address' },
			{ name: 'City', fieldLabel: 'City' },
			{ name: 'Region', fieldLabel: 'Region' },
			{ name: 'PostalCode', fieldLabel: 'Postal code' },
			{ name: 'Country', fieldLabel: 'Country' },
			{ name: 'Phone', fieldLabel: 'Phone' },
			{ name: 'Fax', fieldLabel: 'Fax' },
			this.triggerField
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
