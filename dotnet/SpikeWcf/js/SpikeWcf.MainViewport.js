"use strict";

Ext.namespace("SpikeWcf");

SpikeWcf.MainViewport = Ext.extend(Ext.Viewport, {
	layout: 'fit',
	hideBorders: true,
	initComponent: function () {
		this.items = [{
			xtype: 'panel',
			tbar: {
				xtype: 'toolbar',
				items: [{
					xtype: 'button',
					text: 'Search Customer',
					handler: this.searchCustomerClick,
					scope: this
				},
				{
					xtype: 'button',
					text: 'Edit Customer',
					handler: this.editCustomerClick,
					scope: this
				}]
			}
		}];
		SpikeWcf.MainViewport.superclass.initComponent.call(this);
	},
	
	searchCustomerClick: function () {
		var window = new SpikeWcf.SearchCustomerWindow();
		window.show();
	},
	
	editCustomerClick: function () {
		var window = new SpikeWcf.EditCustomerWindow();
		window.show();
	}
});