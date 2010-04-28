"use strict";

Ext.namespace("ExtMvc");

ExtMvc.EditCustomerWindow = Ext.extend(Ext.Window, {
	title: 'Edit Customer',
	width: 300,
	height: 300,
	layout: 'fit',
	initComponent: function() {
		this.editCustomerFormPanel = new Ext.form.FormPanel({
			border: false,
			padding: 10,
			buttons: [{
				text: 'Load',
				handler: this.loadClick,
				scope: this
			}, {
				text: 'Save',
				handler: this.saveClick,
				scope: this
			}],
			items: [{
				name: 'CompanyName',
				xtype: 'textfield',
				fieldLabel: 'Company name',
				anchor: '100%'
			}, {
				name: 'ContactName',
				xtype: 'textfield',
				fieldLabel: 'Contact name',
				anchor: '100%'
			}, {
				name: 'ContactTitle',
				xtype: 'textfield',
				fieldLabel: 'Contact title',
				anchor: '100%'
			}, {
				name: 'Address',
				xtype: 'textfield',
				fieldLabel: 'Address',
				anchor: '100%'
			}, {
				name: 'City',
				xtype: 'textfield',
				fieldLabel: 'City',
				anchor: '100%'
			}, {
				name: 'Region',
				xtype: 'textfield',
				fieldLabel: 'Region',
				anchor: '100%'
			}, {
				name: 'PostalCode',
				xtype: 'textfield',
				fieldLabel: 'Postal code',
				anchor: '100%'
			}, {
				name: 'Country',
				xtype: 'textfield',
				fieldLabel: 'Country',
				anchor: '100%'
			}, {
				name: 'Phone',
				xtype: 'textfield',
				fieldLabel: 'Phone',
				anchor: '100%'
			}, {
				name: 'Fax',
				xtype: 'textfield',
				fieldLabel: 'Fax',
				anchor: '100%'
			}]
		});

		this.items = [this.editCustomerFormPanel];
		ExtMvc.EditCustomerWindow.superclass.initComponent.call(this);
	},

	loadClick: function () {
		var that = this;
		that.el.mask('Please wait...', 'x-mask-loading');
		Rpc.call('/Customer/Get', { id: 'ALFKI' }, function (success, ret) {
			that.editCustomerFormPanel.getForm().setValues(ret);
			that.el.unmask();
		});
	},

	saveClick: function () {
		var vals = this.editCustomerFormPanel.getForm().getFieldValues();
		Rpc.call('/Customer/Update', { customer: vals }, function (success) {
			alert(success ? 'done' : 'error');
		});
	}
});
