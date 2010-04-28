"use strict";

Ext.namespace("ExtMvc");

ExtMvc.SearchCustomerWindow = Ext.extend(Ext.Window, {
	title: 'Search Customer',
	width: 600,
	height: 300,
	layout: 'fit',
	initComponent: function () {
		this.items = new ExtMvc.CustomerSearchPanel();
		ExtMvc.SearchCustomerWindow.superclass.initComponent.call(this);
	}
});