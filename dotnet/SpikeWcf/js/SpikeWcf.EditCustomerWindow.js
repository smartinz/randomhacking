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
			api: {
				load: function (a, b) {
					var aa = a;
					var bb = b;

					for( var i = 0; i < arguments.length; i++ ) {
						alert(arguments[i]);
					}
				},
				submit: function (a, b, c) {
					var aa = a;
					var bb = b;
					var cc = c;
					
					for( var i = 0; i < arguments.length; i++ ) {
						alert(arguments[i]);
					}
				}
			},
			buttons: [{
				text: 'Load',
				handler: function () {
					this.editCustomerFormPanel.getForm().load({params: {foo: 'bar', uid: 34}});
				},
				scope: this
			},
			{
				text: 'Save',
				handler: function () {
					this.editCustomerFormPanel.getForm().submit();
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
