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
				handler: function () {
					this.editCustomerFormPanel.getForm().load({
						url: '/CustomerService.svc/Get',
						method: 'POST',
						params: { customerId: 'ALFKI' },
						//waitMsg: 'Loading',
						success: function(form, action) {
							Ext.MessageBox.alert('Message', 'Loaded OK');
						},
						failure: function(form, action) {
							Ext.MessageBox.alert('Message', 'Load failed');
						}
					});
				},
				scope: this
			},
			{
				text: 'Save',
				handler: function () {
					this.editCustomerFormPanel.getForm().submit({
						url: '/CustomerService.svc/Get',
						method: 'POST'
					});
				},
				scope: this
			}],
			items: [{
				xtype: 'textfield',
				fieldLabel: 'Company name',
				anchor: '100%'
			},
			{
				xtype: 'textfield',
				fieldLabel: 'Contact name',
				anchor: '100%'
			},
			{
				xtype: 'textfield',
				fieldLabel: 'Contact title',
				anchor: '100%'
			},
			{
				xtype: 'textfield',
				fieldLabel: 'Address',
				anchor: '100%'
			},
			{
				xtype: 'textfield',
				fieldLabel: 'City',
				anchor: '100%'
			},
			{
				xtype: 'textfield',
				fieldLabel: 'Region',
				anchor: '100%'
			},
			{
				xtype: 'textfield',
				fieldLabel: 'Postal code',
				anchor: '100%'
			},
			{
				xtype: 'textfield',
				fieldLabel: 'Country',
				anchor: '100%'
			},
			{
				xtype: 'textfield',
				fieldLabel: 'Phone',
				anchor: '100%'
			},
			{
				xtype: 'textfield',
				fieldLabel: 'Fax',
				anchor: '100%'
			}]
		});

		this.items = [this.editCustomerFormPanel];
		SpikeWcf.EditCustomerWindow.superclass.initComponent.call(this);
	}
});
