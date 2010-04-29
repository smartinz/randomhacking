"use strict";

Ext.namespace("ExtMvc");

ExtMvc.EditCustomerWindow = Ext.extend(Ext.Window, {
	title: 'Edit Customer',
	width: 300,
	height: 300,
	layout: 'fit',
	initComponent: function () {
		this.items = new ExtMvc.CustomerFormPanel();
		ExtMvc.EditCustomerWindow.superclass.initComponent.call(this);
	}
});
