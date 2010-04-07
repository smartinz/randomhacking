"use strict";

Ext.namespace("SpikeWcf");

SpikeWcf.EditCustomerWindow = Ext.extend(Ext.Window, {
	title: 'Edit Customer',
	width: 300,
	height: 300,
	layout: 'fit',
	initComponent: function() {
		this.editCustomerFormPanel = new Ext.form.FormPanel({
			labelWidth: 100,
			labelAlign: 'left',
			layout: 'form',
			border: false,
			padding: 10,
			buttons: [{
				text: 'Load',
				handler: function () {
					alert('ok');
				}
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
