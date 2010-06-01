/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, Rpc, ExtMvc */
"use strict";

Ext.namespace('ExtMvc');

ExtMvc.OrderNormalSearchContainer = Ext.extend(Ext.Container, {
	layout: 'vbox',
	layoutConfig: {
		align: 'stretch',
		pack: 'start'
	},
	initComponent: function () {
		var store = new Ext.data.Store({
			proxy: new Rpc.JsonPostHttpProxy({
				url: '/Order/SearchNormal'
			}),
			remoteSort: true,
			reader: new ExtMvc.OrderJsonReader()
		});
		this.gridPanel = new ExtMvc.OrderGridPanel({
			flex: 1,
			store: store,
			bbar: new Ext.PagingToolbar({
				store: store,
				displayInfo: true,
				pageSize: 25,
				prependButtons: true
			}),
			listeners: {
				rowdblclick: {
					fn: this.gridPanel_rowDblClick,
					scope: this
				}
			}
		});

		this.searchFormPanel = new Ext.form.FormPanel({
			labelWidth: 100,
			border: false,
			padding: 10,
			items: [{ name: 'orderId', xtype: 'textfield', fieldLabel: 'orderId', anchor: '100%' }, { name: 'orderDate', xtype: 'textfield', fieldLabel: 'orderDate', anchor: '100%' }, { name: 'requiredDate', xtype: 'textfield', fieldLabel: 'requiredDate', anchor: '100%' }, { name: 'shippedDate', xtype: 'textfield', fieldLabel: 'shippedDate', anchor: '100%' }, { name: 'freight', xtype: 'textfield', fieldLabel: 'freight', anchor: '100%' }, { name: 'shipName', xtype: 'textfield', fieldLabel: 'shipName', anchor: '100%' }, { name: 'shipAddress', xtype: 'textfield', fieldLabel: 'shipAddress', anchor: '100%' }, { name: 'shipCity', xtype: 'textfield', fieldLabel: 'shipCity', anchor: '100%' }, { name: 'shipRegion', xtype: 'textfield', fieldLabel: 'shipRegion', anchor: '100%' }, { name: 'shipPostalCode', xtype: 'textfield', fieldLabel: 'shipPostalCode', anchor: '100%' }, { name: 'shipCountry', xtype: 'textfield', fieldLabel: 'shipCountry', anchor: '100%' }, { name: 'customer', xtype: 'ExtMvc.CustomerField', fieldLabel: 'customer', anchor: '100%' }, { name: 'employee', xtype: 'ExtMvc.EmployeeField', fieldLabel: 'employee', anchor: '100%' }, { name: 'shipper', xtype: 'ExtMvc.ShipperField', fieldLabel: 'shipper', anchor: '100%' }],
			buttons: [{
				xtype: 'button',
				text: 'Search',
				handler: this.searchClick,
				scope: this
			}]
		});

		this.items = [this.searchFormPanel, this.gridPanel];

		this.addEvents('itemselected');

		ExtMvc.OrderNormalSearchContainer.superclass.initComponent.call(this);
	},

	gridPanel_rowDblClick: function (grid, rowIndex, event) {
		var item = grid.getStore().getAt(rowIndex).data;
		this.fireEvent('itemselected', this, item);
	},

	searchClick: function (b, e) {
		var args = this.searchFormPanel.getForm().getFieldValues();
		this.gridPanel.getStore().load({
			params: Ext.apply({
				start: 0,
				limit: this.gridPanel.getBottomToolbar().pageSize
			}, args)
		});
	}
});