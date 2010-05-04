/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.CustomerListViewContainer = Ext.extend(Ext.Container, {
	layout: 'fit',
	initComponent: function () {
		this.gridPanel =  this.buildGridPanel(this.dataProxy);
		this.items = this.gridPanel;

		this.addEvents('itemselected');

		this.gridPanel.on('rowdblclick', this.gridPanel_rowDblClick, this);

		ExtMvc.CustomerListViewContainer.superclass.initComponent.call(this);
	},

	gridPanel_rowDblClick: function (grid, rowIndex, event) {
		var item = grid.getStore().getAt(rowIndex).data;
		this.fireEvent('itemselected', this, item);
	},

	loadItems: function (args) {
		this.gridPanel.getStore().load({
			params: Ext.apply({
				start: 0,
				limit: this.gridPanel.getBottomToolbar().pageSize
			}, args)
		});
	},

	buildGridPanel: function (dataProxy) {
		var store = new Ext.data.Store({
			proxy: dataProxy,
			remoteSort: true,
			reader: new Ext.data.JsonReader({
				root: 'items',
				idProperty: "CustomerId",
				totalProperty: 'count',
				fields: ['CustomerId', 'CompanyName', 'ContactName', 'ContactTitle', 'Address', 'City', 'Region', 'PostalCode', 'Country', 'Phone', 'Fax']
			})
		});

		return new ExtMvc.CustomerGridPanel({
			store: store,
			bbar: new Ext.PagingToolbar({
				store: store,
				displayInfo: true,
				pageSize: 25,
				prependButtons: true
			})
		});
	}
});