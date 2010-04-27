"use strict";

Ext.namespace("ExtMvc");

ExtMvc.MainViewport = Ext.extend(Ext.Viewport, {
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
		ExtMvc.MainViewport.superclass.initComponent.call(this);
	},
	
	searchCustomerClick: function () {
		var window = new ExtMvc.SearchCustomerWindow();
		window.show();
	},
	
	editCustomerClick: function () {
		var window = new ExtMvc.EditCustomerWindow();
		window.show();
	}
});