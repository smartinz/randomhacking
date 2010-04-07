"use strict";

Ext.namespace("SpikeWcf");

SpikeWcf.EditCustomerWindow = Ext.extend(Ext.Window, {
	title: 'Edit Customer',
	width: 650,
	height: 390,
	layout: 'fit',
	initComponent: function() {
		this.items = [
            {
            	xtype: 'form',
            	labelWidth: 100,
            	labelAlign: 'left',
            	layout: 'form',
            	border: false,
            	padding: 10,
            	items: [
                    {
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
                    }
                ]
            }
        ];
		SpikeWcf.EditCustomerWindow.superclass.initComponent.call(this);
	}
});
