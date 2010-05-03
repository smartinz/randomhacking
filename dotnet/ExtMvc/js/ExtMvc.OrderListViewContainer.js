/*jslint white: true, browser: true, onevar: true, undef: true, nomen: true, eqeqeq: true, plusplus: true, bitwise: true, regexp: true, strict: true, newcap: true, immed: true */
/*global Ext, ExtMvc */
"use strict";

Ext.namespace("ExtMvc");

ExtMvc.OrderListViewContainer = Ext.extend(Ext.Container, {
	layout: 'fit',
	initComponent: function () {
		this.gridPanel =  this.buildGridPanel(this.dataProxy);
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
	},

	buildGridPanel: function (dataProxy) {
		var store;

		store = new Ext.data.Store({
			proxy: dataProxy || new Ext.data.MemoryProxy({ items: [] }),
			remoteSort: dataProxy ? true : false,
			reader: new ExtMvc.OrderJsonReader()/*new Ext.data.JsonReader({
				root: 'items',
				idProperty: "OrderId",
				totalProperty: 'count',
				fields: ['OrderId', 'OrderDate', 'RequiredDate', 'ShippedDate', 'Freight', 'ShipName', 'ShipAddress', 'ShipCity', 'ShipRegion', 'ShipPostalCode', 'ShipCountry']
			})*/
		});

		return new Ext.grid.GridPanel({
			border: false,
			store: store,
			colModel: new Ext.grid.ColumnModel({
				defaults: { width: 60, sortable: true },
				columns: [
					{ dataIndex: 'OrderId', header: "OrderId" },
					{ dataIndex: 'OrderDate', header: "OrderDate" },
					{ dataIndex: 'RequiredDate', header: "RequiredDate" },
					{ dataIndex: 'ShippedDate', header: "ShippedDate" },
					{ dataIndex: 'Freight', header: "Freight" },
					{ dataIndex: 'ShipName', header: "ShipName" },
					{ dataIndex: 'ShipAddress', header: "ShipAddress" },
					{ dataIndex: 'ShipCity', header: "ShipCity" },
					{ dataIndex: 'ShipRegion', header: "ShipRegion" },
					{ dataIndex: 'ShipPostalCode', header: "ShipPostalCode" },
					{ dataIndex: 'ShipCountry', header: "ShipCountry" }
				]
			}),

			bbar: new Ext.PagingToolbar({
				store: store,
				displayInfo: true,
				pageSize: 25,
				prependButtons: true
			})
		});
	}
});