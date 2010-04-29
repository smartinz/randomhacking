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
		var window = new Ext.Window({
			title: 'Search Customer',
			width: 600,
			height: 300,
			layout: 'fit',
			items: new ExtMvc.CustomerSearchPanel()
		});
		window.show();
	},

	editCustomerClick: function () {
		var window = new Ext.Window({
			title: 'Edit Customer',
			width: 300,
			height: 300,
			layout: 'fit',
			items: new ExtMvc.CustomerFormPanel()
		});
		window.show();
	}
});