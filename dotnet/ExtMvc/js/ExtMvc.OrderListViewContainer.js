/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.OrderListViewContainer = Ext.extend(Ext.Container, {
	layout: 'fit',
	initComponent: function () {
		var store = new Ext.data.Store({
			proxy: this.dataProxy,
			remoteSort: true,
			reader: new ExtMvc.OrderJsonReader()
		});

		this.gridPanel = new ExtMvc.OrderGridPanel({
			store: store,
			bbar: new Ext.PagingToolbar({
				store: store,
				displayInfo: true,
				pageSize: 25,
				prependButtons: true
			})
		});

		this.items = this.gridPanel;

		this.addEvents('itemselected');

		this.gridPanel.on('rowdblclick', this.gridPanel_rowDblClick, this);

		ExtMvc.OrderListViewContainer.superclass.initComponent.call(this);
	},

	gridPanel_rowDblClick: function (grid, rowIndex, event) {
		var item = grid.getStore().getAt(rowIndex).data;
		this.fireEvent('itemselected', this, item);
	},

	setValue: function (items) {
		this.gridPanel.getStore().proxy.data.items = items;
	},

	loadItems: function (args) {
		this.gridPanel.getStore().load({
			params: Ext.apply({
				start: 0,
				limit: this.gridPanel.getBottomToolbar().pageSize
			}, args)
		});
	}
});