"use strict";

Ext.namespace("SpikeWcf");

SpikeWcf.EditCustomerWindow = Ext.extend(Ext.Window, {
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
			},
			{
				text: 'Save',
				handler: this.saveClick,
				scope: this
			}],
			items: [{
				name: 'companyName',
				xtype: 'textfield',
				fieldLabel: 'Company name',
				anchor: '100%'
			},
			{
				name: 'contactName',
				xtype: 'textfield',
				fieldLabel: 'Contact name',
				anchor: '100%'
			},
			{
				name: 'contactTitle',
				xtype: 'textfield',
				fieldLabel: 'Contact title',
				anchor: '100%'
			},
			{
				name: 'address',
				xtype: 'textfield',
				fieldLabel: 'Address',
				anchor: '100%'
			},
			{
				name: 'city',
				xtype: 'textfield',
				fieldLabel: 'City',
				anchor: '100%'
			},
			{
				name: 'region',
				xtype: 'textfield',
				fieldLabel: 'Region',
				anchor: '100%'
			},
			{
				name: 'postalCode',
				xtype: 'textfield',
				fieldLabel: 'Postal code',
				anchor: '100%'
			},
			{
				name: 'country',
				xtype: 'textfield',
				fieldLabel: 'Country',
				anchor: '100%'
			},
			{
				name: 'phone',
				xtype: 'textfield',
				fieldLabel: 'Phone',
				anchor: '100%'
			},
			{
				name: 'fax',
				xtype: 'textfield',
				fieldLabel: 'Fax',
				anchor: '100%'
			}]
		});

		this.items = [this.editCustomerFormPanel];
		SpikeWcf.EditCustomerWindow.superclass.initComponent.call(this);
	},

	loadClick: function () {
		var that = this;
		Wcf.invoke('/CustomerService.svc/Get', { customerId: 'ALFKI' }, function (ret) {
			that.editCustomerFormPanel.getForm().setValues(ret);
		});
	},

	saveClick: function () {
		var vals = this.editCustomerFormPanel.getForm().getFieldValues();
		Wcf.invoke('/CustomerService.svc/Save', { customer: vals }, function () {
			alert('done');
		});
	}
});
