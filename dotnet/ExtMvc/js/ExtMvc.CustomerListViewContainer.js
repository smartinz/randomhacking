"use strict";

Ext.namespace("ExtMvc");

ExtMvc.CustomerListViewContainer = Ext.extend(Ext.Container, {
	layout: 'fit',
	initComponent: function () {
		this.gridPanel =  this.buildGridPanel();
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

	buildGridPanel: function () {
		var store = new Ext.data.Store({
			proxy: new Rpc.JsonPostHttpProxy({
				url: '/Customer/Find'
			}),
			remoteSort: true,
			reader: new Ext.data.JsonReader({
				root: 'items',
				idProperty: "CustomerId",
				totalProperty: 'count',
				fields: ['CustomerId', 'CompanyName', 'ContactName', 'ContactTitle', 'Address', 'City', 'Region', 'PostalCode', 'Country', 'Phone', 'Fax']
			})
		});

		return new Ext.grid.GridPanel({
			border: false,
			store: store,
			colModel: new Ext.grid.ColumnModel({
				defaults: { width: 60, sortable: true },
				columns: [
					{ dataIndex: 'CustomerId', header: "Id" },
					{ dataIndex: 'CompanyName', header: "Company", width: 180 },
					{ dataIndex: 'ContactName', header: "Contact name", width: 120 },
					{ dataIndex: 'ContactTitle', header: "Contact title", width: 120 },
					{ dataIndex: 'Address', header: "Address", width: 120 },
					{ dataIndex: 'City', header: "City" },
					{ dataIndex: 'Region', header: "Region" },
					{ dataIndex: 'PostalCode', header: "Postal code" },
					{ dataIndex: 'Country', header: "Country" },
					{ dataIndex: 'Phone', header: "Phone", width: 120 },
					{ dataIndex: 'Fax', header: "Fax", width: 120 }
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